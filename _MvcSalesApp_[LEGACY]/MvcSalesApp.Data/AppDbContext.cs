using Microsoft.EntityFrameworkCore;
using MvcSalesApp.Domain;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

namespace MvcSalesApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public AppDbContext(){}

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<NewCart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }

          public static readonly LoggerFactory MyConsoleLoggerFactory
         = new LoggerFactory(new [] {
                new ConsoleLoggerProvider((category, level)
                 => category == DbLoggerCategory.Database.Command.Name 
                 && level == LogLevel.Information, true )});
      

         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NewCart>().HasKey(c => c.CartId);
            modelBuilder.Ignore<RevisitedCart>();
            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {            
                //  var connString = "Server=localhost;Port=3306;Database=mvcsales;Uid=gbarska;Pwd=password;";
               
                 builder
                .UseLoggerFactory(MyConsoleLoggerFactory)
                // .UseMySql(connString)
                .EnableSensitiveDataLogging(true);
            
        }
        public override int SaveChanges()
        {
        
            return base.SaveChanges();
            
        }
       
    }
}