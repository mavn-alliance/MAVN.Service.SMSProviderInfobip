using JetBrains.Annotations;
using Lykke.Sdk;
using Lykke.Service.SmsProviderInfobip.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Lykke.Service.SmsProviderInfobip
{
    [UsedImplicitly]
    public class Startup
    {
        private readonly LykkeSwaggerOptions _swaggerOptions = new LykkeSwaggerOptions
        {
            ApiTitle = "SmsProviderInfobip API",
            ApiVersion = "v1"
        };

        [UsedImplicitly]
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            return services.BuildServiceProvider<AppSettings>(options =>
            {
                options.SwaggerOptions = _swaggerOptions;

                options.Logs = logs =>
                {
                    logs.AzureTableName = "SmsProviderInfobipLog";
                    logs.AzureTableConnectionStringResolver = settings => settings.SmsProviderInfobipService.Db.LogsConnString;
                };
            });
        }

        [UsedImplicitly]
        public void Configure(IApplicationBuilder app)
        {
            app.UseLykkeConfiguration(options =>
            {
                options.SwaggerOptions = _swaggerOptions;
            });
        }
    }
}
