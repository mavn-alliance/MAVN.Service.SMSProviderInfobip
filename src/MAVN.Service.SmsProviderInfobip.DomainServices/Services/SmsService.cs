using System;
using System.Linq;
using System.Threading.Tasks;
using Common.Log;
using Lykke.Common.Log;
using MAVN.Service.NotificationSystemBroker.SmsProviderClient;
using MAVN.Service.NotificationSystemBroker.SmsProviderClient.Enums;
using MAVN.Service.SmsProviderInfobip.Domain.Services;
using MAVN.Service.SmsProviderInfobip.InfobipClient;
using SendSmsRequestModel = MAVN.Service.SmsProviderInfobip.InfobipClient.Models.Requests.SendSmsRequestModel;

namespace MAVN.Service.SmsProviderInfobip.DomainServices.Services
{
    public class SmsService : ISmsService
    {
        private readonly string _fromSender;
        private readonly IInfobipClient _infobipClient;
        private readonly ILog _log;
        private readonly int _maxNumberOfRetries;

        public SmsService(string fromSender, IInfobipClient infobipClient, ILogFactory logFactory,
            int maxNumberOfRetries)
        {
            _fromSender = fromSender;
            _infobipClient = infobipClient;
            _maxNumberOfRetries = maxNumberOfRetries;
            _log = logFactory.CreateLog(this);
        }

        public async Task<SmsSenderResult> SendSmsAsync(
            NotificationSystemBroker.SmsProviderClient.SendSmsRequestModel model)
        {
            var result = new SmsSenderResult();

            // Try to send SMS via Infobip client and propagate proper audit message
            try
            {
                _log.Info("Sending SMS with Infobip...", new {model.MessageId});

                var response = await TryExecute(() =>
                    _infobipClient.Api.SendSmsAsync(new SendSmsRequestModel
                    {
                        From = _fromSender, Text = model.Message, To = model.PhoneNumber
                    }));

                // Valid statuses that are treated as SMS is sent
                // 0 - OK, 1 - PENDING, 3 - DELIVERED
                var validStatuses = new[] {"OK", "PENDING", "DELIVERED"};
                var responseMessage = response.Messages.First();
                var messageStatus = responseMessage.Status;

                if (validStatuses.All(x =>
                    string.Compare(x, messageStatus.GroupName, StringComparison.InvariantCultureIgnoreCase) != 0))
                {
                    _log.Error(
                        null,
                        "Could not send SMS",
                        new
                        {
                            model.MessageId,
                            InfobipResponse = new {responseMessage.MessageId, responseMessage.Status}
                        });

                    result.Result = SmsResult.Error;
                    result.ErrorMessage = $"{messageStatus.Name} - {messageStatus.Description}";

                    return result;
                }

                result.Result = SmsResult.Ok;

                _log.Info("SMS sent",
                    new {model.MessageId, InfobipResponse = new {responseMessage.MessageId, responseMessage.Status}});
            }
            catch (Exception e)
            {
                _log.Error(e, "Could not send SMS", new {model.MessageId});

                result.Result = SmsResult.Error;
                result.ErrorMessage = e.Message;
            }

            return result;
        }

        private async Task<TR> TryExecute<TR>(Func<Task<TR>> func)
        {
            for (var currentRetry = 1; currentRetry <= _maxNumberOfRetries; currentRetry++)
            {
                try
                {
                    return await func();
                }
                catch (Exception)
                {
                    if (currentRetry == _maxNumberOfRetries)
                        throw;
                }
            }

            return default(TR);
        }
    }
}
