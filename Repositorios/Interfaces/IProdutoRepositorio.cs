using Api.Models;

namespace Api.Repositorios.Interfaces
{
    public interface IProdutoRepositorio
    {
        Task<List<ProdutoModel>> GetAll();

        Task<ProdutoModel> GetById(int id);

        Task<ProdutoModel> InsertProduto(ProdutoModel produto);

        Task<ProdutoModel> UpdateProduto(ProdutoModel produto, int id);

        Task<bool> DeleteProduto(int id);
    }
}
