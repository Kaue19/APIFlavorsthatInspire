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
    public class StatusDaEntregaController : ControllerBase
    {
        private readonly IStatusDaEntregaRepositorio _statusdaentregasRepositorio;

        public StatusDaEntregaController(IStatusDaEntregaRepositorio statusdaentregasRepositorio)
        {
            _statusdaentregasRepositorio = statusdaentregasRepositorio;
        }

        [HttpGet("GetAllStatusDaEntrega")]
        public async Task<ActionResult<List<StatusDaEntregaModel>>> GetAllStatusDaEntrega()
        {
            List<StatusDaEntregaModel> statusdaentregas = await _statusdaentregasRepositorio.GetAll();
            return Ok(statusdaentregas);
        }

        [HttpGet("GetStatusDaEntregaId/{id}")]
        public async Task<ActionResult<StatusDaEntregaModel>> GetStatusDaEntregaId(int id)
        {
            StatusDaEntregaModel statusdaentregas = await _statusdaentregasRepositorio.GetById(id);
            return Ok(statusdaentregas);
        }

        [HttpPost("CreateStatusDaEntrega")]
        public async Task<ActionResult<StatusDaEntregaModel>> InsertStatusDaEntrega([FromBody] StatusDaEntregaModel statusdaentregaModel)
        {
            StatusDaEntregaModel statusdaentrega = await _statusdaentregasRepositorio.InsertStatusDaEntrega(statusdaentregaModel);
            return Ok(statusdaentrega);
        }

        [HttpPut("UpdateStatusDaEntrega/{id:int}")]
        public async Task<ActionResult<StatusDaEntregaModel>> UpdateStatusDaEntrega(int id, [FromBody] StatusDaEntregaModel statusdaentregaModel)
        {
            statusdaentregaModel.StatusDaEntregaId = id;
            StatusDaEntregaModel statusdaentrega = await _statusdaentregasRepositorio.UpdateStatusDaEntrega(statusdaentregaModel, id);
            return Ok(statusdaentrega);
        }

        [HttpDelete("DeleteStatusDaEntrega/{id:int}")]
        public async Task<ActionResult<StatusDaEntregaModel>> DeleteStatusDaEntrega(int id)
        {
            bool deleted = await _statusdaentregasRepositorio.DeleteStatusDaEntrega(id);
            return Ok(deleted);
        }

    }
}
