
// Demonstrating Call by Value and Call by Reference in C#


// ===============================
// CALL BY VALUE METHOD
// ===============================
class CallBy_Ref_Value
{
    void ChangeValue(int num)
    {
        // This method receives a COPY of the variable
        // Any change here will NOT affect the original variable

        num = num + 15;

        Console.WriteLine("Inside ChangeValue method: " + num);
    }



    // ===============================
    // CALL BY REFERENCE METHOD
    // ===============================
    void ChangeValueByRef(ref int num)
    {
        // ref means the method receives the ACTUAL variable
        // Any modification here WILL affect the original variable

        num = num + 10;

        Console.WriteLine("Inside ChangeValueByRef method: " + num);
    }



    // ===============================
    // MAIN EXECUTION
    // ===============================
    public static void Run()
    {

        CallBy_Ref_Value obj = new CallBy_Ref_Value();
        int number = 20;

        Console.WriteLine("Original value before Call by Value: " + number);

        // Calling method normally (Call by Value)
        obj.ChangeValue(number);

        Console.WriteLine("Value after Call by Value method: " + number);


        Console.WriteLine("\nOriginal value before Call by Reference: " + number);

        // Calling method using ref keyword
        obj.ChangeValueByRef(ref number);

        Console.WriteLine("Value after Call by Reference method: " + number);
    }
}