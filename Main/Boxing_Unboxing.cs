class Boxing_Unboxing {
    public static void Run()
    {
        // Boxing : is the process of converting a value type (such as int, float, etc.) to an object type. 
        // This is done by creating a new object on the heap and copying the value of the value type into that object. 
        // The boxed object can then be treated as an object and can be used in any context where an object is expected.
        int num = 10; // value type
        object obj = num; // boxing : converting value type to object type
        Console.WriteLine("Boxed value : " + obj); // Output: Boxed value : 10

        // Unboxing : is the process of converting a boxed object back to a value type. 
        // This is done by casting the boxed object back to the original value type. 
        // Unboxing requires an explicit cast and can throw an InvalidCastException if the cast is not valid.
        // Unboxing must be done with the EXACT same type that was used for boxing. For example, if you boxed an int, you must unbox it as an int, not as a float or any other type.
        int unboxedNum = (int)obj; // unboxing : converting object type back to value type
        Console.WriteLine("Unboxed value : " + unboxedNum); // Output: Unboxed value : 10



        // Error Case :
        // float f = (float)obj; // This will throw an InvalidCastException at runtime, because 'obj' contains a boxed int value, and you cannot unbox it as a float.
        // Console.WriteLine("Unboxed float value : " + f);
    }
}