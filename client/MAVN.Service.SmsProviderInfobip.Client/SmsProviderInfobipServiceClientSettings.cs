using Lykke.SettingsReader.Attributes;

namespace Lykke.Service.SmsProviderInfobip.Client 
{
    /// <summary>
    /// SmsProviderInfobip client settings.
    /// </summary>
    public class SmsProviderInfobipServiceClientSettings 
    {
        /// <summary>Service url.</summary>
        [HttpCheck("api/isalive")]
        public string ServiceUrl {get; set;}
    }
}
