using System;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace SingletonSerializationConsoleApplication
{
    [Serializable]
    public class LibraryJournalSingleton : ISerializable
    {
        private static readonly LibraryJournalSingleton _libraryJournal = new LibraryJournalSingleton();

        public User LastUser = new User()
        {
            FirstName = "Yevhen",
            LastName = "Blinov",
            Age = 23,
            Email = "Yevhen.blinov@gmail.com"
        };

        public DateTime LastVisitedOn = DateTime.Now;

        private LibraryJournalSingleton()
        {
        }

        public static LibraryJournalSingleton GetSingleton()
        {
            return _libraryJournal;
        }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.SetType(typeof(LibraryJournalSingletonSerializationHelper));
        }

        [Serializable]
        private sealed class LibraryJournalSingletonSerializationHelper : IObjectReference
        {
            public object GetRealObject(StreamingContext context)
            {
                return GetSingleton();
            }
        }
    }
}
