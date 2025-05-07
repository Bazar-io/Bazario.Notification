using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace Bazario.Notification
{
    public class Functions
    {
        private readonly ILogger _logger;

        public Functions(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<Functions>();
        }

        [Function("Function1")]
        public void Run([RabbitMQTrigger("myqueue", ConnectionStringSetting = "")] string myQueueItem)
        {
            _logger.LogInformation($"C# Queue trigger function processed: {myQueueItem}");
        }
    }
}
