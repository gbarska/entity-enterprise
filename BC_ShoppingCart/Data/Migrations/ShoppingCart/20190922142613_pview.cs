using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoppingCart.Data.Migrations.ShoppingCart
{
    public partial class pview : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           migrationBuilder.Sql(@"CREATE VIEW ShoppingCart.ProductListing
                    AS
                    SELECT ProductId, Description, P.Name, P.CategoryID,
                            C.Name as Category, MaxQuantity, CurrentPrice
                    FROM Maintenance.Products P
                    LEFT Join Maintenance.Category C
                    ON P.CategoryId = C.CategoryId
                    WHERE P.IsAvailable = 1"); 
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
              migrationBuilder.Sql(@"DROP VIEW ShoppingCart.ProductListing;"); 
        }
    }
}
