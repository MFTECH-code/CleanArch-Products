using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Products.Domain.Interfaces;
using Products.Domain.Interfaces.Repositories;
using Products.Persistence.Context;
using Products.Persistence.Repositories;

namespace Products.Persistence
{
    public static class ServiceExtensions
    {
        public static void ConfigurePersistenceApp(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Postgres");
            services.AddDbContext<AppDbContext>(opt => opt.UseNpgsql(connectionString));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IProductRepository, ProductRepository>();
        }
    }
}
