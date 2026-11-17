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
    public class ZipcodeController : ControllerBase
    {
        private readonly WebRestOracleContext _context;

        public ZipcodeController(WebRestOracleContext context)
        {
            _context = context;
        }

        // GET: api/Zipcode
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Zipcode>>> GetZipcode()
        {
            return await _context.Zipcode.ToListAsync();
        }

        // GET: api/Zipcode/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Zipcode>> GetZipcode(string id)
        {
            var zipcode = await _context.Zipcode.FindAsync(id);

            if (zipcode == null)
            {
                return NotFound();
            }

            return zipcode;
        }

        // PUT: api/Zipcode/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutZipcode(string id, Zipcode zipcode)
        {
            if (id != zipcode.ZipcodeGuid)
            {
                return BadRequest();
            }

            _context.Entry(zipcode).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ZipcodeExists(id))
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

        // POST: api/Zipcode
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Zipcode>> PostZipcode(Zipcode zipcode)
        {
            _context.Zipcode.Add(zipcode);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetZipcode", new { id = zipcode.ZipcodeGuid }, zipcode);
        }

        // DELETE: api/Zipcode/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteZipcode(string id)
        {
            var zipcode = await _context.Zipcode.FindAsync(id);
            if (zipcode == null)
            {
                return NotFound();
            }

            _context.Zipcode.Remove(zipcode);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ZipcodeExists(string id)
        {
            return _context.Zipcode.Any(e => e.ZipcodeGuid == id);
        }
    }
}
