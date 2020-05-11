using Lykke.SettingsReader.Attributes;

namespace MAVN.Service.SmsProviderInfobip.Settings
{
    public class DbSettings
    {
        [AzureTableCheck]
        public string LogsConnString { get; set; }
    }
}
