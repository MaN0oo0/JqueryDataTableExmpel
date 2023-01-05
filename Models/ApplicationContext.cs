using Microsoft.EntityFrameworkCore;

namespace jQueryDataTable.Models
{
    public class ApplicationContext:DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options):base(options)
        {

        }
        public DbSet<Customer>Customers { set; get; }
    }
}
