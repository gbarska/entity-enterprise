using MvcSalesApp.Domain;
using MvcSalesApp.Data;

namespace MvcSalesApp.Data
{
    public class CustomerRepository : GenericRepository<Customer>
    {
        public CustomerRepository(AppDbContext dbContext): base(dbContext)
        {


        }
    }
}