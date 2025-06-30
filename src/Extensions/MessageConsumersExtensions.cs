using Bazario.AspNetCore.Shared.Contracts.UserRegistered;
using Bazario.AspNetCore.Shared.Infrastructure.MessageBroker.DependencyInjection;
using Bazario.Notification.Consumers;

namespace Bazario.Notification.Extensions
{
    public static class MessageConsumersExtensions
    {
        public static IServiceCollection AddMessageConsumers(
            this IServiceCollection services)
        {
            services.AddMessageConsumer<
                SendConfirmationEmailRequestedEvent,
                SendConfirmationEmailRequestedEventConsumer>();

            return services;
        }
    }
}
