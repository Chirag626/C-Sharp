// ============================================================
//       C# LAMBDA - QUICK REVISION
// ============================================================

using System;
using System.Collections.Generic;

class LambdaDemo
{
    // Normal method — naam se call hota hai
    static int Add(int a, int b) => a + b;

    public static void Run()
    {
        // ---------------------------------------------------
        // NORMAL vs LAMBDA
        // Normal method — alag define karo, naam se call karo
        // Lambda — variable mein store karo, variable naam se call karo
        // ---------------------------------------------------
        Console.WriteLine(Add(5, 3));                          // 8 — normal method

        Func<int, int, int> add = (a, b) => a + b;            // 'add' hi naam hai
        Action<string> print    = msg => Console.WriteLine(msg); // 'print' hi naam hai
        Predicate<int> isEven   = n => n % 2 == 0;            // 'isEven' hi naam hai

        Console.WriteLine(add(5, 3));   // 8
        print("Hello Lambda!");         // Hello Lambda!
        Console.WriteLine(isEven(4));   // True


        // ---------------------------------------------------
        // LAMBDA STRUCTURES
        // ---------------------------------------------------
        var x = 10; // Lambda ke andar local variable bhi use kar sakte ho
        Func<int, int> addX = n => n + x; // x ko capture kar raha hai, isse closure kehte hain.
        Console.WriteLine(addX(5)); // 15

        var y = (int num) => num * num; // Type inference — var ke saath lambda, but we have to explicitly mention the type of parameter (int num) because without it, it will give an error as it cannot infer the type of 'num'.
        Console.WriteLine(y(6)); // 36 (not recommended, better to use Func,Action,Predicate for clarity

        Action sayHello              = () => Console.WriteLine("Hello!");         // No param
        Func<int, int> square        = n => n * n;                                // 1 param
        Func<int, int, int> multiply = (a, b) => a * b;                          // Multi param
        Func<int, int, int> power    = (a, b) =>                                  // Multi line
        {
            int result = 1;
            for (int i = 0; i < b; i++) result *= a;
            return result;
        };

        sayHello();                    // Hello!
        Console.WriteLine(square(5));  // 25
        Console.WriteLine(multiply(4, 5)); // 20
        Console.WriteLine(power(2, 8));    // 256


        // ---------------------------------------------------
        // FUNC → Return hoti hai  |  Last type = Output
        // ACTION → Void, kuch return nahi
        // PREDICATE → Hamesha bool return
        // ---------------------------------------------------
        Func<string, string> shout       = name => name.ToUpper();
        Action<string, int> printInfo    = (name, age) => Console.WriteLine($"{name} is {age}");
        Predicate<int> isAdult           = age => age >= 18;

        Console.WriteLine(shout("Chirag"));  // Chirag
        printInfo("Chirag", 21);             // Chirag is 21
        Console.WriteLine(isAdult(20));     // True


        // ---------------------------------------------------
        // LAMBDA AS PARAMETER
        // Lambda ko method mein pass karo
        // Java mein interface pass karni padti thi 
        // ---------------------------------------------------
        Console.WriteLine(Calculate(10, 5, (a, b) => a + b));  // 15
        Console.WriteLine(Calculate(10, 5, (a, b) => a * b));  // 50


        // ---------------------------------------------------
        // LINQ — Lambda har jagah hai!
        // ---------------------------------------------------
        var numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        var evens   = numbers.Where(n => n % 2 == 0);       // Predicate
        var doubled = numbers.Select(n => n * 2);            // Func
        var sum     = numbers.Aggregate((a, b) => a + b);   // Func

        Console.WriteLine(string.Join(", ", evens));    // 2,4,6,8,10
        Console.WriteLine(string.Join(", ", doubled));  // 2,4,6...20
        Console.WriteLine(sum);                         // 55
    }

    static int Calculate(int a, int b, Func<int, int, int> op) => op(a, b);
}

// -------------------------------------------------------
// RULE:
// Return karta hai  →  Func<Input, Output>
// Void              →  Action<Input>
// Bool return       →  Predicate<Input>
// -------------------------------------------------------


// ## Short Summary
// ```
// var    → Local variable mein store karna ho toh chalega
//          But type explicitly batani padegi — (int n) => n*n
//          Method parameter mein pass nahi kar sakte

// Func   → Har jagah use kar sakte ho
// Action → Har jagah use kar sakte ho