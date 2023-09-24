using Microsoft.Extensions.DependencyInjection;
using Products.Application.Interfaces.Services;
using Products.Application.Services;
using System.Reflection;

namespace Products.Application
{
    public static class ServiceExtensions
    {
        public static void ConfigureApplicationApp(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<IProductService, ProductService>();
        }
    }
}
