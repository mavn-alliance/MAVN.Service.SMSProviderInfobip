using Lykke.SettingsReader.Attributes;

namespace MAVN.Service.SmsProviderInfobip.Client
{
    /// <summary>
    /// SmsProviderInfobip client settings.
    /// </summary>
    public class SmsProviderInfobipServiceClientSettings
    {
        /// <summary>Service url.</summary>
        [HttpCheck("api/isalive")]
        public string ServiceUrl { get; set; }
    }
}
