namespace CarConstructConsoleApplication
{
    public class Engine
    {
        public string Name { get; private set; }
        private readonly int _cylindrsCount;
        public int CylindrsCount 
        {
            get { return _cylindrsCount; } 
        }

        public Engine(string name, int cylindrsCount)
        {
            Name = name;
            _cylindrsCount = cylindrsCount;
        }
    }
}
