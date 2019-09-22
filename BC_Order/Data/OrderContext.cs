using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Order.Domain;

namespace Order.Data
{
    public class OrderContext : DbContext
    {
        public OrderContext(DbContextOptions<OrderContext> options) : base(options)
        {
        }
        public OrderContext(){}

        public DbSet<SalesOrder> Orders { get; set; }
    
          public static readonly LoggerFactory MyConsoleLoggerFactory
         = new LoggerFactory(new [] {
                new ConsoleLoggerProvider((category, level)
                 => category == DbLoggerCategory.Database.Command.Name 
                 && level == LogLevel.Information, true )});
      

         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Order");
            // modelBuilder.Entity<SalesOrder>.OwnsOne(s=>s.Address);

            modelBuilder.Ignore<Domain.DTOs.Customer>();
            modelBuilder.Ignore<Domain.DTOs.CartItem>();
            
            //value types mapping in EF
             modelBuilder.Entity<SalesOrder>().OwnsOne(s => s.ShippingAddress).ToTable("ShippingAddresses");

            base.OnModelCreating(modelBuilder);
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