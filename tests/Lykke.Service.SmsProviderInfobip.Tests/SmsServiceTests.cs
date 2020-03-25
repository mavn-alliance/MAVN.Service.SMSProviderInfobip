using System.Threading.Tasks;
using AutoFixture;
using Lykke.Logs;
using Lykke.Service.SmsProviderInfobip.DomainServices.Services;
using Lykke.Service.SmsProviderInfobip.InfobipClient;
using Lykke.Service.SmsProviderInfobip.InfobipClient.Models.Responses;
using Moq;
using Xunit;
using SendSmsRequestModel = Lykke.Service.SmsProviderInfobip.InfobipClient.Models.Requests.SendSmsRequestModel;

namespace Lykke.Service.SmsProviderInfobip.Tests
{
    public class SmsServiceTests
    {
        private readonly Fixture _fixture = new Fixture();

        private readonly Mock<IInfobipClient> _infobipClientMock = new Mock<IInfobipClient>();
        private readonly SmsService _service;

        public SmsServiceTests()
        {
            _service = new SmsService("", _infobipClientMock.Object, EmptyLogFactory.Instance, 1);
        }

        [Fact]
        public async Task When_Send_Sms_Async_Is_Executed_Expect_That_Infobip_Client_Send_Sms_Async_Is_Called()
        {
            _infobipClientMock.Setup(x => x.Api.SendSmsAsync(It.IsAny<SendSmsRequestModel>()))
                .Returns(Task.FromResult(_fixture.Build<SmsResponseModel>().Create()));

            await _service.SendSmsAsync(_fixture.Build<NotificationSystemBroker.SmsProviderClient.SendSmsRequestModel>()
                .Create());

            _infobipClientMock.Verify(x => x.Api.SendSmsAsync(It.IsAny<SendSmsRequestModel>()), Times.Once);
        }
    }
}
