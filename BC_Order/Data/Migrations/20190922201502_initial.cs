using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Order.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Order");

            migrationBuilder.CreateTable(
                name: "Orders",
                schema: "Order",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    OrderDate = table.Column<DateTime>(nullable: false),
                    DueDate = table.Column<DateTime>(nullable: true),
                    OnlineOrder = table.Column<bool>(nullable: false),
                    PurchaseOrderNumber = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    PromotionId = table.Column<int>(nullable: false),
                    CurrentCustomerStatus = table.Column<int>(nullable: false),
                    CustomerDiscount = table.Column<double>(nullable: false),
                    PromoDiscount = table.Column<double>(nullable: false),
                    SalesOrderNumber = table.Column<string>(nullable: true),
                    CustomerId = table.Column<int>(nullable: false),
                    SubTotal = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LineItem",
                schema: "Order",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    SalesOrderId = table.Column<Guid>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    UnitPrice = table.Column<double>(nullable: true),
                    UnitPriceDiscount = table.Column<double>(nullable: true),
                    ShipmentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LineItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LineItem_Orders_SalesOrderId",
                        column: x => x.SalesOrderId,
                        principalSchema: "Order",
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShippingAddresses",
                schema: "Order",
                columns: table => new
                {
                    SalesOrderId = table.Column<Guid>(nullable: false),
                    Street = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    StateProvince = table.Column<string>(nullable: true),
                    PostalCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShippingAddresses", x => x.SalesOrderId);
                    table.ForeignKey(
                        name: "FK_ShippingAddresses_Orders_SalesOrderId",
                        column: x => x.SalesOrderId,
                        principalSchema: "Order",
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LineItem_SalesOrderId",
                schema: "Order",
                table: "LineItem",
                column: "SalesOrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LineItem",
                schema: "Order");

            migrationBuilder.DropTable(
                name: "ShippingAddresses",
                schema: "Order");

            migrationBuilder.DropTable(
                name: "Orders",
                schema: "Order");
        }
    }
}
