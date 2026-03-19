// ============================================================
//          C# METHODS - COMPLETE REVISION FILE
//          For: Java Developer learning C#
// ============================================================

class Functions
{
    // -------------------------------------------------------
    // MAIN METHOD — Entry point (Same as Java)
    // Saare method calls yahan se hote hain
    // -------------------------------------------------------
   public  static void Run()
    {
        // 1. Basic Method
        int result = Add(5, 10);
        Console.WriteLine($"Add: {result}");            // 15

        // 2. Void Method
        PrintHello("Chirag");                            // Hello, Chirag!

        // 3. Optional Parameters
        // Calling method with ONLY required parameter(Name) , message parameter is not passed, so default value "Hello" will be used
        Greet("Chirag");                                 // Hello, Chirag!  — default use hua - "Hello" use hua

        // Calling method with BOTH parameter, Here we override the default value "Hello" with "Hi"
        Greet("Chirag", "Hi");                           // Hi, Chirag!     — custom value di - "Hi" use hua

        // 4. Named Parameters
        int r1 = Divide(10, 2);                         // Normal call isme order matter karta hai.
        int r2 = Divide(denominator: 2, numerator: 10); // Named call — order ulta, phir bhi kaam karega
        Console.WriteLine($"Divide normal: {r1}");      // 5
        Console.WriteLine($"Divide named: {r2}");       // 5

        // 5. Out Parameter
        GetDetails("Rohan Sharma", out string firstName, out string lastName);
        Console.WriteLine($"First: {firstName}");       // Rohan
        Console.WriteLine($"Last: {lastName}");         // Sharma

        // 6(a). Out Parameter — Practical Example 1
        int x, y;

        GetNumbers(out x, out y);

        Console.WriteLine(x); // 10
        Console.WriteLine(y); // 20

        // 6(b). Out Parameter — Practical Example 2
        var nums = new List<int> { 10, 20, 30, 40, 50 };
        GetSumAndAverage(nums, out int total, out double avg);
        Console.WriteLine($"Sum: {total}");             // 150
        Console.WriteLine($"Average: {avg}");           // 30

        // 7. Method Overloading
        Console.WriteLine(Multiply(3, 4));              // 12   — int version called
        Console.WriteLine(Multiply(3.5, 2.0));          // 7.0  — double version called

        // 8. Expression-Bodied Method
        Console.WriteLine(Square(5));                   // 25
        Console.WriteLine(GetGreeting("Rohan"));        // Hey Rohan!
    }


    // -------------------------------------------------------
    // 1. BASIC METHOD
    // - PascalCase naming (Java mein camelCase hota tha)
    // - Return type pehle, phir method name
    // -------------------------------------------------------
    static int Add(int a, int b)
    {
        return a + b;
    }


    // -------------------------------------------------------
    // 2. VOID METHOD
    // - Kuch return nahi karta
    // - Same as Java
    // -------------------------------------------------------
    static void PrintHello(string name)
    {
        Console.WriteLine($"Hello, {name}!");
    }


    // -------------------------------------------------------
    // 3. OPTIONAL PARAMETERS (Java mein nahi hota!)
    // - Parameter ko default value de sakte ho
    // - Agar caller value na de toh default use hogi
    // - Default parameters hamesha last mein hone chahiye
    // - Overloading se better alternative hai default parameters, kyunki code duplication nahi hota
    
    // -------------------------------------------------------
    
    // here "name" is required parameter and "message" is optional parameter with default value "Hello".
    static void Greet(string name, string message = "Hello") 
    {
        Console.WriteLine($"{message}, {name}!");
    }


    // -------------------------------------------------------
    // 4. NAMED PARAMETERS (Java mein nahi hota!)
    // - Method call mein parameter ka naam likh sakte ho
    // - Order matter nahi karta jab naam use karo
    // -------------------------------------------------------
    static int Divide(int numerator, int denominator)
    {
        return numerator / denominator;
    }


    // -------------------------------------------------------
    // 5. OUT PARAMETER (Multiple values return karna)
    // - Java mein multiple values ke liye object banana padta tha
    // - C# mein 'out' keyword se seedha multiple values milti hain
    // - Caller mein bhi 'out' likhna zaroori hai
    // -------------------------------------------------------
    static void GetDetails(string fullName, out string first, out string last)
    {
        string[] parts = fullName.Split(' ');
        first = parts[0];
        last = parts[1];
    }


    // -------------------------------------------------------
    // 6(a). OUT PARAMETER — PRACTICAL EXAMPLE 1
    // - List<int> se Sum aur Average dono ek saath nikalna
    // -------------------------------------------------------
    static void GetNumbers(out int a, out int b)
    {
        a = 10;
        b = 20;
    }


    // -------------------------------------------------------
    // 6(b). OUT PARAMETER — PRACTICAL EXAMPLE 2
    // - List<int> se Sum aur Average dono ek saath nikalna
    // -------------------------------------------------------
    static void GetSumAndAverage(List<int> numbers, out int sum, out double average)
    {
        sum = 0;
        foreach (var num in numbers)
        {
            sum += num;
        }
        average = (double)sum / numbers.Count;
    }


    // -------------------------------------------------------
    // 7. METHOD OVERLOADING (Same as Java)
    // - Same method naam, alag parameters
    // - Compiler automatically sahi version choose karta hai
    // -------------------------------------------------------
    static int Multiply(int a, int b)
    {
        return a * b;
    }

    static double Multiply(double a, double b)
    {
        return a * b;
    }


    // -------------------------------------------------------
    // 8. EXPRESSION-BODIED METHOD (Shorthand — Java mein nahi hota!)
    // - Single line method ke liye => use kar sakte ho
    // - Cleaner aur concise syntax
    // -------------------------------------------------------
    static int Square(int n) => n * n;
    static string GetGreeting(string name) => $"Hey {name}!";

}

// -------------------------------------------------------
// QUICK JAVA vs C# COMPARISON
// -------------------------------------------------------
// Java                          | C#
// ------------------------------|-----------------------------
// public static int add()       | static int Add()
// camelCase method names        | PascalCase method names
// No default params             | Default params ✅
// No named params               | Named params ✅
// Return only 1 value           | 'out' se multiple values ✅
// No => shorthand               | Expression-bodied => ✅
// -------------------------------------------------------