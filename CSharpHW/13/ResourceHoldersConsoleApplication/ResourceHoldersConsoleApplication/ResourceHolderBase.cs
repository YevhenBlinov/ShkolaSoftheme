using System;
using System.IO;

namespace ResourceHoldersConsoleApplication
{
    public class ResourceHolderBase : IDisposable
    {
        protected readonly StreamReader ReaderResource;
        protected bool Disposed;

        public ResourceHolderBase()
        {
            Console.WriteLine("ResourceHolderBase's constructor was called. Initializing reader resource.");
            ReaderResource = new StreamReader(@"C:\Users\eugen\Documents\file1.txt");
        }

        ~ResourceHolderBase()
        {
            Console.WriteLine("ResourceHolderBase's destructor was called.");
            Dispose(false);
        }

        public virtual void DoSomeAction()
        {
            Console.WriteLine("I'm doing some action in ResourceHolderBase");
        }

        public void Dispose()
        {
            Console.WriteLine("ResourceHolderBase's dispose was called.");
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (Disposed)
            {
                Console.WriteLine("ResourceHolderBase has been already disposed.");
                return;
            }

            if (!disposing)
            {
                Console.WriteLine("I'll dispose all resources myself when I want!");
                return;
            }

            if (ReaderResource != null)
            {
                ReaderResource.Dispose();
                Console.WriteLine("Reader resource was disposed.");
            }

            Disposed = true;
        }
    }
}
