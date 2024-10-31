using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data
{
    public class ProdutoMap : IEntityTypeConfiguration<ProdutoModel>
    {
        public void Configure(EntityTypeBuilder<ProdutoModel> builder)
        {
            builder.HasKey(x => x.ProdutoId);
            builder.Property(x => x.ProdutoNome).IsRequired().HasMaxLength(255);
            builder.Property(x => x.ProdutoFoto).IsRequired().HasMaxLength(255);
            builder.Property(x => x.ProdutoDescricao).IsRequired().HasMaxLength(255);
            builder.Property(x => x.ProdutoPreco).IsRequired().HasMaxLength(255);
            builder.Property(x => x.CategoriaId).IsRequired();
            builder.Property(x => x.ProdutoDesconto).IsRequired().HasMaxLength(255);
        }
    }
}
