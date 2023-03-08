using Microsoft.EntityFrameworkCore;

namespace CrmApplication.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> dbContextOptions) : base(dbContextOptions) { }
        public DbSet<Person> Customers { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Opportunity> Opportunities { get; set; }
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
