using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using Microsoft.ServiceBus.Messaging;
using SendGrid;
using System.Net.Http;


namespace BugTrackingSystem.QueueListener
{
    class Program
    {
        private const string MyEmailAdress = "asignartester@gmail.com";
        private const string Password = "zxcvbasdfg";
        private const string Subject = "The bug state was changed";
        private const string ConnectionString = "Endpoint=sb://blinov.servicebus.windows.net/;SharedAccessKeyName=ConsumerAccessKey;SharedAccessKey=7y8L/m9iPfc9V0Xrn18w5pAcTmMBef2GYRCVNTgCxLw=";
        private const string QueueName = "blinovqueue";

        static void Main(string[] args)
        {
            Listen();
        }

        public static void Listen()
        {
            var client = QueueClient.CreateFromConnectionString(ConnectionString, QueueName);

            try
            {
                var shutdownFilePath = Environment.GetEnvironmentVariable("WEBJOBS_SHUTDOWN_FILE");

                if (string.IsNullOrEmpty(shutdownFilePath))
                {
                    throw new InvalidOperationException("WEBJOBS_SHUTDOWN_FILE variable has empty value");
                }

                while (!File.Exists(shutdownFilePath))
                {
                    var message = client.Receive();

                    if (message == null)
                        continue;

                    Console.WriteLine("Processing a new message...");
                    var queueMessage = message.GetBody<string>();
                    var queueMessageInformation = queueMessage.Split(' ');
                    var fromAddress = new MailAddress(MyEmailAdress, "Asignar tester");
                    var body = string.Format("The {0} was changed from {1} to {2}", queueMessageInformation[1],
                        queueMessageInformation[2], queueMessageInformation[3]);

                    var sendgridMessage = new SendGridMessage();
                    sendgridMessage.AddTo(queueMessageInformation[0]);
                    sendgridMessage.From = fromAddress;
                    sendgridMessage.Subject = Subject;
                    sendgridMessage.Text = body;
                    sendgridMessage.EnableTemplateEngine("6c885ea1-d808-40a6-9c32-620b641342ed");

                    var apiKey = "uH8PMtkJSEaBh4nF62VV5Q";
                    var transportWeb = new Web(new NetworkCredential("apikey", apiKey));
                    transportWeb.DeliverAsync(sendgridMessage).Wait();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
