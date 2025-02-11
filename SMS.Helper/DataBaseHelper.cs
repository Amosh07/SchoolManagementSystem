using Microsoft.EntityFrameworkCore;
using SMS.Domain.Common;

namespace SMS.Helper
{
    public static class DataBaseHelper
    {
        public static DbContextOptionsBuilder UseDatabase(this DbContextOptionsBuilder builder, string dbProvider, string connectionString)
        {
            return dbProvider.ToLowerInvariant() switch
            {
                Constants.DbProviderKey.Npgsql => builder.UseNpgsql(connectionString, e =>
                    e.MigrationsAssembly("CMSTrain.Migrators.PostgreSQL")),
                _ => throw new InvalidOperationException($"DB Provider {dbProvider} is not supported."),
            };
        }
    }
}
