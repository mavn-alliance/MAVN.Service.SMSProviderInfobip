using Lykke.SettingsReader.Attributes;

namespace Lykke.Service.SmsProviderInfobip.Settings
{
    public class DbSettings
    {
        [AzureTableCheck]
        public string LogsConnString { get; set; }
    }
}
