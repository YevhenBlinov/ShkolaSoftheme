using System;

namespace ResourceHoldersConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var resourceHolderBase = new ResourceHolderBase())
            {
                resourceHolderBase.DoSomeAction();
            }
            Console.WriteLine();

            using (var resourceHolderDerived = new ResourceHolderDerived())
            {
                resourceHolderDerived.DoSomeAction();
            }

            Console.WriteLine();

            var anotherResourceHolderBase = new ResourceHolderBase();
            anotherResourceHolderBase.Dispose();
            anotherResourceHolderBase.Dispose();

            Console.WriteLine();

            var anotherResourceHolderDerived = new ResourceHolderDerived();
            anotherResourceHolderDerived.Dispose();
            anotherResourceHolderDerived.Dispose();

            Console.WriteLine();
            var oneMoreAnotherResourceHolderBase = new ResourceHolderBase();
            oneMoreAnotherResourceHolderBase = null;
            var oneMoreAnotherResourceHolderDerived = new ResourceHolderDerived();
            oneMoreAnotherResourceHolderDerived = null;
            GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
            GC.WaitForPendingFinalizers();
        }
    }
}
