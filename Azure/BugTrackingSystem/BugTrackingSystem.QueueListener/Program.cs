using System;
using System.Net;
using System.Net.Mail;
using Microsoft.ServiceBus.Messaging;

namespace BugTrackingSystem.QueueListener
{
    class Program
    {
        private const string MyEmailAdress = "asignartester@gmail.com";
        private const string Password = "zxcvbasdfg";
        private const string Subject = "The bug state was changed";
        private const string ConnectionString = "Endpoint=sb://blinov.servicebus.windows.net/;SharedAccessKeyName=ConsumerAccessKey;SharedAccessKey=7y8L/m9iPfc9V0Xrn18w5pAcTmMBef2GYRCVNTgCxLw=";

        static void Main(string[] args)
        {
            Listen();
        }

        public static void Listen()
        {
            var queueName = "blinovqueue";
            var client = QueueClient.CreateFromConnectionString(ConnectionString, queueName);

            //var options = new OnMessageOptions();
            //options.AutoComplete = false;
            //options.AutoRenewTimeout = TimeSpan.FromMinutes(1);

            while (true)
            {
                var message = client.Receive();
                
                if(message == null)
                    continue;

                try
                {
                    Console.WriteLine("Processing a new message...");
                    var queueMessage = message.GetBody<string>();
                    var queueMessageInformation = queueMessage.Split(' ');
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

                    using (var mailMessage = new MailMessage(fromAddress, toAddress)
                    {
                        Subject = Subject,
                        Body = body
                    })
                    {
                        smtp.Send(mailMessage);
                    }

                    Console.WriteLine("Email was sent to {0}", queueMessageInformation[0]);
                    message.Complete();
                }
                catch (Exception)
                {
                    message.Abandon();
                }
            }         
        }
    }
}
