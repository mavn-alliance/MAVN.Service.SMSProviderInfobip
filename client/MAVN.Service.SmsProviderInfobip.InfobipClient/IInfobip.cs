using System.Threading.Tasks;
using MAVN.Service.SmsProviderInfobip.InfobipClient.Models.Requests;
using MAVN.Service.SmsProviderInfobip.InfobipClient.Models.Responses;
using Refit;

namespace MAVN.Service.SmsProviderInfobip.InfobipClient
{
    /// <summary>
    /// Interface that describes Infobip SMS client access
    /// </summary>
    public interface IInfobip
    {
        /// <summary>
        /// Infobip endpoint that is used to send SMS
        /// </summary>
        /// <param name="requestModel">SMS data</param>
        /// <returns></returns>
        [Post("/sms/2/text/single")]
        Task<SmsResponseModel> SendSmsAsync([Body] SendSmsRequestModel requestModel);
    }
}
