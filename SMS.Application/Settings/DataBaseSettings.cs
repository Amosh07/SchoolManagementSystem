using SMS.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace SMS.Application.Settings
{
    public class DataBaseSettings : IValidatableObject
    {
        public string DbProvider { get; set; } 

        public string? NpgSqlConnectionStrings { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty(DbProvider))
            {
                yield return new ValidationResult(
                    $"{nameof(DataBaseSettings)}.{nameof(DbProvider)} is not configured.",
                    new[] { nameof(DbProvider) });
            }

            if (string.IsNullOrEmpty(NpgSqlConnectionStrings))
            {
                yield return new ValidationResult(
                    $"{nameof(DataBaseSettings)}. A valid connection string for {GetDbProviderKey(DbProvider)} is not configured.");
            }
        }
        private static string GetDbProviderKey(string dbProvider)
        {
            return dbProvider switch
            {
                Constants.DbProviderKey.Npgsql => "PostgreSQL"
            };
        }
    }
}
