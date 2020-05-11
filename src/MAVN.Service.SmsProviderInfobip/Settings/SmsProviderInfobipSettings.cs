using JetBrains.Annotations;

namespace MAVN.Service.SmsProviderInfobip.Settings
{
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class SmsProviderInfobipSettings
    {
        public DbSettings Db { get; set; }
    }
}
