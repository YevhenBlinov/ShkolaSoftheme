using System;
using System.Collections.Generic;

namespace MobileConsoleApplication
{
    public class MobileOperator
    {   
        public static void SendAMessageToMobileAccount(MobileAccount mobileAccountSender, MobileAccount mobileAccountReceiver)
        {
            Console.WriteLine("The SMS was sent from {0} to {1}.", mobileAccountSender.PhoneNumber, mobileAccountReceiver.PhoneNumber);
        }

        public static void MakeACallToMobileAccount(MobileAccount mobileAccountSender, MobileAccount mobileAccountReceiver)
        {
            Console.WriteLine("The call from {0} to {1} was maded.", mobileAccountSender.PhoneNumber, mobileAccountReceiver.PhoneNumber);
        }      
    }
}
