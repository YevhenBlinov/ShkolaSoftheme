﻿using System;

namespace GenericIteratorConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new GenericAggregate<string>();

            a[0] = "Item A";
            a[1] = "Item B";
            a[2] = "Item C";
            a[3] = "Item D";

            var i = new GenericIterator<string>(a);

            Console.WriteLine("Iterating over collection:");

            var item = i.First();
            while (item != null)
            {
                Console.WriteLine(item);
                item = i.Next();
            }
        }
    }
}
