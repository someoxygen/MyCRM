using Microsoft.EntityFrameworkCore;

namespace MyCRM.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Models.User> Users => Set<Models.User>();
        public DbSet<Models.Customer> Customers => Set<Models.Customer>();
        public DbSet<Models.Contact> Contacts => Set<Models.Contact>();
    }
}
