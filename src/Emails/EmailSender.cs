using FluentEmail.Core;

namespace Bazario.Notification.Emails
{
    public sealed class EmailSender : IEmailSender
    {
        private readonly IFluentEmail _fluentEmail;

        public EmailSender(IFluentEmail fluentEmail)
        {
            _fluentEmail = fluentEmail;
        }

        public async Task SendEmailAsync<T>(
            SendEmailRequest<T> request,
            string templateFile)
        {
            await _fluentEmail
                .To(request.RecipientEmail)
                .Subject(request.Subject)
                .UsingTemplateFromFile(templateFile, request.Model)
                .SendAsync();
        }
    }
}
