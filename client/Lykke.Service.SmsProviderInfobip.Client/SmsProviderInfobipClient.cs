using Lykke.HttpClientGenerator;

namespace Lykke.Service.SmsProviderInfobip.Client
{
    /// <summary>
    /// SmsProviderInfobip API aggregating interface.
    /// </summary>
    public class SmsProviderInfobipClient : ISmsProviderInfobipClient
    {
        // Note: Add similar Api properties for each new service controller

        /// <summary>Interface to SmsProviderInfobip Api.</summary>
        public ISmsProviderInfobipApi Api { get; private set; }

        /// <summary>C-tor</summary>
        public SmsProviderInfobipClient(IHttpClientGenerator httpClientGenerator)
        {
            Api = httpClientGenerator.Generate<ISmsProviderInfobipApi>();
        }
    }
}
