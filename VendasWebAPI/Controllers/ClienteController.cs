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
                Profissao = model.Profissao,
            };

            await _mySQLDbContext.Cliente.AddAsync(cliente);
            
            await _mySQLDbContext.SaveChangesAsync();
            return Ok("Sucesso.. gravou no banco");
        }


        [HttpPut]
        public async Task<IActionResult> Atualizar([FromBody] AtualizarClienteViewModel model)
        {
            var cliente = await _mySQLDbContext.Cliente.FirstOrDefaultAsync(p => p.Id == model.Id);

            if (cliente == null) 
            {
                return BadRequest("cliente não localizado");
            }

            cliente.Nome = model.Nome;
            cliente.Telefone = model.Telefone;
            cliente.Endereco = model.Endereco;
            cliente.Profissao = model.Profissao;

            _mySQLDbContext.Cliente.Update(cliente);
            await _mySQLDbContext.SaveChangesAsync();
            return Ok("Alterado com sucesso.....");
        }
    }
}
