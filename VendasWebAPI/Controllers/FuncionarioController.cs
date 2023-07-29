using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VendasWebAPI.DbContextMysql;
using VendasWebAPI.Entidades;
using VendasWebAPI.ViewModels;

namespace VendasWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        public readonly MySQLDbContext _mySQLDbContext;

        public FuncionarioController(MySQLDbContext mySQLDbContext)
        {
            _mySQLDbContext = mySQLDbContext;
        }


        [HttpPost]

        public async Task<IActionResult> Cadastrar([FromBody] CadastrarFuncionarioViewModel model)
        {
            var funcionario = new Funcionario
            {
                Nome = model.Nome,
                Profissao = model.Profissao


            };

            await _mySQLDbContext.Funcionario.AddAsync(funcionario);
            await _mySQLDbContext.SaveChangesAsync();
            return Ok("salvo");

        }
    }
}
