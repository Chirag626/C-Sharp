// NOTE:
// In .NET 6+ C#, we can use Top-Level Statements.
// That means in Program.cs we can directly write code like Console.WriteLine()
// without creating a class or Main() method.

// IMPORTANT RULE:
// Only ONE file in the project can contain top-level statements.
// Usually this file is Program.cs.

// Other .cs files that we create should contain:
// - class
// - methods
// - no direct Console.WriteLine statements at the top level

// Example usage: 
// Console.WriteLine("Hello, World!"); 

// Compiler actually yeh banata hai internally:
// class Program {
//    public static void Main(String[] args) {
//         Console.WriteLine("Hello, World!");
//     }
// }

using System;

public class Program
{
    public static void Main(string[] args)
    {
        // Console.WriteLine("----- Datatypes -----");
        // DataTypes.Run();

        // Console.WriteLine("\n----- Conditions -----");
        // Conditions.Run();

        // Console.WriteLine("\n----- Loops -----");
        // Loops.Run();

        // Console.WriteLine("\n----- Arrays -----");
        // Arrays.Run();

        // Console.WriteLine("\n----- Arrays Example -----");
        // Arrays_Example.Run();

        // Console.WriteLine("\n----- String Methods -----");
        // StringMethods.Run();

        // Console.WriteLine("\n----- Functions -----");
        // Functions.Run();

        // Console.WriteLine("\n----- Switch -----");
        // Switch.Run();

        // Console.WriteLine("\n----- Goto -----");
        // Goto.Run();

        // Console.WriteLine("\n----- Ref Keyword -----");
        // Ref_keyword.Run();
        // Ref_keyword.Run1();


        // Console.WriteLine("\n----- Ref Return Example -----");
        // Console.WriteLine(Ref_Return.GetReference()); // This will print 50 because we have not changed the value of data variable in GetReference method yet, so when we call GetReference method here, it will return the reference to data variable which has the value 50.
        // Ref_Return.GetReference() = 500; // This will change the value of data variable in GetReference method to 500 because it is returning a reference to data variable, so any changes made to the reference returned by GetReference method will also change the value of data variable.
        // Console.WriteLine("Data : " + Ref_Return.GetReference()); // This will print 500 because we have changed the value of data variable in GetReference method to 500 using ref return, so when we call GetReference method here, it will return the reference to data variable which now has the value 500.
        // Ref_Return.Run2(); // This will print 999 because in Run2 method, we are getting the reference to data variable using GetReference method and then modifying it, so the changes will reflect in data variable as well because it is referring to the same memory location. So when we print data variable after modification, it will print 999.

        // Console.WriteLine("\n----- Out Keyword -----");
        // Out_Keyword.Run();
        // Out_Keyword.Display(out int x); // This will call the Display method of the Out_Keyword class, which demonstrates the use of the 'out' keyword. The variable 'x' will be assigned a value inside the Display method, and then we can use it here after the method call. So this will print 15 because in the Display method, we are assigning the value 15 to 'x' and then printing it.

        // Console.WriteLine("\n----- In Keyword -----");
        // In_Keyword.Run();

        // Console.WriteLine("\n----- Null Keyword -----");
        // Null_keyword.Run();

        // Console.WriteLine("\n----- Call By Ref Value -----");
        // CallBy_Ref_Value.Run();

        // Console.WriteLine("\n----- Object_type -----");
        // Object_type.Run(); // This will call the Run method of the Object_type class, which demonstrates the use of the 'object' type.

        //    Console.WriteLine("\n----- Params Keyword -----");

        //     1. Basic params — kitne bhi numbers pass karo
        //     Console.WriteLine(Params_keyword.Add(1, 2));            // 3
        //     Console.WriteLine(Params_keyword.Add(1, 2, 3));         // 6
        //     Console.WriteLine(Params_keyword.Add(1, 2, 3, 4, 5));   // 15
        //     Console.WriteLine(Params_keyword.Add());                // 0 — empty bhi chalega!

        //     2. params ke saath normal parameter bhi use kar sakte ho, bas params ko last mein rakhna hai
        //     Params_keyword.PrintAll("Students", "Rohan", "Amit", "Sara"); // here "Students" is the normal parameter(title) and "Rohan", "Amit", "Sara" are the params parameters. The output will be:

        //     3. Array bhi pass kar sakte ho directly
        //     int[] nums = { 10, 20, 30 };
        //     Console.WriteLine("\n"+Params_keyword.AddArray(nums));       // 60

        //    Console.WriteLine("\n-----Dynamic return type  Params Keyword -----"); 
        //            // Same method — alag alag types return kar raha hai
        //     dynamic intResult    = Dynamic.GetValue(1, 2, 3);
        //     dynamic stringResult = Dynamic.GetValue("Rianchal", "Chirag","Sumit");
        //     dynamic doubleResult = Dynamic.GetValue(1.5, 2.5);
        //     dynamic mulitType = Dynamic.GetValue(1, "Hello", 3.14); // This will return an error message because the types are mixed and not the same.

        //     Console.WriteLine($"intResult : {intResult}");     // 6
        //     Console.WriteLine($"stringResult : {stringResult}");  // Rianchal Chirag Sumit
        //     Console.WriteLine($"doubleResult : {doubleResult}");  // 4.0
        //     Console.WriteLine($"mulitTypeData : {mulitType}");  // Error: Mixed types pass kiye hain!


        // Console.WriteLine("\n----Constructors-----");  
        //    Constructors.Run(); // This will call the Main method of the Constructors class, which demonstrates the use of constructors in C#.


        // Console.WriteLine("\n----This Keyword-----");  
        // This_Keyword.Run(); // This will call the Run method of the This_Keyword class, which demonstrates the use of the 'this' keyword in C#.


        // Console.WriteLine("\n---- StaticVSInstance -----");
        // StaticVSInstance.Run(); 

        // Console.WriteLine("\n---- Access Modifiers -----");
        // Access_Modifiers.Run();

        // Console.WriteLine("\n----Getters and Setters -----"); 
        // Getters_Setters.Run(); // This will call the Run method of the Getters_Setters class, which demonstrates the use of properties (getters and setters) in C#. 

        // Console.WriteLine("\n---- Encapsulation  -----"); 
        // Encapsulation.Run(); // This will call the Run method of the Encapsulation class, which demonstrates the concept of encapsulation in C#. In this example, we have a private field 'age' in the Student2 class, and we are using a public property 'Age' to access and modify that private field. This way, we are hiding the internal implementation details of the Student2 class and providing controlled access to the age data through the Age property.

        // Console.WriteLine("\n---- Inheritance  -----"); 
        // Inheritance.Run(); // This will call the Run method of the Inheritance class, which demonstrates the concept of inheritance in C#. In this example, we have a base class 'Person' with a property 'name' and a method 'ShowName'. The 'Student3' class inherits from the 'Person' class, which means it can access the 'name' property and the 'ShowName' method. Additionally, the 'Student3' class has its own property 'roll' and a method 'ShowRoll'. In the Run method, we create an instance of Student3, set the inherited name property, and call both the ShowName and ShowRoll methods to display the name and roll number of the student.

        // Console.WriteLine("\n---- Polymorphism  -----");
        // Polymorphism.Run(); // This will call the Run method of the Polymorphism class, which demonstrates both compile-time and runtime polymorphism in C#. In this example, we have two methods named 'Add' with different parameters, which is an example of compile-time polymorphism (method overloading). We also have a base class 'Animal' with a virtual method 'Speak', and two derived classes 'Dog' and 'Cat' that override the Speak method, which is an example of runtime polymorphism (method overriding). In the Run method, we create instances of Dog and Cat and call their Speak methods to demonstrate how the overridden methods are called at runtime based on the actual object type.

        // Console.WriteLine("\n---- Abstraction  -----");
        // Abstraction.Run();

        // Console.WriteLine("\n---- Exception Handling  -----");
        // ExceptionHandling.Run();

        // Console.WriteLine("\n---- Collections  -----");
        // Collections.Run();

        // Console.WriteLine("\n---- Generics  -----");
        // Generics.Run();

        // Console.WriteLine("\n---- Delegates  -----");    
        // Delegates.Run(); 
        // Delegates_2.Run();
        // Delegates_Practice.Run();

        // Console.WriteLine("\n---- Lambda Expressions  -----");
        // LambdaDemo.Run();

        // Console.WriteLine("\n---- Linq -----");
        // LINQ.Run();

        // Console.WriteLine("\n---- Async/Await  -----");
        // AsyncAwaitDemo.Run();

        Console.WriteLine("\n---- Practice  -----");
        Practice.Run();

    
    }
}