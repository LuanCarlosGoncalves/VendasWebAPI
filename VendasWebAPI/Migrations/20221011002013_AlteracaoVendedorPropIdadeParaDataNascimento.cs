using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VendasWebAPI.Migrations
{
    public partial class AlteracaoVendedorPropIdadeParaDataNascimento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CPF",
                table: "Vendedor",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataNascimento",
                table: "Vendedor",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Vendedor",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CPF",
                table: "Vendedor");

            migrationBuilder.DropColumn(
                name: "DataNascimento",
                table: "Vendedor");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Vendedor");
        }
    }
}
