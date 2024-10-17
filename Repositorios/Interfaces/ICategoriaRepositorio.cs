using Api.Models;

namespace Api.Repositorios.Interfaces
{
    public interface ICategoriaRepositorio
    {
        Task<List<CategoriaModel>> GetAll();

        Task<CategoriaModel> GetById(int id);

        Task<CategoriaModel> InsertCategoria(CategoriaModel categoria);

        Task<CategoriaModel> UpdateCategoria(CategoriaModel categoria, int id);

        Task<bool> DeleteCategoria(int id);
    }
}
