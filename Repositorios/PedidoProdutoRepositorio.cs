using Api.Data;
using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Api.Repositorios
{
    public class PedidoProdutoRepositorio : IPedidoProdutoRepositorio
    {
        private readonly Contexto _dbContext;

        public PedidoProdutoRepositorio(Contexto dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<PedidoProdutoModel>> GetAll()
        {
            return await _dbContext.PedidoProduto.ToListAsync();
        }

        public async Task<PedidoProdutoModel> GetById(int id)
        {
            return await _dbContext.PedidoProduto.FirstOrDefaultAsync(x => x.PedidoProdutoId == id);
        }

        public async Task<PedidoProdutoModel> InsertPedidoProduto(PedidoProdutoModel pedidoproduto)
        {
            await _dbContext.PedidoProduto.AddAsync(pedidoproduto);
            await _dbContext.SaveChangesAsync();
            return pedidoproduto;
        }

        public async Task<PedidoProdutoModel> UpdatePedidoProduto(PedidoProdutoModel pedidoproduto, int id)
        {
            PedidoProdutoModel pedidoprodutos = await GetById(id);
            if (pedidoprodutos == null)
            {
                throw new Exception("Não encontrado.");
            }
            else
            {
                pedidoprodutos.PedidoId = pedidoproduto.PedidoProdutoId;
                _dbContext.PedidoProduto.Update(pedidoprodutos);
                await _dbContext.SaveChangesAsync();
            }
            return pedidoprodutos;

        }

        public async Task<bool> DeletePedidoProduto(int id)
        {
            PedidoProdutoModel pedidoprodutos = await GetById(id);
            if (pedidoprodutos == null)
            {
                throw new Exception("Não encontrado.");
            }

            _dbContext.PedidoProduto.Remove(pedidoprodutos);
            await _dbContext.SaveChangesAsync();
            return true;
        }

    }
}
