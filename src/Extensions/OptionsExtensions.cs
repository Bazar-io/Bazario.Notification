using Bazario.AspNetCore.Shared.Infrastructure.MessageBroker.Options;
using Bazario.AspNetCore.Shared.Options.DependencyInjection;
using Bazario.Notification.Options;

namespace Bazario.Notification.Extensions
{
    public static class OptionsExtensions
    {
        public static IServiceCollection ConfigureOptions(
            this IServiceCollection services)
        {
            services.ConfigureValidatableOptions<MessageBrokerSettings, MessageBrokerSettingsValidator>(
                MessageBrokerSettings.SectionName);
            services.ConfigureValidatableOptions<SmtpClientSettings, SmtpClientSettingsValidator>(
                SmtpClientSettings.SectionName);

            return services;
        }

        public static IServiceProvider ValidateOptionsOnStart(
            this IServiceProvider serviceProvider)
        {
            serviceProvider.ValidateOptionsOnStart<MessageBrokerSettings>();
            serviceProvider.ValidateOptionsOnStart<SmtpClientSettings>();

            return serviceProvider;
        }
    }
}
