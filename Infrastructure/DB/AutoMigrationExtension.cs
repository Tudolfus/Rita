using FluentMigrator.Runner;
using Infrastructure.DB.Migrations;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.DB
{
    public static class AutoMigrationExtension
    {
        public static IServiceCollection LaunchAutoMigration(this IServiceCollection services)
        {
            services
               .AddLogging(c => c.AddFluentMigratorConsole())
               .AddFluentMigratorCore()
               .ConfigureRunner(c => c
                   .AddSqlServer2012()
                   .WithGlobalConnectionString("Persist Security Info = False; Integrated Security = true; Initial Catalog = Rita; server = USER-PC")
                   .ScanIn(typeof(Migration_2021_04_29_22_17).Assembly).For.All()); //проверить

            return services;
        }
    }
}
