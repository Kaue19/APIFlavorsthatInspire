using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data
{
    public class PedidoMap : IEntityTypeConfiguration<PedidoModel>
    {
        public void Configure(EntityTypeBuilder<PedidoModel> builder)
        {
            builder.HasKey(x => x.PedidoId);
            builder.Property(x => x.UsuarioId).IsRequired();
            builder.Property(x => x.PrecoPedido).IsRequired().HasMaxLength(255);
        }
    }
}
