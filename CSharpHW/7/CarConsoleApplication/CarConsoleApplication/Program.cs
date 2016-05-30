using System;

namespace CarConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var myCar = new Car(){Model = "BMW", Color = "Black", Year = 2015};
            Console.WriteLine("Car properties: Model " + myCar.Model + ", Color " + myCar.Color + ", Year " + myCar.Year);
            Console.WriteLine("It is necessary to repaint the car in red!");
            TuningAtelier.TuneCar(myCar);
            Console.WriteLine("Car properties: Model " + myCar.Model + ", Color " + myCar.Color + ", Year " + myCar.Year);
        }
    }
}
