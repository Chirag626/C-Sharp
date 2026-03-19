/*
Purpose: Allow a method to modify the original variable.

Example use cases:
* Swap values
* Modify counters
* Update variables inside methods
*/
using System;
static class Ref_keyword
{

    class Practice
{
    // public static int x = 10;
    // ref int y = ref x; // 'y' is a reference to 'x' is invalid because ref variables cannot be declared at class level, they must be declared inside a method. This will cause a compilation error.

    // Console.WriteLine(x); // ❌ INVALID, cannot have top-level statements in a class. This will cause a compilation error.
}

    // ref passes variable by reference
    // variable must be initialized before passing to method.
    public static void AddFive(ref int num)
    {
// this will change the value of num in the caller method because it is passed by reference using ref keyword.
        num = num + 5; 
    }

    public static void Run()
    {
        int number = 10; // must initialize

        Console.WriteLine("Before method: " + number);

        AddFive(ref number); // pass by reference, so the changes made to num in AddFive method will reflect in number variable here.

        Console.WriteLine("After method: " + number); // number will print 15 because it is passed by reference and the changes made to num in AddFive method will reflect in number variable here.
    }

    public static void Run1()
    {
        int val = 10;

        // ref local variable must be initialized with same type variable.
        ref int referenceVal = ref val; // referenceVal is now a reference to val, so any changes made to referenceVal will also change val because they refer to the same memory location.
        referenceVal = 1000; // modifies val.
        // Console.WriteLine("Ref var. another Example : " + referenceVal); // referenceVal will print 1000 because it is referring to the same memory location as val.
        Console.WriteLine("Val : " + val); // val will also change because referenceVal is referring to the same memory location as val.
    }
}