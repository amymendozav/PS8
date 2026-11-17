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
    public class InstructorAddressController : ControllerBase
    {
        private readonly WebRestOracleContext _context;

        public InstructorAddressController(WebRestOracleContext context)
        {
            _context = context;
        }

        // GET: api/InstructorAddress
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InstructorAddress>>> GetInstructorAddress()
        {
            return await _context.InstructorAddress.ToListAsync();
        }

        // GET: api/InstructorAddress/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InstructorAddress>> GetInstructorAddress(string id)
        {
            var instructorAddress = await _context.InstructorAddress.FindAsync(id);

            if (instructorAddress == null)
            {
                return NotFound();
            }

            return instructorAddress;
        }

        // PUT: api/InstructorAddress/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInstructorAddress(string id, InstructorAddress instructorAddress)
        {
            if (id != instructorAddress.InstructorAddressGuid)
            {
                return BadRequest();
            }

            _context.Entry(instructorAddress).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InstructorAddressExists(id))
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

        // POST: api/InstructorAddress
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<InstructorAddress>> PostInstructorAddress(InstructorAddress instructorAddress)
        {
            _context.InstructorAddress.Add(instructorAddress);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInstructorAddress", new { id = instructorAddress.InstructorAddressGuid }, instructorAddress);
        }

        // DELETE: api/InstructorAddress/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInstructorAddress(string id)
        {
            var instructorAddress = await _context.InstructorAddress.FindAsync(id);
            if (instructorAddress == null)
            {
                return NotFound();
            }

            _context.InstructorAddress.Remove(instructorAddress);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InstructorAddressExists(string id)
        {
            return _context.InstructorAddress.Any(e => e.InstructorAddressGuid == id);
        }
    }
}
