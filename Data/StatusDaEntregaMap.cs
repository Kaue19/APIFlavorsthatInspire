using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data
{
    public class StatusDaEntregaMap : IEntityTypeConfiguration<StatusDaEntregaModel>
    {
        public void Configure(EntityTypeBuilder<StatusDaEntregaModel> builder)
        {
            builder.HasKey(x => x.StatusDaEntregaId);
            builder.Property(x => x.UsuarioId).IsRequired();
            builder.Property(x => x.PedidoId).IsRequired();
            builder.Property(x => x.DataSaida).IsRequired();
            builder.Property(x => x.DataEntrega).IsRequired();
        }
    }
}
