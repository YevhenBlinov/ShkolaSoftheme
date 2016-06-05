using System;
using System.IO;

namespace ResourceHoldersConsoleApplication
{
    public class ResourceHolderDerived : ResourceHolderBase
    {
        private readonly StreamWriter _writerResource;

        public ResourceHolderDerived()
        {
            Console.WriteLine("ResourceHolderDerived's constructor was called. Initializing writer resource.");
            _writerResource = new StreamWriter(@"C:\Users\eugen\Documents\file2.txt");
        }

        ~ResourceHolderDerived()
        {
            Console.WriteLine("ResourceHolderDerived's destructor was called.");
            Dispose(false);
        }

        public override void DoSomeAction()
        {
            Console.WriteLine("I'm doing some action in ResourceHolderDerived.");
        }

        public new void Dispose()
        {
            Console.WriteLine("ResourceHolderDerived's dispose was called.");
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected override void Dispose(bool disposing)
        {
            if (Disposed)
            {
                Console.WriteLine("ResourceHolderDerived has been already disposed.");
                return;
            }

            if (!disposing)
            {
                Console.WriteLine("I'll dispose all resources myself when I want!");
                return;
            }

            if (_writerResource != null)
            {
                _writerResource.Dispose();
                Console.WriteLine("Writer resource was disposed.");
            }

            base.Dispose(disposing);
        }
    }
}
