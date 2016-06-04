namespace CarConstructConsoleApplication
{
    public class Car
    {
        public Engine Engine { get; set; }
        public Color Color { get; private set; }
        public Transmission Transmission { get; private set; }

        public Car(Engine engine, Color color, Transmission transmission)
        {
            Engine = engine;
            Color = color;
            Transmission = transmission;
        }
    }
}
