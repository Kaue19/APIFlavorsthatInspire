using Api.Data;
using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Api.Repositorios
{
    public class PedidoRepositorio : IPedidoRepositorio
    {
        private readonly Contexto _dbContext;

        public PedidoRepositorio(Contexto dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<PedidoModel>> GetAll()
        {
            return await _dbContext.Pedido.ToListAsync();
        }

        public async Task<PedidoModel> GetById(int id)
        {
            return await _dbContext.Pedido.FirstOrDefaultAsync(x => x.PedidoId == id);
        }

        public async Task<PedidoModel> InsertPedido(PedidoModel pedido)
        {
            await _dbContext.Pedido.AddAsync(pedido);
            await _dbContext.SaveChangesAsync();
            return pedido;
        }

        public async Task<PedidoModel> UpdatePedido(PedidoModel pedido, int id)
        {
            PedidoModel pedidos = await GetById(id);
            if (pedidos == null)
            {
                throw new Exception("Não encontrado.");
            }
            else
            {
                pedidos.PedidoId = pedido.PedidoId;
                _dbContext.Pedido.Update(pedidos);
                await _dbContext.SaveChangesAsync();
            }
            return pedidos;

        }

        public async Task<bool> DeletePedido(int id)
        {
            PedidoModel pedidos = await GetById(id);
            if (pedidos == null)
            {
                throw new Exception("Não encontrado.");
            }

            _dbContext.Pedido.Remove(pedidos);
            await _dbContext.SaveChangesAsync();
            return true;
        }

    }
}
