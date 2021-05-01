using FluentMigrator.Runner;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.DB
{
    public static class MigrationExtension
    {
        public static IApplicationBuilder Migrate(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var runner = scope.ServiceProvider.GetService<IMigrationRunner>();

            runner.MigrateUp(202104292222);
            runner.MigrateUp(202105012221);
            runner.MigrateUp(202105012223);
            runner.MigrateUp(202105020028);

            return app;
        }
    }
}