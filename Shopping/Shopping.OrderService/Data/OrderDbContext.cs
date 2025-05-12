using Microsoft.EntityFrameworkCore;
using Shopping.Model;

namespace Shopping.OrderService.Data
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Order> Orders { get; set; }

    }
}
