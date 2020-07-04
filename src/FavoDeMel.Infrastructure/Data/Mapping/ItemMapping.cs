using FavoDeMel.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FavoDeMel.Infrastructure.Data.Mapping
{
    public class ItemMapping
    {
        public ItemMapping(EntityTypeBuilder<Item> builder)
        {
            builder.ToTable("Item");

            builder.HasKey(i => i.Id);

            builder.Property(i => i.Nome)
                .HasColumnName("Nome")
                .IsRequired();

            builder.Property(i => i.Descricao)
                .HasColumnName("Descricao");

            builder.Property(i => i.Cozinha)
                .HasColumnName("Cozinha")
                .IsRequired();
            
            builder.Property(i => i.Valor)
                .HasColumnName("Valor");

            builder
                .HasMany(i => i.Pedidos)
                .WithOne()
                .HasForeignKey(p => p.ItemId);
        }
    }
}