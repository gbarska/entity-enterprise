using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Order.Write.Domain;
using Order.Write.Domain.DTOs;

namespace Order.Read.Data
{
    public class OrderReadContext: DbContext
    {
      public OrderContext(DbContextOptions<OrderContext> options) : base(options)
        {
        }
        public OrderContext(){}
      public DbSet<SalesOrder> Orders { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder) {
      modelBuilder.HasDefaultSchema("Order");
   }

     protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {            
                 var connString = "Server=localhost;Port=3306;Database=salesrefac;Uid=gbarska;Pwd=password;";
               
                 builder
                .UseLoggerFactory(MyConsoleLoggerFactory)
                 .UseMySql(connString)
                .EnableSensitiveDataLogging(true);
            
        }
        public override int SaveChanges()
        {
        
            return base.SaveChanges();
            
        }
  }
}
