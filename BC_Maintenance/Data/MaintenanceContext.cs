using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Maintenance.Domain;

namespace Maintenance.Data
{
    public class MaintenanceContext : DbContext
    {
        public MaintenanceContext(DbContextOptions<MaintenanceContext> options) : base(options)
        {
        }
        public MaintenanceContext(){}

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
    
          public static readonly LoggerFactory MyConsoleLoggerFactory
         = new LoggerFactory(new [] {
                new ConsoleLoggerProvider((category, level)
                 => category == DbLoggerCategory.Database.Command.Name 
                 && level == LogLevel.Information, true )});
      

         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Maintenance");
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