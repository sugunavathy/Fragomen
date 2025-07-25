using Microsoft.EntityFrameworkCore;

namespace ShopSphere.Models
{
    public class OrderItemDBContext :DbContext
    {
        public OrderItemDBContext(DbContextOptions<OrderItemDBContext> options) : base(options)
        { }
        public DbSet<order_items> order_items { get; set; }
        public DbSet<orders> orders { get; set; }
    }
}
