namespace CarConstructConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var carConstructor = new CarConstructor();
            var car = carConstructor.Construct(new Engine("A good one engine", 4), new Color("Black"),
                new Transmission(TransmissionType.FullyAutomatic));
            carConstructor.Reconstruct(car, new Engine("The best engine", 8));
        }
    }
}
