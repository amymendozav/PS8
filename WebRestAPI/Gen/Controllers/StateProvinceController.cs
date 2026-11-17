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
    public class StateProvinceController : ControllerBase
    {
        private readonly WebRestOracleContext _context;

        public StateProvinceController(WebRestOracleContext context)
        {
            _context = context;
        }

        // GET: api/StateProvince
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StateProvince>>> GetStateProvince()
        {
            return await _context.StateProvince.ToListAsync();
        }

        // GET: api/StateProvince/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StateProvince>> GetStateProvince(string id)
        {
            var stateProvince = await _context.StateProvince.FindAsync(id);

            if (stateProvince == null)
            {
                return NotFound();
            }

            return stateProvince;
        }

        // PUT: api/StateProvince/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStateProvince(string id, StateProvince stateProvince)
        {
            if (id != stateProvince.StateProvinceGuid)
            {
                return BadRequest();
            }

            _context.Entry(stateProvince).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StateProvinceExists(id))
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

        // POST: api/StateProvince
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StateProvince>> PostStateProvince(StateProvince stateProvince)
        {
            _context.StateProvince.Add(stateProvince);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStateProvince", new { id = stateProvince.StateProvinceGuid }, stateProvince);
        }

        // DELETE: api/StateProvince/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStateProvince(string id)
        {
            var stateProvince = await _context.StateProvince.FindAsync(id);
            if (stateProvince == null)
            {
                return NotFound();
            }

            _context.StateProvince.Remove(stateProvince);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StateProvinceExists(string id)
        {
            return _context.StateProvince.Any(e => e.StateProvinceGuid == id);
        }
    }
}
