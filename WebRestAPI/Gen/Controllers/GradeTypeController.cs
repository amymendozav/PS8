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
    public class GradeTypeController : ControllerBase
    {
        private readonly WebRestOracleContext _context;

        public GradeTypeController(WebRestOracleContext context)
        {
            _context = context;
        }

        // GET: api/GradeType
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GradeType>>> GetGradeType()
        {
            return await _context.GradeType.ToListAsync();
        }

        // GET: api/GradeType/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GradeType>> GetGradeType(string id)
        {
            var gradeType = await _context.GradeType.FindAsync(id);

            if (gradeType == null)
            {
                return NotFound();
            }

            return gradeType;
        }

        // PUT: api/GradeType/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGradeType(string id, GradeType gradeType)
        {
            if (id != gradeType.GradeTypeGuid)
            {
                return BadRequest();
            }

            _context.Entry(gradeType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GradeTypeExists(id))
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

        // POST: api/GradeType
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GradeType>> PostGradeType(GradeType gradeType)
        {
            _context.GradeType.Add(gradeType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGradeType", new { id = gradeType.GradeTypeGuid }, gradeType);
        }

        // DELETE: api/GradeType/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGradeType(string id)
        {
            var gradeType = await _context.GradeType.FindAsync(id);
            if (gradeType == null)
            {
                return NotFound();
            }

            _context.GradeType.Remove(gradeType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GradeTypeExists(string id)
        {
            return _context.GradeType.Any(e => e.GradeTypeGuid == id);
        }
    }
}
