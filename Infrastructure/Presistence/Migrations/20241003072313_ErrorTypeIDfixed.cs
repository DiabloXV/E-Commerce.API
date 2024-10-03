using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ErrorTypeIDfixed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductTypes_TypedId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "TypedId",
                table: "Products",
                newName: "TypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_TypedId",
                table: "Products",
                newName: "IX_Products_TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductTypes_TypeId",
                table: "Products",
                column: "TypeId",
                principalTable: "ProductTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductTypes_TypeId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "TypeId",
                table: "Products",
                newName: "TypedId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_TypeId",
                table: "Products",
                newName: "IX_Products_TypedId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductTypes_TypedId",
                table: "Products",
                column: "TypedId",
                principalTable: "ProductTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
