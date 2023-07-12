using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VendasWebAPI.Entities;
using VendasWebAPI.ViewModels;

namespace VendasWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly MySQLDBContext _mySQLDBContext;

        public ProdutoController(MySQLDBContext mySQLDBContext)
        {
            _mySQLDBContext = mySQLDBContext;
        }


        [HttpPost]
        public async Task<IActionResult> CadastrarProduto([FromBody] CadastrarProdutoViewModel cadastrarProdutoViewModel)
        {
            var produto = new Produto
            {
                Nome = cadastrarProdutoViewModel.Nome,
                Quantidade = cadastrarProdutoViewModel.Quantidade,
                Valor = cadastrarProdutoViewModel.Valor,
                Cor = cadastrarProdutoViewModel.Cor,
                MarcaId = 1,
                CategoriaId = 1
            };

            _mySQLDBContext.Produto.Add(produto);
            await _mySQLDBContext.SaveChangesAsync();

            return Ok();
        }


        [HttpPut]
        public async Task<IActionResult> AlterarProduto([FromBody] AlterarProdutoViewModel alterarProdutoViewModel)
        {
            var produto = _mySQLDBContext.Produto.FirstOrDefault(p => p.Id == alterarProdutoViewModel.Id);

            if (produto == null)
            {
                return NotFound("produto nao foi localizado");
            }

            produto.Nome = alterarProdutoViewModel.Nome;
            produto.Valor = alterarProdutoViewModel.Valor;
            produto.Quantidade = alterarProdutoViewModel.Quantidade;
            produto.Cor = alterarProdutoViewModel.Cor;

            _mySQLDBContext.Produto.Update(produto);
            await _mySQLDBContext.SaveChangesAsync();

            return Ok(produto);
        }


        [HttpGet]
        public async Task<IActionResult> ListarTodosProduto()
        {
            var produtos = await _mySQLDBContext.Produto.ToListAsync();

            return Ok(produtos);
        }


        [HttpGet("ListarProdutosPorId")]
        public async Task<IActionResult> ListarProdutosPorId(int id)
        {
            var produto = _mySQLDBContext.Produto.FirstOrDefault(p => p.Id == id);

            if (produto == null)
            {
                return NotFound("produto nao foi localizado");
            }

            return Ok(produto);
        }


        [HttpDelete]
        public async Task<IActionResult> RemoverProduto(int id)
        {
            var produto = _mySQLDBContext.Produto.Where(p => p.Id == id).FirstOrDefault();

            if (produto == null)
            {
                return NotFound("produto nao foi localizado");
            }

            _mySQLDBContext.Produto.Remove(produto);
            await _mySQLDBContext.SaveChangesAsync();

            return Ok();
        }
    }
}
