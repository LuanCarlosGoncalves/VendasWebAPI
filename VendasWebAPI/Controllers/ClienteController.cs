using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VendasWebAPI.DbContextMysql;
using VendasWebAPI.Entidades;
using VendasWebAPI.ViewModels;

namespace VendasWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        public readonly MySQLDbContext _mySQLDbContext;

        public ClienteController(MySQLDbContext mySQLDbContext)
        {
            _mySQLDbContext = mySQLDbContext;
        }

        //[fromBody] -> recebe um json no corpo da requisicao. usado no httpPost
        //[fromQuery] -> passa os parametros na URL Ex: api/Cliente/Cadastrar?nome="lucas"&idade=33. usado no httpGet

        [HttpPost]
        public async Task<IActionResult> Cadastrar([FromBody] CadastrarClienteViewModel model)
        {
            var cliente = new Cliente
            {
                Nome = model.Nome,
                Telefone = model.Telefone,
                Endereco = model.Endereco,
            };

            await _mySQLDbContext.Cliente.AddAsync(cliente);

            return Ok("Sucesso.. gravou no banco");
        }

    }
}
