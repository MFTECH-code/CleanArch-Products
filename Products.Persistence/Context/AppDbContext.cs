using Microsoft.EntityFrameworkCore;
using Products.Domain.Entities;

namespace Products.Persistence.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Product> Products { get; set; }
    }
}
