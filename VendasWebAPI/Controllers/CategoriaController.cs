using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VendasWebAPI.Entities;
using VendasWebAPI.ViewModels;

namespace VendasWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly MySQLDBContext _mySQLDBContext;

        public CategoriaController(MySQLDBContext mySQLDBContext)
        {
            _mySQLDBContext = mySQLDBContext;
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarCategoria([FromBody] CadastrarCategoriaViewModel cadastrarcategoriaViewModel)
        {
            var categoria = new Categoria
            {
                Nome = cadastrarcategoriaViewModel.Nome,

            };

            _mySQLDBContext.Categoria.Add(categoria);
            await _mySQLDBContext.SaveChangesAsync();

            return Ok(categoria);
        }
        [HttpPut]
        public async Task<IActionResult> AlterarCategoria([FromBody] AlterarCategoriaViewModel alterarcategoriaViewModel)
        {
            var categoria = _mySQLDBContext.Categoria.FirstOrDefault(p => p.Id == alterarcategoriaViewModel.Id);
            
            if (categoria == null)
            {
                return NotFound("Categoria não foi encontrada");
            }

            categoria.Nome= alterarcategoriaViewModel.Nome;

            _mySQLDBContext.Categoria.Update(categoria);
            await _mySQLDBContext.SaveChangesAsync();
            


            return Ok(categoria);
        }
       
        
        
        [HttpGet]
        public async Task<IActionResult> ListarTodasCategoriaPorId(int id)
        {
            var categoria = _mySQLDBContext.Categoria.FirstOrDefault(p => p.Id == id);

            if (categoria == null)
            {
                return NotFound("categoria nao localizada");

            }

            return Ok(categoria);        
        }

       
        
        [HttpGet("ListarCattegoriaPorId")]
        public async Task<IActionResult> ListarTodasCategoria()
        {
            var categoria = await _mySQLDBContext.Categoria.ToListAsync();

            return Ok(categoria);
        }
       
        [HttpDelete]
        public async Task<IActionResult> RemoverCategoria(int id)
        {
            var categoria = _mySQLDBContext.Categoria.Where(p => p.Id == id).FirstOrDefault();

            if (categoria == null)
            {
                return NotFound("Categoria nao localizado");
            }
            
                
                return Ok(categoria);


        }
        }
    }
