using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VendasWebAPI.DbContextMysql;
using VendasWebAPI.Entidades;
using VendasWebAPI.ViewModels;

namespace VendasWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModeloController : ControllerBase
    {
        public readonly MySQLDbContext _mySQLDbContext;

        public ModeloController(MySQLDbContext mySQLDbContext)
        {
            _mySQLDbContext = mySQLDbContext;
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar([FromBody] CadastrarModeloViewModel model)
        {
            var modelo = new Modelo
            {
                Nome = model.Nome,
                Cor = model.Cor,
            };

            await _mySQLDbContext.Modelo.AddAsync(modelo);
            await _mySQLDbContext.SaveChangesAsync();

            return Ok("Sucesso.. gravou no banco");
        }

        [HttpGet("ListarTodos")]
        public async Task<IActionResult> ListarTodos()
        {

            var modelo = await _mySQLDbContext.Marca.ToListAsync();

            return Ok(modelo);
        }

        [HttpGet("ListarPorId")]
        public async Task<IActionResult> ListarPorId(int modeloId)
        {
            var modelo = await _mySQLDbContext.Cliente.FirstOrDefaultAsync(p => p.Id == modeloId);

            return Ok(modelo);
        }

        [HttpPut]
        public async Task<IActionResult> Atualizar([FromBody] AtualizarModeloViewModel model)
        {
            var modelo = await _mySQLDbContext.Modelo.FirstOrDefaultAsync(p => p.Id == model.Id);

            if (modelo == null)
            {
                return BadRequest("modelo não encontrado");
            }

            modelo.Nome = model.Nome;
            modelo.Cor = model.Cor;

            _mySQLDbContext.Modelo.Update(modelo);
            await _mySQLDbContext.SaveChangesAsync();

            return Ok("Alterado meu chapa");

        }

        [HttpDelete]
        public async Task<IActionResult> Excluir(int modeloId)
        {
            var modelo = await _mySQLDbContext.Modelo.FirstOrDefaultAsync(p => p.Id == modeloId);

            if (modelo == null)
            {
                return BadRequest("Modelo não encontrado");
            }

            _mySQLDbContext.Remove(modelo);
            await _mySQLDbContext.SaveChangesAsync();

            return NoContent();


        }
    }
}
