using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Real_Estate.Data;
using Real_Estate.Model;

namespace Real_Estate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CasasController : ControllerBase
    {
        private readonly RealEstateContext _context;

        public CasasController(RealEstateContext context)
        {
            _context = context;
        }

        // GET: api/Casas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Casa>>> GetCasas()
        {
            return await _context.Casas.ToListAsync();
        }

        // GET: api/Casas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Casa>> GetCasa(int id)
        {
            var casa = await _context.Casas.FindAsync(id);

            if (casa == null)
            {
                return NotFound();
            }

            return casa;
        }

        // PUT: api/Casas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCasa(int id, Casa casa)
        {
            if (id != casa.cod_casa)
            {
                return BadRequest();
            }

            _context.Entry(casa).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CasaExists(id))
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

        // POST: api/Casas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Casa>> PostCasa(Casa casa)
        {
            _context.Casas.Add(casa);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCasa", new { id = casa.cod_casa }, casa);
        }

        // DELETE: api/Casas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Casa>> DeleteCasa(int id)
        {
            var casa = await _context.Casas.FindAsync(id);
            if (casa == null)
            {
                return NotFound();
            }

            _context.Casas.Remove(casa);
            await _context.SaveChangesAsync();

            return casa;
        }

        private bool CasaExists(int id)
        {
            return _context.Casas.Any(e => e.cod_casa == id);
        }
    }
}
