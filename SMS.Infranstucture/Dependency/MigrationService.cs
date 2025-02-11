using Microsoft.Extensions.DependencyInjection;
using SMS.Infrastructure.Persistence.Seed;

namespace SMS.Infrastructure.Dependency
{
    public static class MigrationService
    {
        public static async Task AddDataSeedMigrationService(this IServiceCollection services)
        {
            await SeedAdmin(services);
        }

        private static async Task SeedAdmin (IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();

            using var scope = serviceProvider.CreateScope();

            var dbInitilizer = scope.ServiceProvider.GetRequiredService<IDbInitilizer>();

            await dbInitilizer.InitializeIdentityData();
        }
    }
}
