using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;

namespace BugTrackingSystem.AzureService
{
    public class QueueService
    {
        private const string ConnectionString = "StorageConnectionString";
        private CloudStorageAccount _storageAccount;
        private CloudQueueClient _queueClient;
        private CloudQueue _queue;

        public QueueService()
        {
            var appSetting = CloudConfigurationManager.GetSetting(ConnectionString);
            _storageAccount = CloudStorageAccount.Parse(appSetting);
            _queueClient = _storageAccount.CreateCloudQueueClient();
            _queue = _queueClient.GetQueueReference("myqueue");
            _queue.CreateIfNotExists();
        }

        public void AddMessageToQueue(string messageContent)
        {
            var messageToAdd = new CloudQueueMessage(messageContent);
            _queue.AddMessage(messageToAdd);
        }
    }
}
