using Autofac;
using Lykke.SettingsReader;
using MAVN.Service.SmsProviderInfobip.Domain.Services;
using MAVN.Service.SmsProviderInfobip.DomainServices.Services;
using MAVN.Service.SmsProviderInfobip.InfobipClient;
using MAVN.Service.SmsProviderInfobip.Settings;

namespace MAVN.Service.SmsProviderInfobip.Modules
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
