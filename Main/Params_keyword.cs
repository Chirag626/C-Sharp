
/*
//params keyword :Jab tumhe variable number of arguments pass karni ho method mein — fixed count nahi pata:

=======================================================================
          C# PARAMS - Without Params jo problem aati hai, uska solution
=======================================================================
// Agar 3 numbers add karne hain
static int Add(int a, int b, int c)
{
    return a + b + c;
}

// 5 numbers ke liye alag method banana padega — painful!
static int Add(int a, int b, int c, int d, int e)
{
    return a + b + c + d + e;
}


*/

using System.Diagnostics.CodeAnalysis;

class Params_keyword
{

    // -------------------------------------------------------
    // 1. BASIC PARAMS
    // - Java mein varargs: int... numbers
    // - C# mein params:    params int[] numbers
    // - Concept same, sirf syntax alag!
    // -------------------------------------------------------
    public static int Add(params int[] numbers)
    {
        int sum = 0;
        foreach (var num in numbers)
        {
            sum += num;
        }
        return sum;
    }


    // -------------------------------------------------------
    // 2. PARAMS KE SAATH NORMAL PARAMETER
    // - Normal params pehle, params wala hamesha LAST mein
    // - Rule: params sirf ek ho sakta hai aur last hona chahiye
    // -------------------------------------------------------
    public static void PrintAll(string title, params string[] names)
    {
        Console.WriteLine($"--- {title} ---");
        foreach (var name in names)
        {
            Console.Write(name+", ");
        }
    }


    // -------------------------------------------------------
    // 3. ARRAY DIRECTLY PASS KARNA
    // - params method mein array bhi directly pass ho sakti hai
    // -------------------------------------------------------
    public static int AddArray(params int[] numbers)
    {
        int sum = 0;
        foreach (var num in numbers)
        {
            sum += num;
        }
        return sum;
    }
}
// -------------------------------------------------------
// QUICK JAVA vs C# COMPARISON
// -------------------------------------------------------
// Java                          | C#
// ------------------------------|-----------------------------
// static int add(int... nums)   | static int Add(params int[] nums)
// Concept same                  | Concept same ✅
// varargs last mein hota hai    | params bhi last mein hota hai ✅
// -------------------------------------------------------