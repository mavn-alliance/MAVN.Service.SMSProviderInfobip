using JetBrains.Annotations;
using Lykke.Sdk.Settings;

namespace MAVN.Service.SmsProviderInfobip.Settings
{
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class AppSettings : BaseAppSettings
    {
        public SmsProviderInfobipSettings SmsProviderInfobipService { get; set; }

        public InfobipSettings Infobip { get; set; }
    }
}
