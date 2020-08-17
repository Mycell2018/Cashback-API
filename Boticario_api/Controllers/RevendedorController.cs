using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Boticario_api.Models;
using Boticario_api.Data;

namespace Boticario_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RevendedorController : ControllerBase
    {
        private readonly Context _context;

        public RevendedorController(Context context)
        {
            _context = context;
        }

        // GET: api/Revendedor
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Revendedor>>> GetRevendedores()
        {
            return await _context.Revendedores.ToListAsync();
        }

        // GET: api/Revendedor/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Revendedor>> GetRevendedor(long id)
        {
            var revendedor = await _context.Revendedores.FindAsync(id);

            if (revendedor == null)
            {
                return NotFound();
            }

            return revendedor;
        }

        // PUT: api/Revendedor/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRevendedor(long id, Revendedor revendedor)
        {
            if (id != revendedor.id)
            {
                return BadRequest();
            }

            _context.Entry(revendedor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RevendedorExists(id))
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

        // POST: api/Revendedor
        [HttpPost]
        public async Task<ActionResult<Revendedor>> PostRevendedor(Revendedor revendedor)
        {
            _context.Revendedores.Add(revendedor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRevendedor", new { id = revendedor.id }, revendedor);
        }

        // DELETE: api/Revendedor/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Revendedor>> DeleteRevendedor(long id)
        {
            var revendedor = await _context.Revendedores.FindAsync(id);
            if (revendedor == null)
            {
                return NotFound();
            }

            _context.Revendedores.Remove(revendedor);
            await _context.SaveChangesAsync();

            return revendedor;
        }

        private bool RevendedorExists(long id)
        {
            return _context.Revendedores.Any(e => e.id == id);
        }
    }
}
