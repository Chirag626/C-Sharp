// Purpose: Return multiple values from a method.
// out keyword passes a variable by reference and allows a method to assign its value inside the method, even if it was not initialized before the call.
#pragma warning disable

using System;

class Out_Keyword
{
   //  out int x; // ❌ INVALID, cannot have fields with 'out' modifier in a class. This will cause a compilation error.
   public static void Display(out int x)
    {
        // ❌ INVALID, 'out' parameters must be assigned inside the method before they are used. 
        // This will cause a compilation error if we try to use 'x' without assigning it a value first.
        x = 15; // ✅ VALID and must initialize, This is a requirement for 'out' parameters, so this line is necessary to avoid a compilation error.
        Console.WriteLine("Value : "+x);
    }
    // Method using 'out' parameters
    // 'out' allows this method to return multiple values
    public static void Calculate(int a, int b, out int sum, out int difference)
    {
        // IMPORTANT RULE:
        // 'out' parameters MUST be assigned inside the method
        // Otherwise compiler error aayega
        sum = a + b; 
        difference = a - b;
    }

    public static void Run()
    {
        int num1 = 10;
        int num2 = 5;

        // Variable declare kar sakte hain without initializing
        int resultSum;  
        int resultDiff;

        // Method call me 'out' keyword likhna compulsory hai
        Calculate(num1, num2, out resultSum, out resultDiff);

        Console.WriteLine("Sum: " + resultSum);
        Console.WriteLine("Difference: " + resultDiff);


        // --------------------------------------------------
        // Real-world example: TryParse method
        // --------------------------------------------------
        Console.WriteLine("\nEnter a String :");
        string input = Console.ReadLine();

        // int number; // we can declare this variable here, but we can also declare it directly in the TryParse method call using 'out' keyword, which is a more modern and concise way to do it. Dekho neeche ka example.

        // TryParse string ko int me convert karta hai
        // Agar conversion successful ho jaye to true return karega
        // aur converted value 'number' me store karega using 'out'

        Console.WriteLine($"Trying to convert string '{input}' to an integer...");
        bool success = int.TryParse(input, out int number);

        if (success)
        {
            Console.WriteLine("Conversion successful: " + number);
        }
        else
        {
            Console.WriteLine("Conversion failed");
        }


        // --------------------------------------------------
        // Modern C# shorthand (C# 7+)
        // Variable directly 'out' me declare kar sakte hain
        // --------------------------------------------------

        if (int.TryParse("456", out int parsedNumber)) // Yahan par humne 'parsedNumber' variable ko directly 'out' parameter ke saath declare kar diya hai, isse code aur concise ho jata hai.
        {
            Console.WriteLine("Parsed number: " + parsedNumber);
        }
    }
}