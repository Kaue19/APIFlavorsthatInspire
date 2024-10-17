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
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoRepositorio _produtosRepositorio;

        public ProdutoController(IProdutoRepositorio produtosRepositorio)
        {
            _produtosRepositorio = produtosRepositorio;
        }

        [HttpGet("GetAllProduto")]
        public async Task<ActionResult<List<ProdutoModel>>> GetAllProduto()
        {
            List<ProdutoModel> produtos = await _produtosRepositorio.GetAll();
            return Ok(produtos);
        }

        [HttpGet("GetProdutoId/{id}")]
        public async Task<ActionResult<ProdutoModel>> GetProdutoId(int id)
        {
            ProdutoModel produto = await _produtosRepositorio.GetById(id);
            return Ok(produto);
        }

        [HttpPost("CreateProduto")]
        public async Task<ActionResult<ProdutoModel>> InsertProduto([FromBody] ProdutoModel produtoModel)
        {
            ProdutoModel produto = await _produtosRepositorio.InsertProduto(produtoModel);
            return Ok(produto);
        }

        [HttpPut("UpdateProduto/{id:int}")]
        public async Task<ActionResult<ProdutoModel>> UpdateProduto(int id, [FromBody] ProdutoModel produtoModel)
        {
            produtoModel.ProdutoId = id;
            ProdutoModel produto = await _produtosRepositorio.UpdateProduto(produtoModel, id);
            return Ok(produto);
        }

        [HttpDelete("DeleteProduto/{id:int}")]
        public async Task<ActionResult<ProdutoModel>> DeleteProduto(int id)
        {
            bool deleted = await _produtosRepositorio.DeleteProduto(id);
            return Ok(deleted);
        }

    }
}
