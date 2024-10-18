using Api.Data;
using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Api.Repositorios
{
    public class StatusDaEntregaRepositorio : IStatusDaEntregaRepositorio
    {
        private readonly Contexto _dbContext;

        public StatusDaEntregaRepositorio(Contexto dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<StatusDaEntregaModel>> GetAll()
        {
            return await _dbContext.StatusDaEntrega.ToListAsync();
        }

        public async Task<StatusDaEntregaModel> GetById(int id)
        {
            return await _dbContext.StatusDaEntrega.FirstOrDefaultAsync(x => x.StatusDaEntregaId == id);
        }

        public async Task<StatusDaEntregaModel> InsertStatusDaEntrega(StatusDaEntregaModel statusdaentrega)
        {
            await _dbContext.StatusDaEntrega.AddAsync(statusdaentrega);
            await _dbContext.SaveChangesAsync();
            return statusdaentrega;
        }

        public async Task<StatusDaEntregaModel> UpdateStatusDaEntrega(StatusDaEntregaModel statusdaentrega, int id)
        {
            StatusDaEntregaModel statusdaentregas = await GetById(id);
            if (statusdaentregas == null)
            {
                throw new Exception("Não encontrado.");
            }
            else
            {
                statusdaentregas.StatusDaEntregaId = statusdaentrega.StatusDaEntregaId;
                _dbContext.StatusDaEntrega.Update(statusdaentregas);
                await _dbContext.SaveChangesAsync();
            }
            return statusdaentregas;

        }

        public async Task<bool> DeleteStatusDaEntrega(int id)
        {
            StatusDaEntregaModel statusdaentregas = await GetById(id);
            if (statusdaentregas == null)
            {
                throw new Exception("Não encontrado.");
            }

            _dbContext.StatusDaEntrega.Remove(statusdaentregas);
            await _dbContext.SaveChangesAsync();
            return true;
        }

    }
}
