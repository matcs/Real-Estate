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
    public class ImoveisController : ControllerBase
    {
        private readonly RealEstateContext _context;

        public ImoveisController(RealEstateContext context)
        {
            _context = context;
        }

        // GET: api/Imoveis
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Imovel>>> GetImoveis()
        {
            /*var Imoveis =
                (from imovel in _context.Imoveis
                 join endereco in _context.Enderecos
                 on imovel.EnderecoRefId equals endereco.cod_endereco
                 select new
                 {                      
                     endereco.logradouro,
                     endereco.rua,
                     endereco.numero,
                     endereco.bairro,
                     endereco.municipio,
                     endereco.cep,
                     endereco.estado,
                     imovel.metro_quadrado,
                     imovel.numero_banheiros,
                     imovel.numero_quartos,
                 }
                 );
            return await Imoveis.ToListAsync();*/

            return await _context.Imoveis.ToListAsync();
        }

        // GET: api/Imoveis/5
        [HttpGet("{id}")]
        public async Task<Object> GetImovelDetails(int id)
        {

            var ImovelDetails =
                (from imovel in _context.Imoveis
                 join endereco in _context.Enderecos
                 on imovel.EnderecoRefId equals endereco.cod_endereco
                 where imovel.EnderecoRefId == id
                 select new
                 {
                     imovel.cod_imovel,
                     imovel.descricao,
                     imovel.metro_quadrado,
                     imovel.numero_banheiros,
                     imovel.numero_quartos,
                     endereco.logradouro,
                     endereco.rua,
                     endereco.numero,
                     endereco.bairro,
                     endereco.cep,
                     endereco.municipio,
                     endereco.estado
                 }
                 );

            return await ImovelDetails.ToListAsync();
        }

        // PUT: api/Imoveis/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutImovel(int id, Imovel imovel)
        {
            if (id != imovel.cod_imovel)
            {
                return BadRequest();
            }

            _context.Entry(imovel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ImovelExists(id))
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

        // POST: api/Imoveis
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Imovel>> PostImovel(Imovel imovel)
        {
            _context.Imoveis.Add(imovel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetImovel", new { id = imovel.cod_imovel }, imovel);
        }

        // DELETE: api/Imoveis/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Imovel>> DeleteImovel(int id)
        {
            var imovel = await _context.Imoveis.FindAsync(id);
            if (imovel == null)
            {
                return NotFound();
            }

            _context.Imoveis.Remove(imovel);
            await _context.SaveChangesAsync();

            return imovel;
        }

        private bool ImovelExists(int id)
        {
            return _context.Imoveis.Any(e => e.cod_imovel == id);
        }
    }
}
