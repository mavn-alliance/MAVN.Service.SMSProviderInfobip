using System;
using Lykke.HttpClientGenerator.Infrastructure;
using Lykke.HttpClientGenerator.Retries;
using Lykke.Service.SmsProviderInfobip.InfobipClient.Infrastructure;

namespace Lykke.Service.SmsProviderInfobip.InfobipClient
{
    /// <summary>
    /// Infobip API client
    /// </summary>
    public class InfobipClient : IInfobipClient
    {
        /// <summary>
        /// Infobip service provider URL
        /// </summary>
        public string ServiceUrl { get; }

        /// <summary>
        /// Infobip service connection timeout in milliseconds
        /// </summary>
        public int TimeoutMs { get; }

        /// <summary>
        /// Number of retries that are made before request fails
        /// </summary>
        public int Retries { get; }

        /// <summary>
        /// Access token that will be used for authentication with API
        /// </summary>
        public string InfobipApiKey { get; }

        /// <summary>
        /// Infobip user for Basic authentication
        /// (not recommended because the password is included in every request)
        /// </summary>
        public string User { get; }

        /// <summary>
        /// Infobip password for Basic authentication
        /// (not recommended because the password is included in every request)
        /// </summary>
        public string Password { get; }

        /// <summary>
        /// API interface to deal with Infobip
        /// </summary>
        public IInfobip Api { get; private set; }

        /// <summary>
        /// Infobip client constructor
        /// </summary>
        /// <param name="serviceUrl">Url of the Infobip service</param>
        /// <param name="timeoutMs">Client timeout in milliseconds</param>
        /// <param name="retries">Number of retries per request that should be executed before request fails</param>
        /// <param name="infobipApiKey">API key token that will be used for authentication (recommended)</param>
        /// <param name="user">Infobip user that will be used for Basic authentication (not recommended)</param>
        /// <param name="password">Infobip password that will be used for Basic authentication (not recommended)</param>
        public InfobipClient(string serviceUrl, int timeoutMs, int retries, string infobipApiKey, string user,
            string password)
        {
            ServiceUrl = serviceUrl;
            TimeoutMs = timeoutMs;
            Retries = retries;
            InfobipApiKey = infobipApiKey;
            User = user;
            Password = password;

            InitializeClient();
        }

        private void InitializeClient()
        {
            var clientBuilder = HttpClientGenerator.HttpClientGenerator.BuildForUrl(ServiceUrl)
                .WithAdditionalCallsWrapper(new ExceptionHandlerCallsWrapper())
                .WithoutRetries()
                .WithAdditionalDelegatingHandler(
                    new AuthorizationHeaderHttpClientHandler(InfobipApiKey, User, Password));

            Api = clientBuilder.Create().Generate<IInfobip>();
        }
    }
}
