namespace Bazario.Notification.Emails
{
    public sealed record SendEmailRequest<T>(
        string RecipientEmail,
        string Subject,
        T Model);
}
