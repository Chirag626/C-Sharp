class Practice
{
    public static void Run()
    {
        List<String> name = new List<String>() { "Alice", "Bob", "Charlie", "David" };

        Action nameFilter = () => Console.WriteLine(name.Select(n => n.StartsWith("A")).FirstOrDefault());
        nameFilter(); // Output: "Alice"
        // Console.WriteLine(result); // Output: "Alice"
    }
}
