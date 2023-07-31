using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Meu_Projeto.Migrations
{
    /// <inheritdoc />
    public partial class AddCategoryEdit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EditeddBy",
                table: "Products",
                newName: "EditedBy");

            migrationBuilder.RenameColumn(
                name: "EditeddBy",
                table: "Categories",
                newName: "EditedBy");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EditedBy",
                table: "Products",
                newName: "EditeddBy");

            migrationBuilder.RenameColumn(
                name: "EditedBy",
                table: "Categories",
                newName: "EditeddBy");
        }
    }
}
