using Api.Models;

namespace Api.Repositorios.Interfaces
{
    public interface IStatusDaEntregaRepositorio
    {
        Task<List<StatusDaEntregaModel>> GetAll();

        Task<StatusDaEntregaModel> GetById(int id);

        Task<StatusDaEntregaModel> InsertStatusDaEntrega(StatusDaEntregaModel statusdaentrega);

        Task<StatusDaEntregaModel> UpdateStatusDaEntrega(StatusDaEntregaModel statusdaentrega, int id);

        Task<bool> DeleteStatusDaEntrega(int id);
    }
}
