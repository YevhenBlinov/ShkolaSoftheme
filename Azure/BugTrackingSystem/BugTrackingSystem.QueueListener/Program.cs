using System.Net;
using System.Net.Mail;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;

namespace BugTrackingSystem.QueueListener
{
    class Program
    {
        private const string MyEmailAdress = "asignartester@gmail.com";
        private const string Password = "zxcvbasdfg";
        private const string Subject = "The bug state was changed";
        private const string ConnectionString = "StorageConnectionString";

        static void Main(string[] args)
        {
            var appSetting = CloudConfigurationManager.GetSetting(ConnectionString);
            var storageAccount = CloudStorageAccount.Parse(appSetting);
            var queueClient = storageAccount.CreateCloudQueueClient();
            var queue = queueClient.GetQueueReference("myqueue");
            queue.CreateIfNotExists();
            Listen(queue);
        }

        public static void Listen(CloudQueue queue)
        {
            while (true)
            {
                var queueMessage = queue.GetMessage();

                if (queueMessage == null)
                    continue;

                var queueMessageInformation = queueMessage.AsString.Split(' ');
                var fromAddress = new MailAddress(MyEmailAdress, "Asignar tester");
                var toAddress = new MailAddress(queueMessageInformation[0]);
                var body = string.Format("The {0} was changed from {1} to {2}", queueMessageInformation[1],
                    queueMessageInformation[2], queueMessageInformation[3]);

                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, Password)
                };

                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = Subject,
                    Body = body
                })
                {
                    smtp.Send(message);
                }

                queue.DeleteMessage(queueMessage);
            }
        }
    }
}
