using Microsoft.EntityFrameworkCore.Migrations;

namespace FavoDeMel.Infrastructure.Migrations
{
    public partial class ValorPedido : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Valor",
                table: "Pedido",
                type: "decimal(13, 2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Valor",
                table: "Pedido");
        }
    }
}
