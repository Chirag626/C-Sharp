/*
Purpose: Pass a variable by reference but read-only. It is similar to ref, but with one important difference.
* in = Method gets the same memory location but we cannot modify the value inside the method, but we can read it.

Used when:
* Data is large (structs)
* You want performance improvement
* Prevent modification of the variable inside the method.

*/

using System;

class In_Keyword        
{
    // in parameter = read-only reference
    // method cannot modify it

//   public in int GetBalance()  // ❌ INVALID, C# does not allow "in" with return types but "ref" allowed.
// in prevents modification inside the method, but it only works for parameters.
    public static void ShowValue(in int num) // valid
    {
        Console.WriteLine("Value received: " + num); // here we can read the value but can't modify

        int x = 2*num;
        Console.WriteLine(x);
        // num = 50; ❌ not allowed and Cannot modify because 'in' makes it read-only
    }

    public static void Run()
    {
        int value = 30;

        ShowValue(in value);

        Console.WriteLine("Original value still: " + value);
    }
}