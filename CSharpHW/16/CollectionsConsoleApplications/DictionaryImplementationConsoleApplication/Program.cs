namespace DictionaryImplementationConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var dictionary = new Dictionary<string, string>();

            dictionary.Remove("Jan");

            dictionary.Add("Jan", "January");
            dictionary.Add("Feb", "February");
            dictionary.Add("Mar", "March");
            dictionary.Display();

            dictionary.Remove("Apr");
            dictionary.Remove("Feb");
            dictionary.Display();

        }
    }
}
