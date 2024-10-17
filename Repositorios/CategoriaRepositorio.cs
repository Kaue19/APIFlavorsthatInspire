using Api.Data;
using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Api.Repositorios
{
    public class CategoriaRepositorio : ICategoriaRepositorio
    {
        private readonly Contexto _dbContext;

        public CategoriaRepositorio(Contexto dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<CategoriaModel>> GetAll()
        {
            return await _dbContext.Categoria.ToListAsync();
        }

        public async Task<CategoriaModel> GetById(int id)
        {
            return await _dbContext.Categoria.FirstOrDefaultAsync(x => x.CategoriaId == id);
        }

        public async Task<CategoriaModel> InsertCategoria(CategoriaModel categoria)
        {
            await _dbContext.Categoria.AddAsync(categoria);
            await _dbContext.SaveChangesAsync();
            return categoria;
        }

        public async Task<CategoriaModel> UpdateCategoria(CategoriaModel categoria, int id)
        {
            CategoriaModel categorias = await GetById(id);
            if (categorias == null)
            {
                throw new Exception("Não encontrado.");
            }
            else
            {
                categorias.CategoriaNome = categoria.CategoriaNome;
                _dbContext.Categoria.Update(categorias);
                await _dbContext.SaveChangesAsync();
            }
            return categorias;

        }

        public async Task<bool> DeleteCategoria(int id)
        {
            CategoriaModel categorias = await GetById(id);
            if (categorias == null)
            {
                throw new Exception("Não encontrado.");
            }

            _dbContext.Categoria.Remove(categorias);
            await _dbContext.SaveChangesAsync();
            return true;
        }

    }
}
