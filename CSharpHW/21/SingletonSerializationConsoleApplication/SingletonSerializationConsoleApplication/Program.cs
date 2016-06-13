using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace SingletonSerializationConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var listOfJournalSingletons = new List<LibraryJournalSingleton>
            {
                LibraryJournalSingleton.GetSingleton(),
                LibraryJournalSingleton.GetSingleton()
            };

            Console.WriteLine("Do both elements refer to the same object? : {0}",
                listOfJournalSingletons[0] == listOfJournalSingletons[1]);

            using (var memoryStream = new MemoryStream())
            {
                var binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(memoryStream, listOfJournalSingletons);
                memoryStream.Position = 0;
                var anotherListOfJournalSingletons = (List<LibraryJournalSingleton>)binaryFormatter.Deserialize(memoryStream);
                Console.WriteLine("Do both elements refer to the same object? : {0}",
                                 (anotherListOfJournalSingletons[0] == anotherListOfJournalSingletons[1]));
                Console.WriteLine("Do all elements refer to the same object? : {0}",
                                 (listOfJournalSingletons[0] == anotherListOfJournalSingletons[0]));
            }            
        }
    }
}
