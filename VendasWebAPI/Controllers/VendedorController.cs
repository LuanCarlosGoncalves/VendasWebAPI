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


        [HttpPut]
        public async Task<IActionResult> Atualizar([FromBody] AtualizarVendedorViewModel model)
        {
            var vendedor = await _mySQLDbContext.Vendedor.FirstOrDefaultAsync(p => p.Id == model.Id);

            if (vendedor == null)
            {
                return BadRequest("vendedor nao existe");
            }

            vendedor.Nome = model.Nome;

            vendedor.Cpf = model.Cpf;

            _mySQLDbContext.Vendedor.Update(vendedor);
            await _mySQLDbContext.SaveChangesAsync();
            return Ok("Alterado chucs");







        }
    }
}