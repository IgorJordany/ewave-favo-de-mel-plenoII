using Microsoft.EntityFrameworkCore.Migrations;

namespace FavoDeMel.Infrastructure.Migrations
{
    public partial class TotalPagarComanda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "TotalPagar",
                table: "Comanda",
                type: "decimal(13, 2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalPagar",
                table: "Comanda");
        }
    }
}
