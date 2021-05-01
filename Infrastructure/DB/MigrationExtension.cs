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
            //runner.ListMigrations();
            //runner.MigrateUp(202103291851);
            runner.MigrateUp(202104292216);
            runner.MigrateUp(202104292221);
            runner.MigrateUp(202104292225);
            return app;
        }
    }
}