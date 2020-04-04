using JetBrains.Annotations;

namespace Lykke.Service.SmsProviderInfobip.Settings
{
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class SmsProviderInfobipSettings
    {
        public DbSettings Db { get; set; }
    }
}
