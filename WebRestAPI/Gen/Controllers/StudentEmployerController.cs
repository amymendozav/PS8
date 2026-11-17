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
    public class StudentEmployerController : ControllerBase
    {
        private readonly WebRestOracleContext _context;

        public StudentEmployerController(WebRestOracleContext context)
        {
            _context = context;
        }

        // GET: api/StudentEmployer
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentEmployer>>> GetStudentEmployer()
        {
            return await _context.StudentEmployer.ToListAsync();
        }

        // GET: api/StudentEmployer/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentEmployer>> GetStudentEmployer(string id)
        {
            var studentEmployer = await _context.StudentEmployer.FindAsync(id);

            if (studentEmployer == null)
            {
                return NotFound();
            }

            return studentEmployer;
        }

        // PUT: api/StudentEmployer/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudentEmployer(string id, StudentEmployer studentEmployer)
        {
            if (id != studentEmployer.StudentEmployerGuid)
            {
                return BadRequest();
            }

            _context.Entry(studentEmployer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentEmployerExists(id))
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

        // POST: api/StudentEmployer
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StudentEmployer>> PostStudentEmployer(StudentEmployer studentEmployer)
        {
            _context.StudentEmployer.Add(studentEmployer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudentEmployer", new { id = studentEmployer.StudentEmployerGuid }, studentEmployer);
        }

        // DELETE: api/StudentEmployer/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudentEmployer(string id)
        {
            var studentEmployer = await _context.StudentEmployer.FindAsync(id);
            if (studentEmployer == null)
            {
                return NotFound();
            }

            _context.StudentEmployer.Remove(studentEmployer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudentEmployerExists(string id)
        {
            return _context.StudentEmployer.Any(e => e.StudentEmployerGuid == id);
        }
    }
}
