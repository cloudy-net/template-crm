using Microsoft.EntityFrameworkCore;

namespace CrmApplication.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> dbContextOptions) : base(dbContextOptions) { }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Company> Companies { get; set; }
    }
}
