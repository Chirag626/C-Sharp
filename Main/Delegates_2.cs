// ============================================================
//       C# DELEGATES - COMPLETE REVISION FILE
// ============================================================
#pragma warning disable
using System;
using System.Collections.Generic;
// ---------------------------------------------------
// DELEGATE TYPE DEFINITIONS
// Method ka blueprint — return type aur parameters define karo
// Java mein: Runnable, Callable interfaces use karni padti thi
// C# mein: directly delegate define karo
// ---------------------------------------------------
delegate int  MathOperationDelegate(int a, int b);  // int return, 2 int params
delegate void NotifyDelegate(string message);        // void return, 1 string param
delegate bool CheckNumberDelegate(int n);            // bool return, 1 int param


class Delegates_2
{
    public static void Run()
    {
        BasicDelegateExample();
        MulticastDelegateExample();
        AnonymousMethodExample();
        LambdaExample();
        FuncActionPredicateExample();
        DelegateAsParameterExample();
        RealWorldExample();
        LinqConnectionExample();
    }


    // ---------------------------------------------------
    // 1. BASIC DELEGATE
    // Method ko variable mein store karo
    // Same variable mein alag alag methods store kar sakte ho
    // ---------------------------------------------------
    static void BasicDelegateExample()
    {
        Console.WriteLine("===== 1. Basic Delegate =====");

        // Methods ko delegate variable mein store karo
        MathOperationDelegate op = Add;
        Console.WriteLine("Add : "+op(5, 3));   // 8

        op = Subtract;                 // Same variable — alag method
        Console.WriteLine("Subtract : "+op(5, 3));   // 2

        op = Multiply;
        Console.WriteLine("Multiply : "+op(5, 3));   // 15

        Console.WriteLine();
    }


    // ---------------------------------------------------
    // 2. MULTICAST DELEGATE
    // += se multiple methods add karo
    // Ek call — sab methods chalenge
    // Java mein directly possible nahi tha
    // ---------------------------------------------------
    static void MulticastDelegateExample()
    {
        Console.WriteLine("===== 2. Multicast Delegate =====");

        NotifyDelegate NotifyDelegate = SendEmail;
        NotifyDelegate += SendSMS;     // Method add karo
        NotifyDelegate += SendPush;    // Aur ek add karo

        // Ek call — teeno methods chalenge!
        NotifyDelegate("Order placed!");

        Console.WriteLine("--- SMS remove karke ---");
        NotifyDelegate -= SendSMS;     // Method remove karo
        NotifyDelegate("Order shipped!");

        Console.WriteLine();
    }


    // ---------------------------------------------------
    // 3. ANONYMOUS METHOD
    // Method alag se define karne ki zaroorat nahi
    // Inline likh do
    // ---------------------------------------------------
    static void AnonymousMethodExample()
    {
        Console.WriteLine("===== 3. Anonymous Method =====");

        // Method alag se define karne ki jagah inline likh do
        MathOperationDelegate add = delegate(int a, int b)
        {
            return a + b;
        };

        MathOperationDelegate multiply = delegate(int a, int b)
        {
            return a * b;
        };

        Console.WriteLine(add(5, 3));       // 8
        Console.WriteLine(multiply(5, 3));  // 15

        Console.WriteLine();
    }


    // ---------------------------------------------------
    // 4. LAMBDA EXPRESSION — Anonymous method ka short form ⭐
    // LINQ mein sabse zyada yahi use hota hai
    // Java mein bhi Lambda Java 8 se aaya — same concept
    // ---------------------------------------------------
    static void LambdaExample()
    {
        Console.WriteLine("===== 4. Lambda Expression =====");

        // Anonymous method  →  Lambda
        // delegate(a, b) { return a + b; }  →  (a, b) => a + b
        MathOperationDelegate add      = (a, b) => a + b;
        MathOperationDelegate subtract = (a, b) => a - b;
        MathOperationDelegate multiply = (a, b) => a * b;

        Console.WriteLine(add(10, 5));       // 15
        Console.WriteLine(subtract(10, 5));  // 5
        Console.WriteLine(multiply(10, 5));  // 50

        // Single parameter — brackets optional
        CheckNumberDelegate isEven = n => n % 2 == 0;
        Console.WriteLine(isEven(4));   // True
        Console.WriteLine(isEven(7));   // False

        // Multi-line lambda
        MathOperationDelegate power = (a, b) =>
        {
            int result = 1;
            for (int i = 0; i < b; i++) result *= a;
            return result;
        };
        Console.WriteLine(power(2, 10));  // 1024

        Console.WriteLine();
    }


