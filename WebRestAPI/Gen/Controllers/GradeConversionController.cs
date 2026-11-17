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
    public class GradeConversionController : ControllerBase
    {
        private readonly WebRestOracleContext _context;

        public GradeConversionController(WebRestOracleContext context)
        {
            _context = context;
        }

        // GET: api/GradeConversion
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GradeConversion>>> GetGradeConversion()
        {
            return await _context.GradeConversion.ToListAsync();
        }

        // GET: api/GradeConversion/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GradeConversion>> GetGradeConversion(string id)
        {
            var gradeConversion = await _context.GradeConversion.FindAsync(id);

            if (gradeConversion == null)
            {
                return NotFound();
            }

            return gradeConversion;
        }

        // PUT: api/GradeConversion/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGradeConversion(string id, GradeConversion gradeConversion)
        {
            if (id != gradeConversion.GradeConversionGuid)
            {
                return BadRequest();
            }

            _context.Entry(gradeConversion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GradeConversionExists(id))
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

        // POST: api/GradeConversion
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GradeConversion>> PostGradeConversion(GradeConversion gradeConversion)
        {
            _context.GradeConversion.Add(gradeConversion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGradeConversion", new { id = gradeConversion.GradeConversionGuid }, gradeConversion);
        }

        // DELETE: api/GradeConversion/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGradeConversion(string id)
        {
            var gradeConversion = await _context.GradeConversion.FindAsync(id);
            if (gradeConversion == null)
            {
                return NotFound();
            }

            _context.GradeConversion.Remove(gradeConversion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GradeConversionExists(string id)
        {
            return _context.GradeConversion.Any(e => e.GradeConversionGuid == id);
        }
    }
}
