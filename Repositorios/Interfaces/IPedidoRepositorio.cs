using Api.Models;

namespace Api.Repositorios.Interfaces
{
    public interface IPedidoRepositorio
    {
        Task<List<PedidoModel>> GetAll();

        Task<PedidoModel> GetById(int id);

        Task<PedidoModel> InsertPedido(PedidoModel pedido);

        Task<PedidoModel> UpdatePedido(PedidoModel pedido, int id);

        Task<bool> DeletePedido(int id);
    }
}
