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
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoRepositorio _pedidosRepositorio;

        public PedidoController(IPedidoRepositorio pedidosRepositorio)
        {
            _pedidosRepositorio = pedidosRepositorio;
        }

        [HttpGet("GetAllPedido")]
        public async Task<ActionResult<List<PedidoModel>>> GetAllPedido()
        {
            List<PedidoModel> pedidos = await _pedidosRepositorio.GetAll();
            return Ok(pedidos);
        }

        [HttpGet("GetProdutoId/{id}")]
        public async Task<ActionResult<PedidoModel>> GetPedidoId(int id)
        {
            PedidoModel pedido = await _pedidosRepositorio.GetById(id);
            return Ok(pedido);
        }

        [HttpPost("CreatePedido")]
        public async Task<ActionResult<PedidoModel>> InsertPedido([FromBody] PedidoModel pedidoModel)
        {
            PedidoModel pedido = await _pedidosRepositorio.InsertPedido(pedidoModel);
            return Ok(pedido);
        }

        [HttpPut("UpdatePedido/{id:int}")]
        public async Task<ActionResult<ProdutoModel>> UpdatePedido(int id, [FromBody] PedidoModel pedidoModel)
        {
            pedidoModel.PedidoId = id;
            PedidoModel pedido = await _pedidosRepositorio.UpdatePedido(pedidoModel, id);
            return Ok(pedido);
        }

        [HttpDelete("DeleteProduto/{id:int}")]
        public async Task<ActionResult<PedidoModel>> DeletePedido(int id)
        {
            bool deleted = await _pedidosRepositorio.DeletePedido(id);
            return Ok(deleted);
        }

    }
}
