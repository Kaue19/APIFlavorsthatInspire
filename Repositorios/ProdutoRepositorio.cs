using Api.Data;
using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Api.Repositorios
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        private readonly Contexto _dbContext;

        public ProdutoRepositorio(Contexto dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ProdutoModel>> GetAll()
        {
            return await _dbContext.Produto.ToListAsync();
        }

        public async Task<ProdutoModel> GetById(int id)
        {
            return await _dbContext.Produto.FirstOrDefaultAsync(x => x.ProdutoId == id);
        }

        public async Task<ProdutoModel> InsertProduto(ProdutoModel produto)
        {
            await _dbContext.Produto.AddAsync(produto);
            await _dbContext.SaveChangesAsync();
            return produto;
        }

        public async Task<ProdutoModel> UpdateProduto(ProdutoModel produto, int id)
        {
            ProdutoModel produtos = await GetById(id);
            if (produtos == null)
            {
                throw new Exception("Não encontrado.");
            }
            else
            {
                produtos.ProdutoNome = produto.ProdutoNome;
                produtos.ProdutoDescricao = produto.ProdutoDescricao;
                produtos.ProdutoPreco = produto.ProdutoPreco;
                produtos.CategoriaId = produto.CategoriaId;
                produtos.ProdutoDesconto = produto.ProdutoDesconto;
                _dbContext.Produto.Update(produtos);
                await _dbContext.SaveChangesAsync();
            }
            return produtos;

        }

        public async Task<bool> DeleteProduto(int id)
        {
            ProdutoModel produtos = await GetById(id);
            if (produtos == null)
            {
                throw new Exception("Não encontrado.");
            }

            _dbContext.Produto.Remove(produtos);
            await _dbContext.SaveChangesAsync();
            return true;
        }

    }
}
