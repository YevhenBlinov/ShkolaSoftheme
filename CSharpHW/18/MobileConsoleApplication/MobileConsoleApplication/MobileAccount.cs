namespace MobileConsoleApplication
{
    public class MobileAccount
    {
        private delegate void MobileAccountOperationsHandler(MobileAccount mobileAccountSender, MobileAccount mobileAccountReceiver);
        private event MobileAccountOperationsHandler SmsEvent;
        private event MobileAccountOperationsHandler CallEvent;

        public string PhoneNumber { get; private set; }

        public MobileAccount(string phoneNumber)
        {
            PhoneNumber = phoneNumber;
            CallEvent += MobileOperator.MakeACallToMobileAccount;
            SmsEvent += MobileOperator.SendAMessageToMobileAccount;
        }

        public void SendAMessage(MobileAccount anotherMobileAccount)
        {
            if (SmsEvent != null)
                SmsEvent(this, anotherMobileAccount);
        }

        public void MakeACall(MobileAccount anotherMobileAccount)
        {
            if(CallEvent != null)
                CallEvent(this, anotherMobileAccount);
        }
    }
}
