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
    public class StudentAddressController : ControllerBase
    {
        private readonly WebRestOracleContext _context;

        public StudentAddressController(WebRestOracleContext context)
        {
            _context = context;
        }

        // GET: api/StudentAddress
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentAddress>>> GetStudentAddress()
        {
            return await _context.StudentAddress.ToListAsync();
        }

        // GET: api/StudentAddress/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentAddress>> GetStudentAddress(string id)
        {
            var studentAddress = await _context.StudentAddress.FindAsync(id);

            if (studentAddress == null)
            {
                return NotFound();
            }

            return studentAddress;
        }

        // PUT: api/StudentAddress/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudentAddress(string id, StudentAddress studentAddress)
        {
            if (id != studentAddress.StudentAddressGuid)
            {
                return BadRequest();
            }

            _context.Entry(studentAddress).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentAddressExists(id))
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

        // POST: api/StudentAddress
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StudentAddress>> PostStudentAddress(StudentAddress studentAddress)
        {
            _context.StudentAddress.Add(studentAddress);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudentAddress", new { id = studentAddress.StudentAddressGuid }, studentAddress);
        }

        // DELETE: api/StudentAddress/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudentAddress(string id)
        {
            var studentAddress = await _context.StudentAddress.FindAsync(id);
            if (studentAddress == null)
            {
                return NotFound();
            }

            _context.StudentAddress.Remove(studentAddress);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudentAddressExists(string id)
        {
            return _context.StudentAddress.Any(e => e.StudentAddressGuid == id);
        }
    }
}
