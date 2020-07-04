using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FavoDeMel.Infrastructure.Migrations
{
    public partial class AdicionaDataInicioPreparo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataInicioPreparo",
                table: "Pedido",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataInicioPreparo",
                table: "Pedido");
        }
    }
}
