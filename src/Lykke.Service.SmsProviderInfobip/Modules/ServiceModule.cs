using Autofac;
using Lykke.Service.SmsProviderInfobip.Domain.Services;
using Lykke.Service.SmsProviderInfobip.DomainServices.Services;
using Lykke.Service.SmsProviderInfobip.InfobipClient;
using Lykke.Service.SmsProviderInfobip.Settings;
using Lykke.SettingsReader;

namespace Lykke.Service.SmsProviderInfobip.Modules
{
    public class ServiceModule : Module
    {
        private readonly IReloadingManager<AppSettings> _appSettings;

        public ServiceModule(IReloadingManager<AppSettings> appSettings)
        {
            _appSettings = appSettings;
        }

        protected override void Load(ContainerBuilder builder)
        {
            // Services
            builder.RegisterType<SmsService>()
                .As<ISmsService>()
                .SingleInstance()
                .WithParameter("fromSender", _appSettings.CurrentValue.Infobip.FromSender)
                .WithParameter("maxNumberOfRetries", _appSettings.CurrentValue.Infobip.Retries);

            // Clients
            builder.RegisterType<InfobipClient.InfobipClient>()
                .As<IInfobipClient>()
                .SingleInstance()
                .WithParameter("serviceUrl", _appSettings.CurrentValue.Infobip.ServiceUrl)
                .WithParameter("retries", _appSettings.CurrentValue.Infobip.Retries)
                .WithParameter("timeoutMs", _appSettings.CurrentValue.Infobip.TimeoutMs)
                .WithParameter("infobipApiKey", _appSettings.CurrentValue.Infobip.InfobipApiKey)
                .WithParameter("user", _appSettings.CurrentValue.Infobip.User)
                .WithParameter("password", _appSettings.CurrentValue.Infobip.Password);
        }
    }
}
