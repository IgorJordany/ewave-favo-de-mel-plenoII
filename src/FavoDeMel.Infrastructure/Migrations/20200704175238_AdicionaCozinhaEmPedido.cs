using Microsoft.EntityFrameworkCore.Migrations;

namespace FavoDeMel.Infrastructure.Migrations
{
    public partial class AdicionaCozinhaEmPedido : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Cozinha",
                table: "Pedido",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cozinha",
                table: "Pedido");
        }
    }
}
