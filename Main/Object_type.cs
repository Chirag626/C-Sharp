#pragma warning disable

using System;
static class Object_type
{
    static object a; // 'a' is declared as an object type, which can hold any data type.

    public static void Run()
    {

    // a = new List<int>(); // This is also valid for the same reason.
    // a = new MyClass(); // This is valid as well, assuming MyClass is defined somewhere in the code
    // a = new DateTime(2024, 6, 1); // This is valid, as 'object' can hold a DateTime value.
    // a = new Dictionary<string, int>(); // This is valid, as 'object' can hold a Dictionary object.
    // a = new int[] { 1, 2, 3 }; // This is valid, as 'object' can hold an array of integers.
    // a = null; // This is valid, as 'object' can also hold a null value.
    a = "Hello, World!"; // This is valid, as 'object' can hold a string value.
    a = 'x'; // This is valid, as 'object' can hold a char value.
    a = true; // This is valid, as 'object' can hold a boolean value.
    a = 123; //  Boxing happens here, as 'object' can hold an integer value.
    a = 2.2f; // Boxing happens here, as 'object' can hold a float value.

     // 'a' currently contains a FLOAT value (2.2f), which is a boxed value type.
    Console.WriteLine("float value : "+a); // This will print the current value of 'a', which is 3.14 in this case.

       // Unboxing must be done with the EXACT same type
    float f = (float)a;   // UNBOXING (object → float) // This will unbox the value of 'a' back to a float type and assign it to variable 'f'.
    Console.WriteLine("Unboxed float value : "+f); 


    // another example using var : 
    Object obj = "hello"; // Boxing happens here, as 'object' can hold an integer value.
    var x = obj; // 'x' is inferred to be of type 'object' because 'obj' is of type 'object'.
    Console.WriteLine("Value of x : " + x); // This will print the value of 'x', which is "hello" in this case.
}
}