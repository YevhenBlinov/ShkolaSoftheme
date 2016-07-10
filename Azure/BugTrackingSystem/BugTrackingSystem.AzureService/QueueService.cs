using Microsoft.ServiceBus.Messaging;

namespace BugTrackingSystem.AzureService
{
    public class QueueService
    {
        private const string ConnectionString = "Endpoint=sb://blinov.servicebus.windows.net/;SharedAccessKeyName=ProducerAccessKey;SharedAccessKey=0GwrLQ98xtYfZwDtT66pOqCvz6hTCjM1XjHnZ9J72HA=";

        public void AddMessageToQueue(string messageContent)
        {
            var queueName = "blinovqueue";
            var client = QueueClient.CreateFromConnectionString(ConnectionString, queueName);
            var message = new BrokeredMessage(messageContent);
            client.Send(message);
        }
    }
}
