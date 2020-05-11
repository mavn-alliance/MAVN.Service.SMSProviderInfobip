using Newtonsoft.Json;

namespace MAVN.Service.SmsProviderInfobip.InfobipClient.Models.Requests
{
    /// <summary>
    /// Model used to send SMS
    /// </summary>
    public class SendSmsRequestModel
    {
        /// <summary>
        /// Represents sender ID and it can be alphanumeric or numeric.
        /// Alphanumeric sender ID length should be between 3 and 11 characters (example: CompanyName).
        /// Numeric sender ID length should be between 3 and 14 characters.
        /// </summary>
        [JsonProperty("from")]
        public string From { get; set; }

        /// <summary>
        /// Destination address. Must be in international format (example: 41793026727).
        /// </summary>
        [JsonProperty("to")]
        public string To { get; set; }

        /// <summary>
        /// Text of the message that will be sent.
        /// </summary>
        [JsonProperty("text")]
        public string Text { get; set; }
    }

}
