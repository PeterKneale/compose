using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Products.Api.Controllers
{
    public class ProductMigrations
    {
        public static void Execute(string connection)
        {
            var serviceProvider = CreateServices(connection);

            using (var scope = serviceProvider.CreateScope())
            {
                UpdateDatabase(scope.ServiceProvider);
            }
        }

        private static IServiceProvider CreateServices(string connection)
        {
            return new ServiceCollection()
                .AddFluentMigratorCore()
                .ConfigureRunner(rb => rb
                    .AddSqlServer()
                    .WithGlobalConnectionString(connection)
                    .ScanIn(typeof(ProductMigration).Assembly).For.Migrations())
                .AddLogging(lb => lb.AddFluentMigratorConsole())
                .BuildServiceProvider(false);
        }

        private static void UpdateDatabase(IServiceProvider serviceProvider)
        {
            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();
            
            runner.MigrateUp();
        }
    }
}
