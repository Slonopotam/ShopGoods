using System.Data.Entity;

namespace ShopGoods.Models.Repository
{
    public class EFDbContext : DbContext
    {
        public DbSet<Good> Goods { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}