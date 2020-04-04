using System;
using FluentValidation;
using Lykke.Service.NotificationSystemBroker.SmsProviderClient;

namespace Lykke.Service.SmsProviderInfobip.Validation
{
    public class SendSmsRequestModelValidator : AbstractValidator<SendSmsRequestModel>
    {
        public SendSmsRequestModelValidator()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.MessageId)
                .NotNull()
                .NotEmpty()
                .NotEqual(Guid.Empty)
                .WithMessage("Message Id cannot be empty");

            RuleFor(x => x.PhoneNumber)
                .NotNull()
                .NotEmpty()
                .WithMessage("Phone Number cannot be empty")
                .Length(3, 50);

            RuleFor(x => x.Message)
                .NotNull()
                .NotEmpty()
                .WithMessage("Message cannot be empty")
                .Length(1, 10000);
        }
    }
}
