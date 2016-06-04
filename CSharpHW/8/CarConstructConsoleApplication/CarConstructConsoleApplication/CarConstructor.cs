using System;

namespace CarConstructConsoleApplication
{
    public class CarConstructor
    {
        public Car Construct(Engine engine, Color color, Transmission transmission)
        {
            Console.WriteLine("A new car with engine " + engine.Name + ", color " + color.Name + " and transmission " +
                              transmission.TransmissionType + " was constructed.");
            return new Car(engine, color, transmission);
        }

        public void Reconstruct(Car car, Engine engine)
        {
            car.Engine = engine;
            Console.WriteLine("The car engine was changed for " + car.Engine.Name + " with " + car.Engine.CylindrsCount +
                              " cylindrs.");
        }
    }
}
