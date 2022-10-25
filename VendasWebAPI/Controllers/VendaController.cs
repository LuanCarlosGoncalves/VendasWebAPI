using Microsoft.AspNetCore.Mvc;
using VendasWebAPI.Entities;
using VendasWebAPI.ViewModels;

namespace VendasWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendaController : ControllerBase
    {
        private readonly MySQLDBContext _mySQLDBContext;
        public VendaController(MySQLDBContext mySQLDBContext)
        {
            _mySQLDBContext = mySQLDBContext;
        }


        [HttpPost]
        public async Task<IActionResult> CadastrarVenda([FromBody] CadastrarVendaViewModel cadastrarVendaViewModel)
        {
            var venda = new Venda
            {
                ClienteId = cadastrarVendaViewModel.ClienteId,
                VendedorId = cadastrarVendaViewModel.VendedorId,
                Data = DateTime.Now
            };

            var itensVendas = new List<ItemVenda>();

            foreach (var item in cadastrarVendaViewModel.ItemVendas)
            {
                var itemVenda = new ItemVenda
                {
                    ProdutoId = item.ProdutoId,
                    Quantidade = item.Quantidade,
                };

                itensVendas.Add(itemVenda);
            }

            venda.ItemVendas = itensVendas;

            _mySQLDBContext.Venda.Add(venda);
            await _mySQLDBContext.SaveChangesAsync();

            return Ok();
        }



    }
}
