using Microsoft.EntityFrameworkCore.Migrations;

namespace Restaurant.Migrations
{
    public partial class Init43 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dishes_Orders_OrderId",
                table: "Dishes");

            migrationBuilder.DropIndex(
                name: "IX_Dishes_OrderId",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Dishes");

            migrationBuilder.CreateTable(
                name: "OrderDish",
                columns: table => new
                {
                    DishesId = table.Column<int>(type: "int", nullable: false),
                    OrdersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDish", x => new { x.DishesId, x.OrdersId });
                    table.ForeignKey(
                        name: "FK_OrderDish_Dishes_DishesId",
                        column: x => x.DishesId,
                        principalTable: "Dishes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDish_Orders_OrdersId",
                        column: x => x.OrdersId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDish_OrdersId",
                table: "OrderDish",
                column: "OrdersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDish");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "Dishes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dishes_OrderId",
                table: "Dishes",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dishes_Orders_OrderId",
                table: "Dishes",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
