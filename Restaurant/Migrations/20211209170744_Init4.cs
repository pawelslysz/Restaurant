using Microsoft.EntityFrameworkCore.Migrations;

namespace Restaurant.Migrations
{
    public partial class Init4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dishes_Categories_CategoryId",
                table: "Dishes");

            migrationBuilder.DropIndex(
                name: "IX_Dishes_CategoryId",
                table: "Dishes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Categories");

            migrationBuilder.AddColumn<string>(
                name: "CategoryName",
                table: "Dishes",
                type: "nvarchar(30)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Dishes_CategoryName",
                table: "Dishes",
                column: "CategoryName");

            migrationBuilder.AddForeignKey(
                name: "FK_Dishes_Categories_CategoryName",
                table: "Dishes",
                column: "CategoryName",
                principalTable: "Categories",
                principalColumn: "Name",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dishes_Categories_CategoryName",
                table: "Dishes");

            migrationBuilder.DropIndex(
                name: "IX_Dishes_CategoryName",
                table: "Dishes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "CategoryName",
                table: "Dishes");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Dishes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Dishes_CategoryId",
                table: "Dishes",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dishes_Categories_CategoryId",
                table: "Dishes",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
