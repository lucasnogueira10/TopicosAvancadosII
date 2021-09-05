using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjPadaria.Data;
using ProjPadaria.Model;

namespace ProjPadaria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PadariaController : ControllerBase
    {
        private readonly ProjPadariaContext _context;

        public PadariaController(ProjPadariaContext context)
        {
            _context = context;
        }

        // GET: api/Padaria
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Padaria>>> GetPadaria()
        {
            return await _context.Padaria.ToListAsync();
        }

        // GET: api/Padaria/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Padaria>> GetPadaria(int id)
        {
            var padaria = await _context.Padaria.FindAsync(id);

            if (padaria == null)
            {
                return NotFound();
            }

            return padaria;
        }

        // PUT: api/Padaria/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPadaria(int id, Padaria padaria)
        {
            if (id != padaria.Id)
            {
                return BadRequest();
            }

            _context.Entry(padaria).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PadariaExists(id))
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

        // POST: api/Padaria
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Padaria>> PostPadaria(Padaria padaria)
        {
            _context.Padaria.Add(padaria);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPadaria", new { id = padaria.Id }, padaria);
        }

        // DELETE: api/Padaria/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePadaria(int id)
        {
            var padaria = await _context.Padaria.FindAsync(id);
            if (padaria == null)
            {
                return NotFound();
            }

            _context.Padaria.Remove(padaria);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PadariaExists(int id)
        {
            return _context.Padaria.Any(e => e.Id == id);
        }
    }
}
