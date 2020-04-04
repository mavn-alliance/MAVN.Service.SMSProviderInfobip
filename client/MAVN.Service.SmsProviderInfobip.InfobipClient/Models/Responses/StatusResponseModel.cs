namespace Lykke.Service.SmsProviderInfobip.InfobipClient.Models.Responses
{
    /// <summary>
    /// Model that represents status response
    /// </summary>
    public class StatusResponseModel
    {
        /// <summary>
        /// Status group ID
        /// </summary>
        public int GroupId { get; set; }

        /// <summary>
        /// Status group name
        /// </summary>
        public string GroupName { get; set; }

        /// <summary>
        /// Status ID
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Status name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Human-readable description of the status
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Action that should be taken to eliminate the error
        /// </summary>
        public string Action { get; set; }
    }
}
