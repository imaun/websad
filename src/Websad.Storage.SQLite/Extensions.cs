using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Websad.Core.App;
using Websad.Core.Contracts;
using Websad.Core.Utils;
using Websad.Storage.Core;

namespace Websad.Storage.SQLite
{
    public static class Extensions
    {
        public static IServiceCollection AddConfiguredSQLiteDbContext(
            this IServiceCollection services,
            WebsadConfig setting) {
            services.AddEntityFrameworkSqlite(); // It's added to access services from the dbcontext, remove it if you are using the normal `AddDbContext` and normal constructor dependency injection.
            services.AddScoped(serviceProvider =>
                serviceProvider.GetRequiredService<WebsadContext>());

            services.AddDbContextPool<IWebsadContext, SQLiteDbContext>(
                (serviceProvider, optionsBuilder) => optionsBuilder.Configure(setting, serviceProvider));
            return services;
        }

        public static void Configure(
            this DbContextOptionsBuilder optionsBuilder,
            WebsadConfig setting,
            IServiceProvider serviceProvider) {
            var connectionString = setting.GetSQLiteDbConnectionString();
            optionsBuilder.UseSqlite(
                connectionString,
                sqlServerOptionsBuilder => {
                    sqlServerOptionsBuilder
                        .CommandTimeout((int)TimeSpan.FromMinutes(3).TotalSeconds);
                    sqlServerOptionsBuilder
                        .MigrationsAssembly(typeof(Extensions).Assembly.FullName);
                });
            optionsBuilder.UseInternalServiceProvider(serviceProvider); // It's added to access services from the dbcontext, remove it if you are using the normal `AddDbContext` and normal constructor dependency injection.
            //optionsBuilder.AddInterceptors(new PersianDataCommandInterceptor());
            optionsBuilder.ConfigureWarnings(warnings => {
                // ...
            });
        }


        public static string GetSQLiteDbConnectionString(this WebsadConfig setting) {
            if (setting == null) {
                throw new ArgumentNullException(nameof(setting));
            }

            return setting.ConnectionStrings.SQLite.ReplaceDataDirectoryInConnectionString();
        }

        public static string ReplaceDataDirectoryInConnectionString(this string connectionString) {
            return connectionString.Replace("|DataDirectory|", ServerInfo.GetAppDataFolderPath());
        }


    }
}
