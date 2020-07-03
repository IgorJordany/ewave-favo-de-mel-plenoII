using FavoDeMel.Core.Entities;
using FavoDeMel.Infrastructure.Data.Mapping;
using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;

namespace FavoDeMel.Infrastructure.Data
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
            modelBuilder.Ignore<Notification>();
            
            new CommandaMaping(modelBuilder.Entity<Comanda>());
            new PedidoMaping(modelBuilder.Entity<Pedido>());
        }
    }
}