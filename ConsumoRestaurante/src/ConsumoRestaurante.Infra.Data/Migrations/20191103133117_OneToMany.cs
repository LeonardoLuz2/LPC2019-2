using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsumoRestaurante.Infra.Data.Migrations
{
    public partial class OneToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consumos_Restaurantes_RestauranteId",
                table: "Consumos");

            migrationBuilder.AddColumn<Guid>(
                name: "ConsumoId",
                table: "Restaurantes",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "RestauranteId",
                table: "Consumos",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Consumos_Restaurantes_RestauranteId",
                table: "Consumos",
                column: "RestauranteId",
                principalTable: "Restaurantes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consumos_Restaurantes_RestauranteId",
                table: "Consumos");

            migrationBuilder.DropColumn(
                name: "ConsumoId",
                table: "Restaurantes");

            migrationBuilder.AlterColumn<Guid>(
                name: "RestauranteId",
                table: "Consumos",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddForeignKey(
                name: "FK_Consumos_Restaurantes_RestauranteId",
                table: "Consumos",
                column: "RestauranteId",
                principalTable: "Restaurantes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
