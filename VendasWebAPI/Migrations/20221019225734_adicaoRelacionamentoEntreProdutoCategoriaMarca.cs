using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VendasWebAPI.Migrations
{
    public partial class adicaoRelacionamentoEntreProdutoCategoriaMarca : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Produto_CategoriaId",
                table: "Produto",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_MarcaId",
                table: "Produto",
                column: "MarcaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produto_Categoria_CategoriaId",
                table: "Produto",
                column: "CategoriaId",
                principalTable: "Categoria",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Produto_Marca_MarcaId",
                table: "Produto",
                column: "MarcaId",
                principalTable: "Marca",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produto_Categoria_CategoriaId",
                table: "Produto");

            migrationBuilder.DropForeignKey(
                name: "FK_Produto_Marca_MarcaId",
                table: "Produto");

            migrationBuilder.DropIndex(
                name: "IX_Produto_CategoriaId",
                table: "Produto");

            migrationBuilder.DropIndex(
                name: "IX_Produto_MarcaId",
                table: "Produto");
        }
    }
}
