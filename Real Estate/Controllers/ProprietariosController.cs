using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Real_Estate.Data;
using Real_Estate.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Real_Estate.Controllers
{   
    [Route("api/[controller]")]
    [ApiController]
    public class ProprietariosController : ControllerBase
    {
        private readonly RealEstateContext _context;

        public ProprietariosController(RealEstateContext context)
        {
            _context = context;
        }

        // GET: api/Proprietarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Proprietario>>> GetProprietarios()
        {
            return await _context.Proprietarios.ToListAsync();
        }

        //GET
        [HttpGet("Imoveis/{id}")]
        public async Task<Object> GetProprietarioImoveis(int id)
        {

            var ProprietarioImoveis =
                (from propri in _context.Proprietarios
                 join imovel in _context.Imoveis
                 on propri.cod_proprietario equals imovel.ProprietarioRefId
                 where propri.cod_proprietario == id
                 join endereco in _context.Enderecos
                 on imovel.EnderecoRefId equals endereco.cod_endereco
                 select new
                 {
                     imovel.cod_imovel,
                     imovel.descricao,
                     imovel.metro_quadrado,
                     imovel._tipoImovel,
                     endereco.logradouro,
                     endereco.rua,
                     endereco.numero,
                     endereco.bairro,
                     endereco.cep,
                     endereco.municipio,
                     endereco.estado
                 });

            return await ProprietarioImoveis.ToListAsync();
        }

        // GET: api/Proprietarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Proprietario>> GetProprietario(int id)
        {
            var proprietario = await _context.Proprietarios.FindAsync(id);

            if (proprietario == null)
            {
                return NotFound();
            }

            return proprietario;
        }

        // PUT: api/Proprietarios/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProprietario(int id, Proprietario proprietario)
        {
            if (id != proprietario.cod_proprietario)
            {
                return BadRequest();
            }

            _context.Entry(proprietario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProprietarioExists(id))
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

        [HttpPost("Login")]
        public async Task<ActionResult<Proprietario>> Login(Proprietario ProprietarioPost, int id)
        {
            var proprietario = await _context.Proprietarios.Where(x => x.email == ProprietarioPost.email).FirstAsync();

            if (proprietario.senha != ProprietarioPost.senha)
            {
                return NotFound();
            }
            
            return proprietario;
        }

        // POST: api/Proprietarios
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Proprietario>> PostProprietario(Proprietario proprietario)
        {
            _context.Proprietarios.Add(proprietario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProprietario", new { id = proprietario.cod_proprietario }, proprietario);
        }

        

        // DELETE: api/Proprietarios/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Proprietario>> DeleteProprietario(int id)
        {
            var proprietario = await _context.Proprietarios.FindAsync(id);
            if (proprietario == null)
            {
                return NotFound();
            }

            _context.Proprietarios.Remove(proprietario);
            await _context.SaveChangesAsync();

            return proprietario;
        }

        private bool ProprietarioExists(int id)
        {
            return _context.Proprietarios.Any(e => e.cod_proprietario == id);
        }
    }
}
