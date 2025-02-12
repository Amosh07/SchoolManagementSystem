using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SMS.Application.Interface.Data;
using SMS.Application.Settings;
using SMS.Domain.Common;
using SMS.Helper;
using SMS.Infrastructure.Persistence;

namespace SMS.Infrastructure.Dependency
{
    public static class InfrastuctureService
    {
        public static IServiceCollection AddInfrastuctureService(this IServiceCollection services, IConfiguration configuration)
        {
            var databaseSettings = new DataBaseSettings();

            configuration.GetSection("DatabaseSettings").Bind(databaseSettings);

            var connectionString = databaseSettings.DbProvider == Constants.DbProviderKey.Npgsql
            ? databaseSettings.NpgSqlConnectionStrings
            : throw new InvalidOperationException("Unsupported database provider.");

            services.AddDbContext<ApplicationsDbContext>(options =>
            {
                options.UseDatabase(databaseSettings.DbProvider, connectionString!);
            });

            services.AddScoped<IApplicationDbContext>(provider =>
                provider.GetService<ApplicationsDbContext>()!);

            services.AddHttpClient();

            services.AddDistributedMemoryCache();

            EnsureDatabaseMigrated(services);

            services.EnableCors(configuration);

            return services;
        }
        private static void EnsureDatabaseMigrated(IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();

            using var scope = serviceProvider.CreateScope();

            var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationsDbContext>();

            dbContext.Database.Migrate();
        }
        private static void EnableCors(this IServiceCollection services, IConfiguration configuration)
        {
            var clientSettings = new ClientSettings();

            configuration.GetSection(nameof(ClientSettings)).Bind(clientSettings);

            var baseUrls = clientSettings.BaseUrl.Split(";");

            foreach (var baseUrl in baseUrls)
            {
                Console.WriteLine($"CORS Allowed Environment: {baseUrl}.");
            }

            services.AddCors(options =>
            {
                options.AddPolicy(name: Constants.Cors.MyAllowSpecificOrigins,
                    builder =>
                    {
                        builder.WithOrigins(baseUrls)
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });
        }
    }
}
