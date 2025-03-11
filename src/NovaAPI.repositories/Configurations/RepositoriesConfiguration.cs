using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NovaAPI.Repositories.Contexts;
using NovaAPI.Repositories.Interfaces;
using NovaAPI.Repositories.Repositories;
using NovaAPI.Repositories.Settings;
using System.Globalization;


namespace NovaAPI.Repositories.Configuration
{
    public static class RepositoriesConfiguration
    {
        public static IServiceCollection AddRepositoriesConfiguration(this IServiceCollection services, DatabaseSettings databaseSettings)
        {
            services.AddApplicationRepositories(databaseSettings);

            services.AddScoped<IProductRepository, ProdutoRepository>();


            return services;
        }
        private static IServiceCollection AddApplicationRepositories(this IServiceCollection services, DatabaseSettings databaseSettings)
        {
            services.AddDbContext<NovaAPIDbContext>(options =>
            {
                var connection = new SqliteConnection(databaseSettings.ConnectionStringNovaAPI);
                connection.CreateCollation("LATIN1_GENERAL_CI_AI", (x, y) =>
                {
                    if (x == null && y == null) return 0;
                    if (x == null) return -1;
                    if (y == null) return 1;

                    // Comparação ignorando maiúsculas/minúsculas e acentos
                    return string.Compare(x, y, CultureInfo.CurrentCulture, CompareOptions.IgnoreCase | CompareOptions.IgnoreNonSpace);
                });

                options.UseSqlite(connection);
            });

            return services;
        }
    }
}
