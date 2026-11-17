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
    public class EmploymentPayController : ControllerBase
    {
        private readonly WebRestOracleContext _context;

        public EmploymentPayController(WebRestOracleContext context)
        {
            _context = context;
        }

        // GET: api/EmploymentPay
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmploymentPay>>> GetEmploymentPay()
        {
            return await _context.EmploymentPay.ToListAsync();
        }

        // GET: api/EmploymentPay/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmploymentPay>> GetEmploymentPay(string id)
        {
            var employmentPay = await _context.EmploymentPay.FindAsync(id);

            if (employmentPay == null)
            {
                return NotFound();
            }

            return employmentPay;
        }

        // PUT: api/EmploymentPay/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmploymentPay(string id, EmploymentPay employmentPay)
        {
            if (id != employmentPay.EmploymentPayGuid)
            {
                return BadRequest();
            }

            _context.Entry(employmentPay).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmploymentPayExists(id))
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

        // POST: api/EmploymentPay
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EmploymentPay>> PostEmploymentPay(EmploymentPay employmentPay)
        {
            _context.EmploymentPay.Add(employmentPay);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmploymentPay", new { id = employmentPay.EmploymentPayGuid }, employmentPay);
        }

        // DELETE: api/EmploymentPay/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmploymentPay(string id)
        {
            var employmentPay = await _context.EmploymentPay.FindAsync(id);
            if (employmentPay == null)
            {
                return NotFound();
            }

            _context.EmploymentPay.Remove(employmentPay);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmploymentPayExists(string id)
        {
            return _context.EmploymentPay.Any(e => e.EmploymentPayGuid == id);
        }
    }
}
