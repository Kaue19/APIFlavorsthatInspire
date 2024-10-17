using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data
{
    public class CategoriaMap : IEntityTypeConfiguration<CategoriaModel>
    {
        public void Configure(EntityTypeBuilder<CategoriaModel> builder)
        {
            builder.HasKey(x => x.CategoriaId);
            builder.Property(x => x.CategoriaNome).IsRequired().HasMaxLength(255);
        }
    }
}
