using Bazario.AspNetCore.Shared.Abstractions.MessageBroker;
using Bazario.AspNetCore.Shared.Contracts.UserRegistered;
using Bazario.Notification.Emails;
using Bazario.Notification.Models;

namespace Bazario.Notification.Consumers
{
    internal sealed class SendConfirmationEmailRequestedEventConsumer
        : IMessageConsumer<SendConfirmationEmailRequestedEvent>
    {
        private readonly IEmailSender _emailSender;
        private readonly ILogger<SendConfirmationEmailRequestedEventConsumer> _logger;

        public SendConfirmationEmailRequestedEventConsumer(
            IEmailSender emailSender,
            ILogger<SendConfirmationEmailRequestedEventConsumer> logger)
        {
            _emailSender = emailSender;
            _logger = logger;
        }

        public async Task ConsumeAsync(
            SendConfirmationEmailRequestedEvent message,
            CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("Sending confirmation email to {Email}", message.Email);

            var request = new SendEmailRequest<ConfirmEmailModel>(
                message.Email,
                "Email confirmation",
                new ConfirmEmailModel(message.ConfirmationLink));

            await _emailSender.SendEmailAsync(
                request,
                "Templates/ConfirmEmailTemplate.cshtml");
        }
    }
}
