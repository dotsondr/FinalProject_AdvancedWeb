using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProject_AdvancedWeb.Migrations
{
    /// <inheritdoc />
    public partial class mig02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ShelfDetailsVMId",
                table: "Product",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ShelfDetailsVM",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShelfName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShelfDetailsVM", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_ShelfDetailsVMId",
                table: "Product",
                column: "ShelfDetailsVMId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_ShelfDetailsVM_ShelfDetailsVMId",
                table: "Product",
                column: "ShelfDetailsVMId",
                principalTable: "ShelfDetailsVM",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_ShelfDetailsVM_ShelfDetailsVMId",
                table: "Product");

            migrationBuilder.DropTable(
                name: "ShelfDetailsVM");

            migrationBuilder.DropIndex(
                name: "IX_Product_ShelfDetailsVMId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ShelfDetailsVMId",
                table: "Product");
        }
    }
}
