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
    public class SectionLocationController : ControllerBase
    {
        private readonly WebRestOracleContext _context;

        public SectionLocationController(WebRestOracleContext context)
        {
            _context = context;
        }

        // GET: api/SectionLocation
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SectionLocation>>> GetSectionLocation()
        {
            return await _context.SectionLocation.ToListAsync();
        }

        // GET: api/SectionLocation/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SectionLocation>> GetSectionLocation(string id)
        {
            var sectionLocation = await _context.SectionLocation.FindAsync(id);

            if (sectionLocation == null)
            {
                return NotFound();
            }

            return sectionLocation;
        }

        // PUT: api/SectionLocation/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSectionLocation(string id, SectionLocation sectionLocation)
        {
            if (id != sectionLocation.SectionLocationGuid)
            {
                return BadRequest();
            }

            _context.Entry(sectionLocation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SectionLocationExists(id))
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

        // POST: api/SectionLocation
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SectionLocation>> PostSectionLocation(SectionLocation sectionLocation)
        {
            _context.SectionLocation.Add(sectionLocation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSectionLocation", new { id = sectionLocation.SectionLocationGuid }, sectionLocation);
        }

        // DELETE: api/SectionLocation/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSectionLocation(string id)
        {
            var sectionLocation = await _context.SectionLocation.FindAsync(id);
            if (sectionLocation == null)
            {
                return NotFound();
            }

            _context.SectionLocation.Remove(sectionLocation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SectionLocationExists(string id)
        {
            return _context.SectionLocation.Any(e => e.SectionLocationGuid == id);
        }
    }
}
