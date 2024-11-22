using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Data
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {

        }

        public DbSet<CategoriaModel> Categoria { get; set; }
        public DbSet<UsuarioModel> Usuario { get; set; }
        public DbSet<ProdutoModel> Produto { get; set; }
        public DbSet<PedidoModel> Pedido { get; set; }
        public DbSet<PedidoProdutoModel> PedidoProduto { get; set; }
        public DbSet<StatusDaEntregaModel> StatusDaEntrega { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoriaMap());
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new ProdutoMap());
            modelBuilder.ApplyConfiguration(new PedidoMap());
            modelBuilder.ApplyConfiguration(new PedidoProdutoMap());
            modelBuilder.ApplyConfiguration(new StatusDaEntregaMap());
            base.OnModelCreating(modelBuilder);
        }

    }
}
