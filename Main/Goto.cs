#pragma warning disable
class Goto {
    public static void Run()
{
    // goto statement : is a control flow statement that allows you to jump to a specific label within the same method. 
    // It can be used to transfer control to a different part of the code, bypassing the normal flow of execution. However, 
    // it is generally discouraged to use goto statements in modern programming practices as they can make code harder to read and maintain.

   
    //int number = Console.ReadLine(); // error : cannot implicitly convert string to int. We need to parse the input string to an integer using int.Parse() or int.TryParse() method.

    l1:
        Console.WriteLine("Number is less than 10");
        Console.WriteLine("Enter a number : ");
        int num  = int.Parse(Console.ReadLine()); // parsing the input string to an integer
        // or 
        // int num = Convert.ToInt32(Console.ReadLine()); // another way to parse the input string to an integer using Convert.ToInt32() method      
    if(num < 10)
        {
            goto l1;
        }
        else 
        {
            Console.WriteLine("Number is greater than or equal to 10");
        }
        Console.WriteLine("End of program");
}
}
