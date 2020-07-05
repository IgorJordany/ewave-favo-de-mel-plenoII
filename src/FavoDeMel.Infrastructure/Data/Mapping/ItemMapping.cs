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
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder.Property(i => i.Descricao)
                .HasColumnName("Descricao")
                .HasColumnType("varchar(255)");

            builder.Property(i => i.Cozinha)
                .HasColumnName("Cozinha")
                .IsRequired();

            builder.Property(i => i.Valor)
                .HasColumnName("Valor")
                .HasColumnType("decimal(13, 2)");

            builder
                .HasMany(i => i.Pedidos)
                .WithOne()
                .HasForeignKey(p => p.ItemId);
        }
    }
}