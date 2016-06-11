using System;

namespace StackImplementationConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var stack = new Stack<int>();

            try
            {
                var popedItem = stack.Pop();               
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine();
            }

            try
            {
                var peekItem = stack.Peek();
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine();
            }

            for (int i = 0; i < 4; i++)
            {
                stack.Push(i+2);
            }
            stack.Display();

            for (int i = 0; i < 4; i++)
            {
                var popedItem = stack.Pop();
                Console.WriteLine("Item {0} was poped from stack.", popedItem);
                stack.Display();              
            }
        }
    }
}
