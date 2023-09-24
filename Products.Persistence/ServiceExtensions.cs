using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Products.Domain.Interfaces;
using Products.Domain.Interfaces.Repositories;
using Products.Persistence.Context;
using Products.Persistence.Repositories;
using Amazon;
using Amazon.SecretsManager;
using Amazon.SecretsManager.Model;
using Newtonsoft.Json;

namespace Products.Persistence
{
    public static class ServiceExtensions
    {
        public static void ConfigurePersistenceApp(this IServiceCollection services, IConfiguration configuration, bool isProduction)
        {
            var connectionString = configuration.GetConnectionString("ProductsDatabase");
            if (isProduction)
            {
                var prodDbCredentials = GetSecret().GetAwaiter().GetResult();
                connectionString = $"Host={prodDbCredentials.Host};Database={prodDbCredentials.Engine};Username={prodDbCredentials.Username};Password={prodDbCredentials.Password}";
            }

            services.AddDbContext<AppDbContext>(opt => opt.UseNpgsql(connectionString, b => b.MigrationsAssembly("Products.WebApi"))
                .UseSnakeCaseNamingConvention());
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IProductRepository, ProductRepository>();
        }

        private static async Task<DbCredentials> GetSecret()
        {
            string secretName = "prod/Product/Database";
            string region = "us-east-1";
            IAmazonSecretsManager client = new AmazonSecretsManagerClient(RegionEndpoint.GetBySystemName(region));
            GetSecretValueRequest request = new GetSecretValueRequest
            {
                SecretId = secretName,
                VersionStage = "AWSCURRENT",
            };

            GetSecretValueResponse response;

            try
            {
                response = await client.GetSecretValueAsync(request);
                return JsonConvert.DeserializeObject<DbCredentials>(response.SecretString);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Não foi possível localizar as secrets {ex.Message}");
                throw;
            }
        }
    }
}
