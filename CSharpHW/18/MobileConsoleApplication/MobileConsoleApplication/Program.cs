namespace MobileConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstMobile = new MobileAccount("050-001-00-01");
            var secondMobile = new MobileAccount("050-002-00-02");

            firstMobile.SendAMessage(secondMobile);
            secondMobile.MakeACall(firstMobile);
        }
    }
}
