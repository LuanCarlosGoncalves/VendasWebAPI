using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VendasWebAPI.Entities;
using VendasWebAPI.ViewModels;

namespace VendasWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly MySQLDBContext _MySQLDBContext;

        public ClienteController(MySQLDBContext mySQLDBContext)
        {
            _MySQLDBContext = mySQLDBContext;
        }


        [HttpPost]
        public async Task<IActionResult> CadastrarCliente([FromBody] CadastrarClienteViewModel cadastrarClienteViewModel)
        {
            var cliente = new Cliente
            {
                Nome = cadastrarClienteViewModel.Nome,
                Telefone = cadastrarClienteViewModel.Telefone,
                Endereco = cadastrarClienteViewModel.Endereco,

            };

            _MySQLDBContext.Cliente.Add(cliente);
            await _MySQLDBContext.SaveChangesAsync();

            return Ok();

        }

        [HttpPut]
        public async Task<IActionResult> AlterarCliente([FromBody] AlterarClienteViewModel alterarClienteViewModel)
        {
            var cliente = _MySQLDBContext.Cliente.FirstOrDefault(p => p.Id == alterarClienteViewModel.Id);
            if (cliente == null)
            {
                return NotFound("Ciente nao localizado");

            }

            cliente.Nome = alterarClienteViewModel.Nome;
            cliente.Telefone = alterarClienteViewModel.Telefone;
            cliente.Endereco = alterarClienteViewModel.Endereco;

            _MySQLDBContext.Cliente.Update(cliente);
            await _MySQLDBContext.SaveChangesAsync();


            return Ok(cliente);

        }

        [HttpGet]
        public async Task<IActionResult> ListarTodasCliente()
        {
            var cliente = await _MySQLDBContext.Cliente.ToListAsync();

            return Ok(cliente);
        }


        [HttpDelete]
        public async Task<IActionResult> RemoverCliente(int id)
        {
            var cliente = _MySQLDBContext.Cliente.Where(p => p.Id == id).FirstOrDefault();

            if (cliente == null)
            {
                return NotFound("cliente nao encontrado");

            }
            _MySQLDBContext.Cliente.Remove(cliente);
            await _MySQLDBContext.SaveChangesAsync();

            return Ok();
        }
    }
}
     
