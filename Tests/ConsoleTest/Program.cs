internal class Program
{
    private static void Main(string[] args)
    {
        Dictionary<string, string> dictionary = new Dictionary<string, string>()
        {
            {"ru", "Русский" },
            {"en", "Английский" },
            {"zh", "Китайский" },
            {"fr", "Французский" }
        };

        var keys = dictionary.Keys;
        var values = dictionary.Values;

        Console.WriteLine(string.Join("\n", keys));
        Console.WriteLine(string.Join("\n", values));
    }
}