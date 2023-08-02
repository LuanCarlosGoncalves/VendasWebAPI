using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VendasWebAPI.DbContextMysql;
using VendasWebAPI.Entidades;
using VendasWebAPI.ViewModels;

namespace VendasWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendedorController : ControllerBase
    {
        public readonly MySQLDbContext _mySQLDbContext;

        public VendedorController(MySQLDbContext mySQLDbContext)
        {
            _mySQLDbContext = mySQLDbContext;
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar([FromBody] CadastrarVendedorViewModel model)
        {
            var vendedor = new Vendedor
            {
                Nome = model.Nome,

                Cpf = model.Cpf,

            };
            await _mySQLDbContext.Vendedor.AddAsync(vendedor);

            await _mySQLDbContext.SaveChangesAsync();
            return Ok("ok thucs");




        }




    }
}
