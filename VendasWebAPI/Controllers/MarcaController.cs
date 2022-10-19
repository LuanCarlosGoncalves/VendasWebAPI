using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VendasWebAPI.Entities;
using VendasWebAPI.ViewModels;

namespace VendasWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcaController : ControllerBase
    {
        private readonly MySQLDBContext _mySQLDBContext;
        public MarcaController(MySQLDBContext mySQLDBContext)
        {
            _mySQLDBContext = mySQLDBContext;
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarMarca([FromBody] CadastrarMarcaViewModel cadastrarMarcaViewModel)
        {
            var marca = new Marca
            {
                Nome = cadastrarMarcaViewModel.Nome
            };
            _mySQLDBContext.Marca.Add(marca);
            await _mySQLDBContext.SaveChangesAsync();

            return Ok(marca);
        }


        [HttpPut]
        public async Task<IActionResult> AlterarMarca([FromBody] AlterarMarcaViewModel alterarMarcaViewModel)
        {
            var marca = _mySQLDBContext.Marca.FirstOrDefault(p => p.Id == alterarMarcaViewModel.Id);

            if (marca == null)
            {
                return NotFound("Marca nao foi localizado");
            }

            marca.Nome = alterarMarcaViewModel.Nome;

            _mySQLDBContext.Marca.Update(marca);
            await _mySQLDBContext.SaveChangesAsync();

            return Ok(marca);


        }


        [HttpGet]
        public async Task<IActionResult> ListarMarca()
        {
            var marcas = await _mySQLDBContext.Marca.ToListAsync();

            return Ok(marcas);

        }

        [HttpGet("ListarMarcaPorId")]
        public async Task<IActionResult> ListarMarcaPorId(int id)
        {
            var Marca = _mySQLDBContext.Marca.FirstOrDefault(m => m.Id == id);

            if (Marca == null)
            {
                return NotFound("Marca nao foi localizada");
            }

            return Ok(Marca);   

        }

        [HttpDelete]
        public async Task<IActionResult> RemoverMarca(int id)
        {
            var Marca = _mySQLDBContext.Marca.Where(m => m.Id == id).FirstOrDefault();

            if (Marca == null)
            
            {
                return NotFound("Marca nao foi localizada");
            }


            _mySQLDBContext.Marca.Remove(Marca);
            await _mySQLDBContext.SaveChangesAsync();

              return Ok();


        }










    }
}
