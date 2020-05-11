using System.Collections.Generic;

namespace MAVN.Service.SmsProviderInfobip.InfobipClient.Models.Responses
{
    /// <summary>
    /// Model that represents SMS response
    /// </summary>
    public class SmsResponseModel
    {
        /// <summary>
        /// The ID that uniquely identifies the request.
        /// Bulk ID will be received only when you send a message to more than one destination address.
        /// </summary>
        public string BulkId { get; set; }

        /// <summary>
        /// Array of sent message objects, one object per every message.
        /// </summary>
        public List<SmsResponseDetailsModel> Messages { get; set; }
    }
}
