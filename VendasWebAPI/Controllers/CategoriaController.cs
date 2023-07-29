﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VendasWebAPI.DbContextMysql;
using VendasWebAPI.Entidades;
using VendasWebAPI.ViewModels;

namespace VendasWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        public readonly MySQLDbContext _mySQLDbContext;

        public CategoriaController(MySQLDbContext mySQLDbContext)
        {
            _mySQLDbContext = mySQLDbContext;
        }

        [HttpPost]

        public async Task<IActionResult> Cadastrar([FromBody] CadastrarCategoriaViewModel model)
        {
            var categoria = new Categoria
            {
                Nome = model.Nome,
                Medida = model.Medida,
                Tipo = model.Tipo,

            };

            await _mySQLDbContext.Categoria.AddAsync(categoria);

            await _mySQLDbContext.SaveChangesAsync();
            return Ok("Sucesso.. gravou no banco");

        }




    }
}