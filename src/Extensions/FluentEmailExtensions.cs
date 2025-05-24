using Bazario.AspNetCore.Shared.Options;
using Bazario.Notification.Options;
using System.Net;
using System.Net.Mail;

namespace Bazario.Notification.Extensions
{
    public static class FluentEmailExtensions
    {
        public static IServiceCollection AddFluentEmailSender(
            this IServiceCollection services)
        {
            var settings = services.BuildServiceProvider().GetOptions<SmtpClientSettings>();

            var client = new SmtpClient(settings.Host, settings.Port)
            {
                Credentials = new NetworkCredential(
                    settings.Username,
                    settings.Password),
                EnableSsl = settings.EnableSsl
            };

            services
                .AddFluentEmail(settings.Username)
                .AddSmtpSender(client)
                .AddRazorRenderer();

            return services;
        }
    }
}
