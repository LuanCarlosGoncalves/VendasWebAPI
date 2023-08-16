using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VendasWebAPI.DbContextMysql;
using VendasWebAPI.Entidades;
using VendasWebAPI.ViewModels;

namespace VendasWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcaController : ControllerBase

    {
        public readonly MySQLDbContext _mySQLDbContext;

        public MarcaController(MySQLDbContext mySQLDbContext)
        {
            _mySQLDbContext = mySQLDbContext;
        }


        [HttpPost]

        public async Task<IActionResult> Cadastrar([FromBody] CadastrarMarcaViewModel model)
        {
            var marca = new Marca
            {
                Nome = model.Nome,

                Tamanho = model.Tamanho,

            };

            await _mySQLDbContext.Marca.AddAsync(marca);
            await _mySQLDbContext.SaveChangesAsync();
            return Ok("salvo");

        }

        [HttpGet("ListarTodos")]
        public async Task<IActionResult> ListarTodos()
        {

            var marca = await _mySQLDbContext.Marca.ToListAsync();

            return Ok(marca);
        }

        [HttpGet("ListarPorId")]
        public async Task<IActionResult> ListarPorId(int marcaId)
        {
            var marca = await _mySQLDbContext.Cliente.FirstOrDefaultAsync(p => p.Id == marcaId);

            return Ok(marca);
        }

        [HttpPut]
        public async Task<IActionResult> Atualizar([FromBody] AtualizarMarcaViewModel model)
        {
            var marca = await _mySQLDbContext.Marca.FirstOrDefaultAsync(p => p.Id == model.Id);
            {
                if (marca == null)
                    return BadRequest("nao existe");
            }

            marca.Nome = model.Nome;

            marca.Tamanho = model.Tamanho;



            _mySQLDbContext.Marca.Update(marca);

            await _mySQLDbContext.SaveChangesAsync();

            return Ok("Alterado");

        }

        [HttpDelete]
        public async Task<IActionResult> Excluir(int marcaId)
        {
            var marca = await _mySQLDbContext.Marca.FirstOrDefaultAsync(p => p.Id == marcaId);

            if (marca == null)
            {
                return BadRequest("Marca não encontrado");
            }

            _mySQLDbContext.Remove(marca);
            await _mySQLDbContext.SaveChangesAsync();

            return NoContent();


        }

    }


}
