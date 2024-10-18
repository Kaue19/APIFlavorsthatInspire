using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data
{
    public class PedidoProdutoMap : IEntityTypeConfiguration<PedidoProdutoModel>
    {
        public void Configure(EntityTypeBuilder<PedidoProdutoModel> builder)
        {
            builder.HasKey(x => x.PedidoId);
            builder.Property(x => x.PedidoId).IsRequired();
            builder.Property(x => x.ProdutoId).IsRequired();
        }
    }
}
