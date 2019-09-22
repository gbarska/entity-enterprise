using ShoppingCart.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

namespace ShoppingCart.Data
{
  public class ReferenceContext : DbContext
  {
    public ReferenceContext(DbContextOptions<ReferenceContext> options) : base(options)
    {
    }

    public ReferenceContext()
    { 
    }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Product> Products { get; set; }

     public static readonly LoggerFactory MyConsoleLoggerFactory
         = new LoggerFactory(new [] {
                new ConsoleLoggerProvider((category, level)
                 => category == DbLoggerCategory.Database.Command.Name 
                 && level == LogLevel.Information, true )});

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
      
      modelBuilder.HasDefaultSchema("Maintenance");
      modelBuilder.Entity<Product>().ToTable("ProductListing","ShoppingCart");
      //need a view:
      //  CREATE VIEW ShoppingCart.ProductListing
      //  AS
      //    SELECT ProductId, Description, P.Name, P.CategoryID,
      //           C.Name as Category, MaxQuantity, CurrentPrice
      //    FROM Maintenance.Products P
      //    LEFT Join Maintenance.Categories C
      //    ON P.CategoryId = C.CategoryId
      //    WHERE p.IsAvailable = 1

      base.OnModelCreating(modelBuilder);
    }

     protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {            
                 var connString = "Server=localhost;Port=3306;Database=salesrefac;Uid=gbarska;Pwd=password;";
               
                 builder
                .UseLoggerFactory(MyConsoleLoggerFactory)
                //  .UseMySql(connString)
                .EnableSensitiveDataLogging(true);
            
        }
        public override int SaveChanges()
        {
        
            return base.SaveChanges();
            
        }
  }
}