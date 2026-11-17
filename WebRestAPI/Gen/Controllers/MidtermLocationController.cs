using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebRest.EF.Data;
using WebRest.EF.Models;

namespace gen.WebRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MidtermLocationController : ControllerBase
    {
        private readonly WebRestOracleContext _context;

        public MidtermLocationController(WebRestOracleContext context)
        {
            _context = context;
        }

        // GET: api/MidtermLocation
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MidtermLocation>>> GetMidtermLocation()
        {
            return await _context.MidtermLocation.ToListAsync();
        }

        // GET: api/MidtermLocation/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MidtermLocation>> GetMidtermLocation(string id)
        {
            var midtermLocation = await _context.MidtermLocation.FindAsync(id);

            if (midtermLocation == null)
            {
                return NotFound();
            }

            return midtermLocation;
        }

        // PUT: api/MidtermLocation/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMidtermLocation(string id, MidtermLocation midtermLocation)
        {
            if (id != midtermLocation.LocationGuid)
            {
                return BadRequest();
            }

            _context.Entry(midtermLocation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MidtermLocationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/MidtermLocation
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MidtermLocation>> PostMidtermLocation(MidtermLocation midtermLocation)
        {
            _context.MidtermLocation.Add(midtermLocation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMidtermLocation", new { id = midtermLocation.LocationGuid }, midtermLocation);
        }

        // DELETE: api/MidtermLocation/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMidtermLocation(string id)
        {
            var midtermLocation = await _context.MidtermLocation.FindAsync(id);
            if (midtermLocation == null)
            {
                return NotFound();
            }

            _context.MidtermLocation.Remove(midtermLocation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MidtermLocationExists(string id)
        {
            return _context.MidtermLocation.Any(e => e.LocationGuid == id);
        }
    }
}
