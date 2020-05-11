using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace MAVN.Service.SmsProviderInfobip.InfobipClient.Infrastructure
{
    public class AuthorizationHeaderHttpClientHandler : DelegatingHandler
    {
        private readonly string _infobipApiKey;
        private readonly string _user;
        private readonly string _password;

        /// <inheritdoc />
        public AuthorizationHeaderHttpClientHandler(string infobipApiKey, string user, string password)
        {
            _infobipApiKey = infobipApiKey;
            _user = user;
            _password = password;
        }

        /// <inheritdoc />
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            // Recommended authentication
            if (!string.IsNullOrEmpty(_infobipApiKey))
            {
                request.Headers.TryAddWithoutValidation("Authorization", $"App {_infobipApiKey}");
            }
            // Not recommended authentication
            else if (!string.IsNullOrEmpty(_user) && !string.IsNullOrEmpty(_password))
            {
                var credentials = $"{_user}:{_password}";
                var credentialsEncoded =
                    System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(credentials));

                request.Headers.TryAddWithoutValidation("Authorization", $"Basic {credentialsEncoded}");
            }

            return base.SendAsync(request, cancellationToken);
        }
    }
}
