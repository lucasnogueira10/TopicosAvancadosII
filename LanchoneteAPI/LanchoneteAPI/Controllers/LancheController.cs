using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LanchoneteAPI.Data;
using LanchoneteAPI.Model;

namespace LanchoneteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LancheController : ControllerBase
    {
        private readonly LanchoneteAPIContext _context;

        public LancheController(LanchoneteAPIContext context)
        {
            _context = context;
        }

        // GET: api/Lanche
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Lanche>>> GetLanche()
        {
            return await _context.Lanche.ToListAsync();
        }

        // GET: api/Lanche/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Lanche>> GetLanche(int id)
        {
            var lanche = await _context.Lanche.FindAsync(id);

            if (lanche == null)
            {
                return NotFound();
            }

            return lanche;
        }

        // PUT: api/Lanche/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLanche(int id, Lanche lanche)
        {
            if (id != lanche.Id)
            {
                return BadRequest();
            }

            _context.Entry(lanche).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LancheExists(id))
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

        // POST: api/Lanche
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Lanche>> PostLanche(Lanche lanche)
        {
            _context.Lanche.Add(lanche);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLanche", new { id = lanche.Id }, lanche);
        }

        // DELETE: api/Lanche/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLanche(int id)
        {
            var lanche = await _context.Lanche.FindAsync(id);
            if (lanche == null)
            {
                return NotFound();
            }

            _context.Lanche.Remove(lanche);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LancheExists(int id)
        {
            return _context.Lanche.Any(e => e.Id == id);
        }
    }
}
