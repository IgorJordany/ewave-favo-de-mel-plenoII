using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FavoDeMel.Infrastructure.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comanda",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Mesa = table.Column<byte>(nullable: false),
                    Status = table.Column<byte>(nullable: false),
                    DataAbertura = table.Column<DateTime>(nullable: false),
                    DataFechamento = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comanda", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pedido",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ComandaId = table.Column<Guid>(nullable: false),
                    Status = table.Column<byte>(nullable: false),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    DataCancelamento = table.Column<DateTime>(nullable: true),
                    DataPronto = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedido", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pedido_Comanda_ComandaId",
                        column: x => x.ComandaId,
                        principalTable: "Comanda",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_ComandaId",
                table: "Pedido",
                column: "ComandaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pedido");

            migrationBuilder.DropTable(
                name: "Comanda");
        }
    }
}
