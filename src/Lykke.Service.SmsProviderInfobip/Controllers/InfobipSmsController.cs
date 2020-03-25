using System.Net;
using System.Threading.Tasks;
using Lykke.Service.NotificationSystemBroker.SmsProviderClient;
using Lykke.Service.SmsProviderInfobip.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lykke.Service.SmsProviderInfobip.Controllers
{
    [Route("/api/")]
    [ApiController]
    public class InfobipSmsController : Controller, ISmsProvider
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
