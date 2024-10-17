using Api.Models;
using Api.Repositorios;
using Api.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaRepositorio _categoriasRepositorio;

        public CategoriaController(ICategoriaRepositorio categoriasRepositorio)
        {
            _categoriasRepositorio = categoriasRepositorio;
        }

        [HttpGet("GetAllCategoria")]
        public async Task<ActionResult<List<CategoriaModel>>> GetAllCategoria()
        {
            List<CategoriaModel> categorias = await _categoriasRepositorio.GetAll();
            return Ok(categorias);
        }

        [HttpGet("GetCategoriaId/{id}")]
        public async Task<ActionResult<CategoriaModel>> GetCategoriaId(int id)
        {
            CategoriaModel categoria = await _categoriasRepositorio.GetById(id);
            return Ok(categoria);
        }

        [HttpPost("CreateCategoria")]
        public async Task<ActionResult<CategoriaModel>> InsertCategoria([FromBody] CategoriaModel categoriaModel)
        {
            CategoriaModel categoria = await _categoriasRepositorio.InsertCategoria(categoriaModel);
            return Ok(categoria);
        }

        [HttpPut("UpdateCategoria/{id:int}")]
        public async Task<ActionResult<CategoriaModel>> UpdateCategoria(int id, [FromBody] CategoriaModel categoriaModel)
        {
            categoriaModel.CategoriaId = id;
            CategoriaModel categoria = await _categoriasRepositorio.UpdateCategoria(categoriaModel, id);
            return Ok(categoria);
        }

        [HttpDelete("DeleteCategoria/{id:int}")]
        public async Task<ActionResult<CategoriaModel>> DeleteCategoria(int id)
        {
            bool deleted = await _categoriasRepositorio.DeleteCategoria(id);
            return Ok(deleted);
        }

    }
}
