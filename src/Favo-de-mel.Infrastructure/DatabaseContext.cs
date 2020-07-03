using Favo_de_mel.Core.Entities;
using Favo_de_mel.Infrastructure.Data.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Favo_de_mel.Infrastructure
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Comanda> Comandas { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new CommandaMaping(modelBuilder.Entity<Comanda>());
            new PedidoMaping(modelBuilder.Entity<Pedido>());
        }
    }
}