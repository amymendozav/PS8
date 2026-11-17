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
    public class GradeTypeWeightController : ControllerBase
    {
        private readonly WebRestOracleContext _context;

        public GradeTypeWeightController(WebRestOracleContext context)
        {
            _context = context;
        }

        // GET: api/GradeTypeWeight
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GradeTypeWeight>>> GetGradeTypeWeight()
        {
            return await _context.GradeTypeWeight.ToListAsync();
        }

        // GET: api/GradeTypeWeight/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GradeTypeWeight>> GetGradeTypeWeight(string id)
        {
            var gradeTypeWeight = await _context.GradeTypeWeight.FindAsync(id);

            if (gradeTypeWeight == null)
            {
                return NotFound();
            }

            return gradeTypeWeight;
        }

        // PUT: api/GradeTypeWeight/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGradeTypeWeight(string id, GradeTypeWeight gradeTypeWeight)
        {
            if (id != gradeTypeWeight.GradeTypeWeightGuid)
            {
                return BadRequest();
            }

            _context.Entry(gradeTypeWeight).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GradeTypeWeightExists(id))
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

        // POST: api/GradeTypeWeight
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GradeTypeWeight>> PostGradeTypeWeight(GradeTypeWeight gradeTypeWeight)
        {
            _context.GradeTypeWeight.Add(gradeTypeWeight);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGradeTypeWeight", new { id = gradeTypeWeight.GradeTypeWeightGuid }, gradeTypeWeight);
        }

        // DELETE: api/GradeTypeWeight/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGradeTypeWeight(string id)
        {
            var gradeTypeWeight = await _context.GradeTypeWeight.FindAsync(id);
            if (gradeTypeWeight == null)
            {
                return NotFound();
            }

            _context.GradeTypeWeight.Remove(gradeTypeWeight);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GradeTypeWeightExists(string id)
        {
            return _context.GradeTypeWeight.Any(e => e.GradeTypeWeightGuid == id);
        }
    }
}
