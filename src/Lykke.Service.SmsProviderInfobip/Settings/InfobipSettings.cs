namespace Lykke.Service.SmsProviderInfobip.Settings
{
    public class InfobipSettings
    {
        // Request timeout in milliseconds
        public int TimeoutMs { get; set; }

        // Number of request reties
        public int Retries { get; set; }

        // Authorization token used to access Infobip
        // (recommended authorization method)
        public string InfobipApiKey { get; set; }

        // FROM number/info for the sms message
        public string FromSender { get; set; }

        // Url to REST API service
        public string ServiceUrl { get; set; }

        // Infobip user for Basic authentication
        // (not recommended because the password is included in every request)
        public string User { get; set; }

        // Infobip password for Basic authentication
        // (not recommended because the password is included in every request)
        public string Password { get; set; }
    }
}
