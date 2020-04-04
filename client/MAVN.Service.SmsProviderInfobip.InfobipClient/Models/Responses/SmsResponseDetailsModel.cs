namespace Lykke.Service.SmsProviderInfobip.InfobipClient.Models.Responses
{
    /// <summary>
    /// Model that represents SMS response details
    /// </summary>
    public class SmsResponseDetailsModel
    {
        /// <summary>
        /// The message destination address.
        /// </summary>
        public string To { get; set; }

        /// <summary>
        /// The ID that uniquely identifies the message sent.
        /// </summary>
        public string MessageId { get; set; }

        /// <summary>
        /// Indicates whether the message is successfully sent, not sent, delivered, not delivered, waiting for delivery or any other possible status.
        /// </summary>
        public StatusResponseModel Status { get; set; }
    }
}
