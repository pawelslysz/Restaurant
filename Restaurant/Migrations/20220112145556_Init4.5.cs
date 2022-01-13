using Microsoft.EntityFrameworkCore.Migrations;

namespace Restaurant.Migrations
{
    public partial class Init45 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsOrdered",
                table: "Orders",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsOrdered",
                table: "Orders");
        }
    }
}
