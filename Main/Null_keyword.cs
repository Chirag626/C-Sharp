using System;

class Null_keyword
{
    public  static void Run()
    {
        // null means variable has no value (points to nothing)

        string? name = null; // ? means this string can be null

        Console.WriteLine("Checking null example:");

        // check if variable is null
        if (name == null)
        {
            Console.WriteLine("Name is null");
        }

        // null coalescing operator ??
        // if left side is null then right value is used
        string displayName = name ?? "Default User";

        Console.WriteLine("Display Name: " + displayName);

        // null conditional operator ?.
        string? text = null;

        int? length = text?.Length; // this will be null if text is null, otherwise it will give length
        
        // if text is null it will not throw error
        Console.WriteLine("Length: " + length);
    }
}