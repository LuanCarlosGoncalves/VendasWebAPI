using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VendasWebAPI.Entities;
using VendasWebAPI.ViewModels;

namespace VendasWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendedorController : ControllerBase
    {
        private readonly MySQLDBContext _MySQLDBContext;

        public VendedorController(MySQLDBContext mySQLDBContext)
        {
            _MySQLDBContext = mySQLDBContext;
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarVendedor([FromBody] CadastrarVendedorViewModel cadastrarvendedorViewModel)
        {
            var vendedor = new Vendedor
            {
                Nome = cadastrarvendedorViewModel.Nome,
                Telefone = cadastrarvendedorViewModel.Telefone,
                CPF = cadastrarvendedorViewModel.CPF,
               DataNascimento = cadastrarvendedorViewModel.DataNascimento,
            };

            _MySQLDBContext.Vendedor.Add(vendedor);
            await _MySQLDBContext.SaveChangesAsync();

            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> AlterarVendedor([FromBody]AlterarVendedorViewmodel alterarVendedorViewmodel) 
        {
            var vendedor = _MySQLDBContext.Vendedor.FirstOrDefault(p => p.Id == alterarVendedorViewmodel.Id);
            
            if (vendedor == null)
            {
             return NotFound("Vendedor não encontrado");
            }

            vendedor.Nome = alterarVendedorViewmodel.Nome;  
            vendedor.Telefone = alterarVendedorViewmodel.Telefone;
            vendedor.CPF = alterarVendedorViewmodel.CPF;    
            vendedor.DataNascimento = alterarVendedorViewmodel.DataNascimento;    

            _MySQLDBContext.Vendedor.Update(vendedor);
            await _MySQLDBContext.SaveChangesAsync();


            return Ok(vendedor);
        }
        [HttpGet]
        public async Task<IActionResult> ListarTodasVendedor()
        {
            var vendedor = await _MySQLDBContext.Vendedor.ToListAsync();

            return Ok(vendedor);
        }
       
        
        [HttpDelete]
        public async Task<IActionResult> RemoverVendedor(int id)
        {
            var vendedor = _MySQLDBContext.Vendedor.Where(p => p.Id == id).FirstOrDefault();    

            if (vendedor == null)
            {
                return NotFound("vendedor nao localizado");

            }

            _MySQLDBContext.Vendedor.Remove(vendedor);
            await _MySQLDBContext.SaveChangesAsync();


            return Ok();


        }

    }
}
