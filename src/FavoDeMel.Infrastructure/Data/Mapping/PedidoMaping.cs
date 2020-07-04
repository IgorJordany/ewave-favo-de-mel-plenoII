using FavoDeMel.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FavoDeMel.Infrastructure.Data.Mapping
{
    public class PedidoMaping
    {
        public PedidoMaping(EntityTypeBuilder<Pedido> builder)
        {
            builder.ToTable("Pedido");

            builder.HasKey(c => c.Id);
            
            builder.Property(c => c.ComandaId)
                .HasColumnName("ComandaId")
                .IsRequired();
            
            builder.Property(c => c.Status)
                .HasColumnName("Status")
                .IsRequired();

            builder.Property(c => c.DataCriacao)
                .HasColumnName("DataCriacao")
                .IsRequired();

            builder.Property(c => c.DataCancelamento)
                .HasColumnName("DataCancelamento");
            
            builder.Property(c => c.DataPronto)
                .HasColumnName("DataPronto");
            
            builder.Property(c => c.Quantidade)
                .HasColumnName("Quantidade")
                .IsRequired();
            
            builder.Property(c => c.ItemId)
                .HasColumnName("ItemId")
                .IsRequired();
        }
    }
}