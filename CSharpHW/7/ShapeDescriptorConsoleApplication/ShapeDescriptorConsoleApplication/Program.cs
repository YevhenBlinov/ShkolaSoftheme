using System;

namespace ShapeDescriptorConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Creating a simple quadrangle...");
            var quadrangle = new ShapeDescriptor(new Point(1, 5), new Point(4, 7), new Point(20, 0), new Point(0, 0));
            DisplayShapeInformation(quadrangle);
            Console.WriteLine("Creating an rectangle...");
            var rectangle = new ShapeDescriptor(new Point(0, 4), new Point(6, 4), new Point(6, 0), new Point(0, 0));
            DisplayShapeInformation(rectangle);
            Console.WriteLine("Creating a square...");
            var square = new ShapeDescriptor(new Point(0, 1), new Point(1, 1), new Point(1, 0), new Point(0, 0));
            DisplayShapeInformation(square);
            Console.WriteLine("Creating a simple triangle...");
            var triangle = new ShapeDescriptor(new Point(0, 0), new Point(1, 4), new Point(10, 2));
            DisplayShapeInformation(triangle);
            Console.WriteLine("Creating an isosceles triangle...");
            var isoscelesTriangle = new ShapeDescriptor(new Point(0, 0), new Point(1, 4), new Point(2, 0));
            DisplayShapeInformation(isoscelesTriangle);
            Console.WriteLine("Creating a simple pentagon...");
            var pentagon = new ShapeDescriptor(new Point(1, 5), new Point(4, 7), new Point(13, 7), new Point(20, 0), new Point(0, 0));
            DisplayShapeInformation(pentagon);
        }

        private static void DisplayShapeInformation(ShapeDescriptor shape)
        {
            Console.WriteLine("Created shape with points ");
            foreach (var coordinate in shape.Coordinates)
            {
                Console.Write(coordinate + " ");
            }
            Console.Write("is " + shape.ShapeType);
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
