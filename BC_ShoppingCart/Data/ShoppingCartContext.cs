using SharedKernel.Interfaces;
using ShoppingCart.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

namespace ShoppingCart.Data
{
  public class ShoppingCartContext : DbContext
  {
    public ShoppingCartContext(DbContextOptions<ShoppingCartContext> options) : base(options)
    {
    }

    public ShoppingCartContext()
    {
        
    }

    public DbSet<NewCart> Carts { get; set; }
    public DbSet<CartItem> CartItems { get; set; }
    public static readonly LoggerFactory MyConsoleLoggerFactory
         = new LoggerFactory(new [] {
                new ConsoleLoggerProvider((category, level)
                 => category == DbLoggerCategory.Database.Command.Name 
                 && level == LogLevel.Information, true )});

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
      modelBuilder.HasDefaultSchema("ShoppingCart");
    
      modelBuilder.Entity<NewCart>().HasKey(c => c.CartId);
      //ignore navigation properties that doesn't belong to my data model
      modelBuilder.Ignore<RevisitedCart>();
      modelBuilder.Entity<IStateObject>().Ignore(s=>s.State);

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

  // public class ShoppingCartContextConfig : DbConfiguration
  // {
  //   public ShoppingCartContextConfig() {
  //     this.SetDatabaseInitializer(new NullDatabaseInitializer<ShoppingCartContext>());
  //   }
  // }
}