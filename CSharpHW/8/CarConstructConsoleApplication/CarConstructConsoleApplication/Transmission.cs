namespace CarConstructConsoleApplication
{
    public class Transmission
    {
        public TransmissionType TransmissionType { get; private set; }

        public Transmission(TransmissionType transmissionType)
        {
            TransmissionType = transmissionType;
        }
    }
}
