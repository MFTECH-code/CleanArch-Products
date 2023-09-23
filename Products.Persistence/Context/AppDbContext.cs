using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Products.Domain.Entities;

namespace Products.Persistence.Context
{
    public class AppDbContext : DbContext
    {
        private IConfiguration _configuration;

        public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
         => optionsBuilder.UseNpgsql(_configuration.GetConnectionString("Postgres"))
            .UseSnakeCaseNamingConvention();
    }
}
