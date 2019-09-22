using Maintenance.Domain;

namespace Maintenance.Data
{
    public class CustomerRepository : GenericRepository<Customer>
    {
        public CustomerRepository(MaintenanceContext dbContext): base(dbContext)
        {

        }
    }
}