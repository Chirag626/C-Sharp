using System;

    
using static Delegates_Practice; // Isse hum Delegates_Practice class ke private methods ko bhi access kar sakte hain, kyunki humne Delegates_Practice class ko static import kiya hai.
class Delegates_Practice
{
    public delegate void MyDelegate();
    public delegate String MyDelegateWithReturn(); // This is a delegate declaration. It defines a delegate type named MyDelegateWithReturn that can reference any method that has a string return type and takes no parameters.

    public static void Run()
    {
        MyDelegate del = PrivateMethod;
        del += PrivateMethod2;
        X.CallPrivateMethod(del); // This will call the CallPrivateMethod of class X and pass the Private

        MyDelegateWithReturn del2 = PrivateMethodWithReturn; 
        Console.WriteLine(del2()); // This will call the PrivateMethodWithReturn and print its return value, which is "This is a private method with return type." to the console.
        Console.WriteLine("Calling the same method using another class : "+X.CallPrivateMethodWithReturn(del2)); // This will call the CallPrivateMethodWithReturn of class X and pass the Private
    }
    private static void PrivateMethod()
    {
        Console.WriteLine("This is a private method.");
    }
    private static void PrivateMethod2()
    {
        Console.WriteLine("This is a private method 2.");
    }

    private static String PrivateMethodWithReturn()
    {
        return "This is a private method with return type.";
    }

}
class X
{
    // Practice.PrivateMethod(); // This will cause a compile-time error because PrivateMethod is a private method and cannot be accessed from outside the Practice class.
    public static void CallPrivateMethod(MyDelegate del)
    {
        del(); // This will call the method referenced by the delegate 'del', which can be the PrivateMethod of the Practice class if it is passed as an argument to this method.
    }

    public static String CallPrivateMethodWithReturn(MyDelegateWithReturn del)
    {
        return del(); // This will call the method referenced by the delegate 'del' and return its result, which can be the PrivateMethodWithReturn of the Practice class if it is passed as an argument to this method.
    }

}
