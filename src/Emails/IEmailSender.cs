namespace Bazario.Notification.Emails
{
    public interface IEmailSender
    {
        Task SendEmailAsync<T>(
            SendEmailRequest<T> request,
            string templateFile);
    }
}
