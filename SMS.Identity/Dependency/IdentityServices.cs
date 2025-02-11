using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using SMS.Application.Interface.Data;
using SMS.Application.Settings;
using SMS.Domain.Common;
using SMS.Domain.Entities.Identity;
using SMS.Helper;
using SMS.Identity.Implementation.Manager;
using SMS.Infrastructure.Persistence;
using System.Security.Claims;
using System.Text;

namespace SMS.Identity.Dependency
{
    public static class IdentityServices
    {
        public static IServiceCollection AddIdentityServices (this IServiceCollection services, IConfiguration configuration)
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
            services.Configure<JwtSettings>(configuration.GetSection(nameof(JwtSettings)));
            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationsDbContext>()!);
            services.AddIdentity<User, Role>(options =>
            {
                options.SignIn.RequireConfirmedAccount = true;
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
            }) .AddEntityFrameworkStores<ApplicationsDbContext>()
               .AddDefaultTokenProviders();

            services.AddSingleton<TokenManager>();

            services.Configure<IdentityOptions>(options =>
                options.ClaimsIdentity.UserIdClaimType = ClaimTypes.NameIdentifier);

            services.AddHttpContextAccessor();

            services
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;
                    options.Audience = configuration["JwtSettings:Audience"];
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ClockSkew = TimeSpan.Zero,
                        ValidAudience = configuration["JwtSettings:Audience"],
                        ValidIssuer = configuration["JwtSettings:Issuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"] ?? string.Empty)),
                    };
                });

            services.AddAuthorization();

            return services;

        }
    }
}
