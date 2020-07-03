using Favo_de_mel.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Favo_de_mel.Infrastructure.Data.Mapping
{
    public class CommandaMaping
    {
        public CommandaMaping(EntityTypeBuilder<Comanda> builder)
        {
            builder.ToTable("Comanda");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Mesa)
                .HasColumnName("Mesa")
                .IsRequired();
            
            builder.Property(c => c.Status)
                .HasColumnName("Status")
                .IsRequired();

            builder.Property(c => c.DataAbertura)
                .HasColumnName("DataAbertura")
                .IsRequired();
            
            builder.Property(c => c.DataFechamento)
                .HasColumnName("DataFechamento");

            builder
                .HasMany(c => c.Pedidos)
                .WithOne()
                .HasForeignKey(p => p.ComandaId);
        }
    }
}