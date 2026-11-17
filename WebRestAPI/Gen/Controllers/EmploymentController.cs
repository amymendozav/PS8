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
    public class EmploymentController : ControllerBase
    {
        private readonly WebRestOracleContext _context;

        public EmploymentController(WebRestOracleContext context)
        {
            _context = context;
        }

        // GET: api/Employment
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employment>>> GetEmployment()
        {
            return await _context.Employment.ToListAsync();
        }

        // GET: api/Employment/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employment>> GetEmployment(string id)
        {
            var employment = await _context.Employment.FindAsync(id);

            if (employment == null)
            {
                return NotFound();
            }

            return employment;
        }

        // PUT: api/Employment/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployment(string id, Employment employment)
        {
            if (id != employment.EmploymentGuid)
            {
                return BadRequest();
            }

            _context.Entry(employment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmploymentExists(id))
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

        // POST: api/Employment
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Employment>> PostEmployment(Employment employment)
        {
            _context.Employment.Add(employment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployment", new { id = employment.EmploymentGuid }, employment);
        }

        // DELETE: api/Employment/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployment(string id)
        {
            var employment = await _context.Employment.FindAsync(id);
            if (employment == null)
            {
                return NotFound();
            }

            _context.Employment.Remove(employment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmploymentExists(string id)
        {
            return _context.Employment.Any(e => e.EmploymentGuid == id);
        }
    }
}
