#pragma warning disable
using System;
class StringMethods {
    public static void Run() {

        // ─────────────────────────────────────────
        // 1. BASIC PROPERTIES
        // ─────────────────────────────────────────
        string s = "  Hello, World!  ";
    

        Console.WriteLine("=== BASIC PROPERTIES ===");
        Console.WriteLine("Length: " + s.Length);          // 17 (includes spaces)
        Console.WriteLine("accessing char at index 2 : " + s[2]);              // ' ' (first char)


        // ─────────────────────────────────────────
        // 2. CASE CONVERSION
        // ─────────────────────────────────────────
        Console.WriteLine("\n=== CASE CONVERSION ===");
        Console.WriteLine(s.ToUpper());       //   HELLO, WORLD!  
        Console.WriteLine(s.ToLower());       //   hello, world!  


        // ─────────────────────────────────────────
        // 3. TRIMMING
        // ─────────────────────────────────────────
        Console.WriteLine("\n=== TRIMMING ==="); // remove leading/trailing spaces
        Console.WriteLine(s.Trim());          // "Hello, World!"
        Console.WriteLine(s.TrimStart());     // "Hello, World!  "
        Console.WriteLine(s.TrimEnd());       // "  Hello, World!"


        // ─────────────────────────────────────────
        // 4. CONTAINS / STARTS / ENDS
        // ─────────────────────────────────────────
        string t = "Hello, World!";

        Console.WriteLine("\n=== CONTAINS / STARTS / ENDS ===");
        Console.WriteLine(t.Contains("World"));      // True
        Console.WriteLine(t.StartsWith("Hello"));    // True
        Console.WriteLine(t.EndsWith("!"));          // True


        // ─────────────────────────────────────────
        // 5. INDEX / SEARCH
        // ─────────────────────────────────────────
        Console.WriteLine("\n=== INDEX / SEARCH ==="); // find position of substring
        Console.WriteLine(t.IndexOf("World"));       // 7 index of first occurrence
        Console.WriteLine(t.LastIndexOf("l"));       // 10 index of last occurrence
        // Returns -1 if not found
        Console.WriteLine(t.IndexOf("xyz"));         // -1


        // ─────────────────────────────────────────
        // 6. SUBSTRING
        // ─────────────────────────────────────────
        Console.WriteLine("\n=== SUBSTRING ==="); // extract part of the string
        Console.WriteLine(t.Substring(7));            // "World!"
        Console.WriteLine(t.Substring(7, 5));         // "World"


        // ─────────────────────────────────────────
        // 7. REPLACE
        // ─────────────────────────────────────────
        Console.WriteLine("\n=== REPLACE ==="); // replace part of the string with something else
        Console.WriteLine(t.Replace("World", "C#"));  // "Hello, C#!"
        Console.WriteLine(t.Replace("l", "*"));       // "He**o, Wor*d!"


        // ─────────────────────────────────────────
        // 8. SPLIT & JOIN
        // ─────────────────────────────────────────
        Console.WriteLine("\n=== SPLIT & JOIN ==="); // split string into parts and join them back together.
        string csv = "Chirag,Amit,Sara,Raj";

        Console.WriteLine("Original CSV : " + csv);

        string[] parts = csv.Split(',');
        foreach (var p in parts)
            Console.WriteLine(p);                     // Chirag Amit Sara Raj

        string joined = string.Join(" - ", parts);
        Console.WriteLine(joined);                    // Chirag - Amit - Sara - Raj
        
        // ─────────────────────────────────────────
        // 9. STRING INTERPOLATION & CONCAT
        // ─────────────────────────────────────────
        Console.WriteLine("\n=== INTERPOLATION & CONCAT ===");
        string name = "Chirag";
        int age  = 21;

        Console.WriteLine($"Name: {name}, Age: {age}");   // Name: Chirag, Age: 21
        Console.WriteLine(string.Concat(name, " is ", age.ToString(), " years old."));


        // ─────────────────────────────────────────
        // 10. COMPARE & EQUALS
        // ─────────────────────────────────────────
        Console.WriteLine("\n=== COMPARE & EQUALS ===");
        string a = "hello";
        string b = "HELLO";

        Console.WriteLine(a.Equals(b));                                         // False
        Console.WriteLine(a.Equals(b, StringComparison.OrdinalIgnoreCase));     // True
        Console.WriteLine(string.Compare(a, b, ignoreCase: true));              // 0 (equal)


        // ─────────────────────────────────────────
        // 11. IS NULL OR EMPTY
        // ─────────────────────────────────────────
        Console.WriteLine("\n=== NULL / EMPTY CHECKS ===");
        string empty = "";
        string blank = "   ";
        string nullS = null;

        Console.WriteLine(string.IsNullOrEmpty(empty));        // True
        Console.WriteLine(string.IsNullOrEmpty(nullS));        // True
        Console.WriteLine(string.IsNullOrWhiteSpace(blank));   // True


        // ─────────────────────────────────────────
        // 12. PAD & REPEAT
        // ─────────────────────────────────────────
        Console.WriteLine("\n=== PAD ===");
        string code = "42";
        // Console.WriteLine(code.PadLeft(2));          // "42" (already 2 chars, no padding)
        Console.WriteLine(code.PadLeft(5));          // "   42"
        Console.WriteLine(code.PadRight(5, '*'));     // "42***"
        Console.WriteLine(code.PadLeft(5, '0'));      // "00042"


        // ─────────────────────────────────────────
        // 13. STRING BUILDER (for heavy concatenation)
        // ─────────────────────────────────────────
        Console.WriteLine("\n=== STRING BUILDER ===");
        var sb = new System.Text.StringBuilder(); // Initialize StringBuilder with initial string  is immutable but StringBuilder is mutable.
        sb.Append("Hello");
        sb.Append(", ");
        sb.Append("World!");
        Console.WriteLine("Before Replacing : "+sb.ToString());            // Hello, World!
        sb.Replace("World", "C#");
        Console.WriteLine("After Replacing : "+sb.ToString());            // Hello, C#!

        string a1 = "abc";
        var sb1 = new System.Text.StringBuilder(a1); // Initialize StringBuilder with initial string  is immutable but StringBuilder is mutable.
        sb1.Append("def");
        Console.WriteLine(sb1.ToString());           // abcdef
        
    }
}