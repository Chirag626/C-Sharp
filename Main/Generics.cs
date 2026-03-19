// ============================================================
//       C# GENERICS - COMPLETE REVISION FILE
//       For: Java Developer learning C#
// ============================================================
#pragma warning disable
using System;
using System.Collections.Generic;

// ---------------------------------------------------
// 1. GENERIC CLASS
// T — placeholder hai, call karte waqt actual type decide hoti hai
// Java mein bhi same concept tha
// ---------------------------------------------------
public class Box<T>
{
    public T Value { get; set; }

    public Box() {}

    public Box(T value)
    {
        Value = value;
    }

    public void PrintValue()
    {
        Console.WriteLine($"Value: {Value}, Type: {typeof(T).Name}");
    }
}


// ---------------------------------------------------
// 2. MULTIPLE TYPE PARAMETERS
// K aur V — 2 alag types
// Java mein bhi same tha
// ---------------------------------------------------
public class Pair<K, V>
{
    public K Key { get; set; }
    public V Value { get; set; }

    public Pair(K key, V value)
    {
        Key   = key;
        Value = value;
    }

    public void Print()
    {
        Console.WriteLine($"Key: {Key}, Value: {Value}");
    }
}


// ---------------------------------------------------
// 3. REAL WORLD — API RESPONSE ⭐
// APIs mein sabse zyada use hota hai
// Har response same structure mein wrap karo
// Java mein manually karna padta tha
// ---------------------------------------------------
public class ApiResponse<T>
{
    public bool Success { get; set; }
    public string Message { get; set; }
    public T Data { get; set; }

    // Success response
    public static ApiResponse<T> Ok(T data, string message = "Success")
    {
        return new ApiResponse<T>
        {
            Success = true,
            Message = message,
            Data    = data
        };
    }

    // Failure response
    public static ApiResponse<T> Fail(string message)
    {
        return new ApiResponse<T>
        {
            Success = false,
            Message = message,
            Data    = default   // T ka default value — null for classes, 0 for int etc
        };
    }

    public void Print()
    {
        Console.WriteLine($"Success: {Success} | Message: {Message} | Data: {Data}");
    }
}


class Generics
{
    public static void Run()
    {
        // ---------------------------------------------------
        // 1. GENERIC METHOD
        // Ek method — sab types ke liye
        // Java mein alag alag methods likhne padte the
        // ---------------------------------------------------
        Console.WriteLine("===== 1. Generic Method =====");
        Console.WriteLine(GetMax(5, 10));                  // 10 — int
        Console.WriteLine(GetMax(3.5, 2.1));               // 3.5 — double
        Console.WriteLine(GetMax("Zebra", "Apple"));       // Zebra — string
        Console.WriteLine();


        // ---------------------------------------------------
        // 2. GENERIC CLASS
        // ---------------------------------------------------
        Console.WriteLine("===== 2. Generic Class =====");
        var intBox    = new Box<int>(42);
        var stringBox = new Box<string>("Hello");
        var doubleBox = new Box<double>(3.14);

        intBox.PrintValue();     // Value: 42,    Type: Int32
        stringBox.PrintValue();  // Value: Hello, Type: String
        doubleBox.PrintValue();  // Value: 3.14,  Type: Double
        Console.WriteLine();


        // ---------------------------------------------------
        // 3. MULTIPLE TYPE PARAMETERS
        // ---------------------------------------------------
        Console.WriteLine("===== 3. Multiple Type Parameters =====");
        var pair1 = new Pair<string, int>("Age", 21);
        var pair2 = new Pair<string, string>("Name", "Rohan");
        var pair3 = new Pair<int, bool>(1, true);

        pair1.Print();   // Key: Age,  Value: 21
        pair2.Print();   // Key: Name, Value: Rohan
        pair3.Print();   // Key: 1,    Value: True
        Console.WriteLine();


        // ---------------------------------------------------
        // 4. CONSTRAINTS — where keyword
        // Java mein : <T extends Comparable>
        // C# mein   : where T : IComparable<T>
        // ---------------------------------------------------
        Console.WriteLine("===== 4. Constraints =====");
        Console.WriteLine(GetMin(5, 10));           // 5
        Console.WriteLine(GetMin(3.5, 2.1));        // 2.1
        Console.WriteLine(GetMin("Zebra", "Apple")); // Apple

        PrintIfNotNull("Hello");   // Hello
        PrintIfNotNull<string>(null); // (nothing — null hai)

        var obj = CreateInstance<Box<int>>();  // New Box<int> bana
        Console.WriteLine($"Created: {obj.GetType().Name}");
        Console.WriteLine();


        // ---------------------------------------------------
        // 5. REAL WORLD — API RESPONSE ⭐
        // ---------------------------------------------------
        Console.WriteLine("===== 5. ApiResponse<T> =====");

        // Success response — string data
        var userResponse = ApiResponse<string>.Ok("Rohan", "User found!");
        userResponse.Print();

        // Success response — int data
        var numResponse = ApiResponse<int>.Ok(42);
        numResponse.Print();

        // Failure response
        var failResponse = ApiResponse<string>.Fail("User not found!");
        failResponse.Print();
        Console.WriteLine();


        // ---------------------------------------------------
        // 6. GENERIC LIST — Built-in C# Collection
        // Java mein ArrayList<T> tha
        // C# mein List<T> — same concept
        // ---------------------------------------------------
        Console.WriteLine("===== 6. Generic List =====");
        var numbers = new List<int> { 1, 2, 3, 4, 5 };
        var names   = new List<string> { "Rohan", "Amit", "Sara" };

        PrintList(numbers);   // 1 2 3 4 5
        PrintList(names);     // Rohan Amit Sara
    }


    // ---------------------------------------------------
    // HELPER METHODS
    // ---------------------------------------------------

    // Generic method — where T : IComparable<T> means T comparable hona chahiye
    // Java mein: <T extends Comparable<T>>
    static T GetMax<T>(T a, T b) where T : IComparable<T>
    {
        return a.CompareTo(b) > 0 ? a : b;
    }

    static T GetMin<T>(T a, T b) where T : IComparable<T>
    {
        return a.CompareTo(b) < 0 ? a : b;
    }

    // where T : class — sirf reference types (string, class etc)
    // Java mein: <T extends Object>
    static void PrintIfNotNull<T>(T value) where T : class
    {
        if (value != null)
            Console.WriteLine(value);
    }

    // where T : new() — T ka default constructor hona chahiye
    static T CreateInstance<T>() where T : new()
    {
        return new T();
    }

    // Generic method jo List print kare — kisi bhi type ki
    static void PrintList<T>(List<T> list)
    {
        foreach (var item in list)
            Console.Write($"{item} ");
        Console.WriteLine();
    }
}

// -------------------------------------------------------
// QUICK JAVA vs C# COMPARISON
// -------------------------------------------------------
// Java                        | C#
// ----------------------------|---------------------------
// <T>                         | <T>  ✅ Same
// <T extends Comparable>      | where T : IComparable<T>
// Type erasure at runtime      | typeof(T) runtime pe bhi ✅
// <? extends T> wildcard      | where T : BaseClass
// ArrayList<T>                | List<T>
// -------------------------------------------------------