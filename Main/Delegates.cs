// Delegates : A delegate is a type that holds a reference to a method. in simple words Method ko variable mein store karna. 
// They are commonly used in event handling and asynchronous programming.   
// Parameters and return type of the method should match with the delegate signature.


// eg. Alert system : Phone, Email, SMS
// eg. Math operations : Add, Subtract, Multiply
// Steps to use Delegates :
// 1. Define a delegate type (method ka blueprint)
// 2. Create methods that match the delegate signature
// 3. Store method in delegate variable
#pragma warning disable
using System;
class Delegates
{

    // Step 1 — Delegate type define karo (method ka blueprint)
    delegate int MathOperation(int a, int b); 

    // Step 2 — Methods banao jo delegate se match karein
    static int Add(int a, int b) => a + b;
    static int Subtract(int a, int b) => a - b;
    static int Multiply(int a, int b) => a*b;




                // Alert Delegate Example : 
    static void AlertPhone()
    {
        Console.WriteLine("Phone Alert!");
    }

    static void AlertEmail()
    {
        Console.WriteLine("Email Alert!");
    }

    static void AlertSMS()
    {
        Console.WriteLine("SMS Alert!");
    }

    public delegate void AlertDelegate(); // This is a delegate declaration. It defines a delegate type named AlertDelegate that can reference any method that has a void return type and takes no parameters.

    public static void Run()
    {
        AlertDelegate alert; // This is a delegate variable declaration. It declares a variable named alert of type AlertDelegate, which can hold a reference to any method that matches the signature defined by the AlertDelegate delegate type.

        alert = AlertPhone; // This assigns the AlertPhone method to the alert delegate variable. Now, alert holds a reference to the AlertPhone method.

        Console.WriteLine("Delegate Call 1 : "); // This invokes the method referenced by the alert delegate variable, which in this case is the AlertPhone method. So it will print "Phone Alert!" to the console.
        alert(); // This invokes the method referenced by the alert delegate variable.
        alert += AlertEmail; // This assigns the AlertEmail method to the alert delegate variable. Now, alert holds a reference to the AlertEmail method.

        Console.WriteLine("Delegate Call 2 : "); // This invokes the method referenced by the alert delegate variable, which in this case is the AlertPhone method. So it will print "Phone Alert!" to the console.
        alert += AlertSMS; // This assigns the AlertSMS method to the alert delegate variable. Now, alert holds a reference to the AlertSMS method.
        alert(); // This invokes the method referenced by the alert delegate variable, which in this case is the AlertEmail method. So it will print "Email Alert!" to the console.


        Console.WriteLine("Delegate Call 3 : ");
        alert -= AlertPhone; // This removes the reference to the AlertPhone method from the alert delegate variable. Now, alert no longer holds a reference to the AlertPhone method.
        alert();

        // Step 3 — Delegate variable mein method store karo
        MathOperation op = Add;
        op += Subtract;
        op += Multiply;

        Console.WriteLine(op(5, 3));   // 15 
/* when we invoke the delegate variable 'op' with the arguments 5 and 3, it will call all the methods assigned to it in the order they were added. 
So it will first call Add(5, 3) which returns 8, then Subtract(5, 3) which returns 2, and finally Multiply(5, 3) which returns 15. 
However, since the delegate is of type MathOperation which returns an int,
it will only return the result of the last method called, which is Multiply(5, 3) returning 15.*/

        // op = Subtract;
        // Console.WriteLine(op(5, 3));   // 2

        // op = Multiply;
        // Console.WriteLine(op(5, 3));   // 15

    }
}