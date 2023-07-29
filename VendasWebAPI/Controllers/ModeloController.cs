using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    }
}
