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
    public class PedidoProdutoController : ControllerBase
    {
        private readonly IPedidoProdutoRepositorio _pedidoprodutosRepositorio;

        public PedidoProdutoController(IPedidoProdutoRepositorio pedidoprodutosRepositorio)
        {
            _pedidoprodutosRepositorio = pedidoprodutosRepositorio;
        }

        [HttpGet("GetAllPedidoProduto")]
        public async Task<ActionResult<List<PedidoProdutoModel>>> GetAllPedidoProduto()
        {
            List<PedidoProdutoModel> pedidoprodutos = await _pedidoprodutosRepositorio.GetAll();
            return Ok(pedidoprodutos);
        }

        [HttpGet("GetProdutoProdutoId/{id}")]
        public async Task<ActionResult<PedidoProdutoModel>> GetPedidoProdutoId(int id)
        {
            PedidoProdutoModel pedidoproduto = await _pedidoprodutosRepositorio.GetById(id);
            return Ok(pedidoproduto);
        }

        [HttpPost("CreatePedidoProduto")]
        public async Task<ActionResult<PedidoProdutoModel>> InsertPedidoProduto([FromBody] PedidoProdutoModel pedidoprodutoModel)
        {
            PedidoProdutoModel pedidoproduto = await _pedidoprodutosRepositorio.InsertPedidoProduto(pedidoprodutoModel);
            return Ok(pedidoproduto);
        }

        [HttpPut("UpdatePedidoProduto/{id:int}")]
        public async Task<ActionResult<PedidoProdutoModel>> UpdatePedidoProduto(int id, [FromBody] PedidoProdutoModel pedidoprodutoModel)
        {
            pedidoprodutoModel.PedidoProdutoId = id;
            PedidoProdutoModel pedidoproduto = await _pedidoprodutosRepositorio.UpdatePedidoProduto(pedidoprodutoModel, id);
            return Ok(pedidoproduto);
        }

        [HttpDelete("DeletePedidoProduto/{id:int}")]
        public async Task<ActionResult<PedidoProdutoModel>> DeletePedidoProduto(int id)
        {
            bool deleted = await _pedidoprodutosRepositorio.DeletePedidoProduto(id);
            return Ok(deleted);
        }

    }
}
