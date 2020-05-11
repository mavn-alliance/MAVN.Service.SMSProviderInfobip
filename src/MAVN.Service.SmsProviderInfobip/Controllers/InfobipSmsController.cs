using System.Net;
using System.Threading.Tasks;
using MAVN.Service.NotificationSystemBroker.SmsProviderClient;
using MAVN.Service.SmsProviderInfobip.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace MAVN.Service.SmsProviderInfobip.Controllers
{
    [Route("/api/")]
    [ApiController]
    public class InfobipSmsController : Controller, ISmsProviderApi
    {
        private readonly ISmsService _smsService;

        public InfobipSmsController(ISmsService smsService)
        {
            _smsService = smsService;
        }

        /// <summary>A method used to send sms</summary>
        /// <param name="model">SMS message request model</param>
        /// <returns>Result with error details in case something happened</returns>
        [HttpPost("sms")]
        [ProducesResponseType(typeof(SmsSenderResult), (int) HttpStatusCode.OK)]
        public async Task<SmsSenderResult> SendSmsAsync(SendSmsRequestModel model)
        {
            return await _smsService.SendSmsAsync(model);
        }
    }
}
