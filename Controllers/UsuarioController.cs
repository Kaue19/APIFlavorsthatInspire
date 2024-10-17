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
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepositorio _usuariosRepositorio;

        public UsuarioController(IUsuarioRepositorio usuariosRepositorio)
        {
            _usuariosRepositorio = usuariosRepositorio;
        }

        [HttpGet("GetAllUsuario")]
        public async Task<ActionResult<List<UsuarioModel>>> GetAllUsuario()
        {
            List<UsuarioModel> usuarios = await _usuariosRepositorio.GetAll();
            return Ok(usuarios);
        }

        [HttpGet("GetUsuarioId/{id}")]
        public async Task<ActionResult<UsuarioModel>> GetUsuarioId(int id)
        {
            UsuarioModel usuario = await _usuariosRepositorio.GetById(id);
            return Ok(usuario);
        }

        [HttpPost("CreateUsuario")]
        public async Task<ActionResult<UsuarioModel>> InsertUsuario([FromBody] UsuarioModel usuarioModel)
        {
            UsuarioModel usuario = await _usuariosRepositorio.InsertUsuario(usuarioModel);
            return Ok(usuario);
        }

        [HttpPut("UpdateUsuario/{id:int}")]
        public async Task<ActionResult<CategoriaModel>> UpdateUsuario(int id, [FromBody] UsuarioModel usuarioModel)
        {
            usuarioModel.UsuarioId = id;
            UsuarioModel usuario = await _usuariosRepositorio.UpdateUsuario(usuarioModel, id);
            return Ok(usuario);
        }

        [HttpDelete("DeleteUsuario/{id:int}")]
        public async Task<ActionResult<UsuarioModel>> DeleteUsuario(int id)
        {
            bool deleted = await _usuariosRepositorio.DeleteUsuario(id);
            return Ok(deleted);
        }

    }
}
