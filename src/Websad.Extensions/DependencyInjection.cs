using System;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.DependencyInjection;
using Websad.Api.Security;
using Websad.Api.Utils;
using Websad.Core.App;
using Websad.Storage.SQLite;
using Websad.Services;
using Websad.Services.Contracts;
using Websad.Services.Factories;
using Websad.Core.Contracts;
using Websad.Core.Security;
using Websad.Core.Utils;

namespace Websad.Extensions
{
    public static class DependencyInjection
    {

        private static void AddSecurityServices(this IServiceCollection services) {
            services.AddAuthentication(options => {
                options.DefaultAuthenticateScheme = ApiKeyAuthenticationOptions.DefaultScheme;
                options.DefaultChallengeScheme = ApiKeyAuthenticationOptions.DefaultScheme;
            }).AddApiKeySupport(options => { });
            services.AddScoped<HttpUserInfo>();
        }

        private static void AddDatabaseServices(this IServiceCollection services,
            WebsadConfig setting) {
            services.AddMemoryCache();
            services.AddConfiguredSQLiteDbContext(setting);
        }

        private static void AddApplicationServices(this IServiceCollection services) {
            //factories
            services.AddScoped<ICommentFactory, CommentFactory>();
            services.AddScoped<IPostFactory, PostFactory>();
            services.AddScoped<ICategoryFactory, CategoryFactory>();
            
            //Services
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICategoryService, CategoryService>();

            Services.Extensions.DtoMapExtensions.AddDtoMapping();
        }

        private static void AddUtilityServices(this IServiceCollection services) {
            services.AddScoped<IDateService, DateService>();
            services.AddSingleton<IUserApiKeyGenerator, UserApiKeyGenerator>();
            services.AddScoped<FileUploadHelper>();
        }

        private static WebsadConfig GetAppSetting(this IServiceCollection services) {
            var provider = services.BuildServiceProvider();
            var options = provider.GetRequiredService<IOptionsSnapshot<WebsadConfig>>();
            var appSetting = options.Value;
            if (appSetting == null)
                throw new ArgumentNullException(nameof(appSetting));

            return appSetting;
        }

        /// <summary>
        /// Add required Websad services to App ServiceCollection
        /// </summary>
        /// <param name="services"></param>
        public static void AddWebsadServices(this IServiceCollection services) {
            var appSetting = GetAppSetting(services);
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSecurityServices();
            services.AddDatabaseServices(appSetting);
            services.AddApplicationServices();
            services.AddUtilityServices();
        }
    }
}
