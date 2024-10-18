using Api.Models;

namespace Api.Repositorios.Interfaces
{
    public interface IPedidoProdutoRepositorio
    {
        Task<List<PedidoProdutoModel>> GetAll();

        Task<PedidoProdutoModel> GetById(int id);

        Task<PedidoProdutoModel> InsertPedidoProduto(PedidoProdutoModel pedidoproduto);

        Task<PedidoProdutoModel> UpdatePedidoProduto(PedidoProdutoModel pedidoproduto, int id);

        Task<bool> DeletePedidoProduto(int id);
    }
}
