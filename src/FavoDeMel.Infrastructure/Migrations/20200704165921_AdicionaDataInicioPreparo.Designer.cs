﻿// <auto-generated />
using System;
using FavoDeMel.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FavoDeMel.Infrastructure.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20200704165921_AdicionaDataInicioPreparo")]
    partial class AdicionaDataInicioPreparo
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FavoDeMel.Core.Entities.Comanda", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataAbertura")
                        .HasColumnName("DataAbertura")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataFechamento")
                        .HasColumnName("DataFechamento")
                        .HasColumnType("datetime2");

                    b.Property<byte>("Mesa")
                        .HasColumnName("Mesa")
                        .HasColumnType("tinyint");

                    b.Property<byte>("Status")
                        .HasColumnName("Status")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.ToTable("Comanda");
                });

            modelBuilder.Entity("FavoDeMel.Core.Entities.Item", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Cozinha")
                        .HasColumnName("Cozinha")
                        .HasColumnType("bit");

                    b.Property<string>("Descricao")
                        .HasColumnName("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Valor")
                        .HasColumnName("Valor")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Item");
                });

            modelBuilder.Entity("FavoDeMel.Core.Entities.Pedido", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ComandaId")
                        .HasColumnName("ComandaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DataCancelamento")
                        .HasColumnName("DataCancelamento")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnName("DataCriacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataInicioPreparo")
                        .HasColumnName("DataInicioPreparo")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataPronto")
                        .HasColumnName("DataPronto")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ItemId")
                        .HasColumnName("ItemId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte>("Quantidade")
                        .HasColumnName("Quantidade")
                        .HasColumnType("tinyint");

                    b.Property<byte>("Status")
                        .HasColumnName("Status")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.HasIndex("ComandaId");

                    b.HasIndex("ItemId");

                    b.ToTable("Pedido");
                });

            modelBuilder.Entity("FavoDeMel.Core.Entities.Pedido", b =>
                {
                    b.HasOne("FavoDeMel.Core.Entities.Comanda", null)
                        .WithMany("Pedidos")
                        .HasForeignKey("ComandaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FavoDeMel.Core.Entities.Item", null)
                        .WithMany("Pedidos")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
