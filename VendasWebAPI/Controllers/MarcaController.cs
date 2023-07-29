using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        public async Task<IActionResult> Cadastrar([FromBody]CadastrarMarcaViewModel model)
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


    }


}