    // ---------------------------------------------------
    // 5. FUNC, ACTION, PREDICATE — Built-in Delegates ⭐
    // Apna delegate define karne ki zaroorat nahi
    // C# ne ready-made delegates diye hain
    // ---------------------------------------------------
    static void FuncActionPredicateExample()
    {
        Console.WriteLine("===== 5. Func, Action, Predicate =====");

        // FUNC — return type hoti hai
        // Func<Input1, Input2, ..., Output> which mean number of input parameters and one output (return type)
        Func<int, int, int> add     = (a, b) => a + b; // here, Func takes two int parameters(first and second) and returns an int(third one).
        Console.WriteLine(add(5, 3));        // 8

        Func<string, string> shout  = name => name.ToUpper();
        Console.WriteLine(shout("Chirag"));   // Chirag
        
        Func<int, bool> isEven      = n => n % 2 == 0; // here, Func takes one int parameter and returns a bool as an output.
        Console.WriteLine(isEven(4));        // True
        
        Func<int, int, string> info = (a, b) => $"Sum of {a} and {b} is {a + b}";
        Console.WriteLine(info(3, 4));       // Sum of 3 and 4 is 7


        Console.WriteLine("--- Action ---");

        // ACTION — void return, kuch return nahi karta
        // Action<Input1, Input2, ...> only input parameters, no output (return type is void).
        Action<string> print          = msg => Console.WriteLine(msg);
        Action<string, int> printInfo = (name, age) => Console.WriteLine($"{name} is {age}");
        Action greet                  = () => Console.WriteLine("Hello!");

        print("Hello");           // Hello
        printInfo("Chirag", 21);   // Chirag is 21
        greet();                  // Hello!

        Console.WriteLine("--- Predicate ---");

        // PREDICATE — hamesha bool return karta hai
        // Predicate<T>
        Predicate<int> isPositive    = n => n > 0;
        Predicate<string> isNotEmpty = s => !string.IsNullOrEmpty(s);
        Predicate<int> isAdult       = age => age >= 18;

        Console.WriteLine(isPositive(5));        // True
        Console.WriteLine(isPositive(-3));       // False
        Console.WriteLine(isNotEmpty("Hello"));  // True
        Console.WriteLine(isAdult(20));          // True

        Console.WriteLine();
    }


    // ---------------------------------------------------
    // 6. DELEGATE AS PARAMETER
    // Method ko method mein pass karo
    // Java mein interface pass karni padti thi
    // C# mein directly Func/Action pass karo
    // ---------------------------------------------------
    static void DelegateAsParameterExample()
    {
        Console.WriteLine("===== 6. Delegate as Parameter =====");

        // Func ko parameter ki tarah pass karo
        Console.WriteLine(Calculate(10, 5, (a, b) => a + b));   // 15
        Console.WriteLine(Calculate(10, 5, (a, b) => a - b));   // 5
        Console.WriteLine(Calculate(10, 5, (a, b) => a * b));   // 50

        // Predicate pass karo
        Console.WriteLine(Filter(15, n => n > 10));   // True
        Console.WriteLine(Filter(5, n => n > 10));    // False

        Console.WriteLine();
    }


    // ---------------------------------------------------
    // 7. REAL WORLD — Sorting with Delegate
    // List.Sort() mein delegate pass karo
    // ---------------------------------------------------
    static void RealWorldExample()
    {
        Console.WriteLine("===== 7. Real World — Sorting =====");

        var students = new List<(string Name, int Marks)>
        {
            ("Chirag", 85),
            ("Amit",  92),
            ("Sara",  78),
            ("Raj",   95)
        };

        // Marks ascending — delegate pass kiya Sort mein
        students.Sort((a, b) => a.Marks.CompareTo(b.Marks));
        Console.WriteLine("Ascending:");
        foreach (var s in students)
            Console.WriteLine($"  {s.Name}: {s.Marks}");

        // Marks descending
        students.Sort((a, b) => b.Marks.CompareTo(a.Marks));
        Console.WriteLine("Descending:");
        foreach (var s in students)
            Console.WriteLine($"  {s.Name}: {s.Marks}");

        Console.WriteLine();
    }


    // ---------------------------------------------------
    // 8. LINQ CONNECTION — Delegates kahan use hote hain
    // LINQ ke andar internally delegates/lambdas hain
    // Isliye delegates pehle padhne zaroori the!
    // ---------------------------------------------------
    static void LinqConnectionExample()
    {
        Console.WriteLine("===== 8. LINQ Connection =====");

        var numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        // Yeh sab internally delegates/lambdas hain!
        var evens   = numbers.Where(n => n % 2 == 0);     // Predicate delegate
        var doubled = numbers.Select(n => n * 2);          // Func delegate
        var sum     = numbers.Aggregate((a, b) => a + b);  // Func delegate

        Console.WriteLine($"Evens   : {string.Join(", ", evens)}");    // 2,4,6,8,10
        Console.WriteLine($"Doubled : {string.Join(", ", doubled)}");  // 2,4,6...20
        Console.WriteLine($"Sum     : {sum}");                         // 55
    }


    // ---------------------------------------------------
    // HELPER METHODS
    // ---------------------------------------------------

    static int Add(int a, int b)      => a + b;
    static int Subtract(int a, int b) => a - b;
    static int Multiply(int a, int b) => a * b;

    static void SendEmail(string message) => Console.WriteLine($"Email: {message}");
    static void SendSMS(string message)   => Console.WriteLine($"SMS: {message}");
    static void SendPush(string message)  => Console.WriteLine($"Push: {message}");

    static int Calculate(int a, int b, Func<int, int, int> operation) => operation(a, b);
    static bool Filter(int number, Predicate<int> condition)          => condition(number);
}


// -------------------------------------------------------
// QUICK SUMMARY
// -------------------------------------------------------
// delegate     →  Method ka type define karna
// Multicast    →  += se multiple methods, ek call mein sab
// Anonymous    →  Inline method, alag define nahi karni
// Lambda =>    →  Anonymous ka short form — sabse zyada use
// Func<T>      →  Built-in delegate — return type hoti hai
// Action<T>    →  Built-in delegate — void, kuch return nahi
// Predicate<T> →  Built-in delegate — hamesha bool return
// -------------------------------------------------------
// JAVA vs C#
// -------------------------------------------------------
// Java                        | C#
// ----------------------------|---------------------------
// Runnable, Callable          | delegate ✅ direct
// No direct method storage    | Method variables ✅
// Lambda — Java 8 se          | Lambda — hamesha se ✅
// No Func/Action/Predicate    | Built-in delegates ✅
// -------------------------------------------------------