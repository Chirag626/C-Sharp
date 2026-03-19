using System;

class AccessDemo
{
    private int privateVar = 1;                 // only inside this class
    protected int protectedVar = 2;             // class + child class
    internal int internalVar = 3;               // same assembly/project
    protected internal int protectedInternalVar = 4; // child OR same assembly
    public int publicVar = 5;                   // accessible everywhere

    public void Show()
    {
        Console.WriteLine("Inside AccessDemo class:");
        Console.WriteLine(privateVar);
        Console.WriteLine(protectedVar);
        Console.WriteLine(internalVar);
        Console.WriteLine(protectedInternalVar);
        Console.WriteLine(publicVar);
    }
}

// Derived class
class Child : AccessDemo
{
    public void Display()
    {
        Console.WriteLine("\nInside Child class:");

        // Console.WriteLine(privateVar); ❌ not accessible

        Console.WriteLine(protectedVar);          // ✔ inherited
        Console.WriteLine(internalVar);           // ✔ same assembly
        Console.WriteLine(protectedInternalVar);  // ✔ inherited
        Console.WriteLine(publicVar);             // ✔ public
    }
}

// Another class (not inherited)
class AnotherClass
{
    public void Test()
    {
        AccessDemo obj = new AccessDemo();

        Console.WriteLine("\nInside AnotherClass:");

        // Console.WriteLine(obj.privateVar); // ❌ not accessible
        // Console.WriteLine(obj.protectedVar); ❌ not accessible

        Console.WriteLine(obj.internalVar);          // ✔ same assembly
        Console.WriteLine(obj.protectedInternalVar); // ✔ same assembly
        Console.WriteLine(obj.publicVar);            // ✔ public
    }
}

class Access_Modifiers
{
    public static void Run()
    {
        AccessDemo a = new AccessDemo();
        a.Show();

        Child c = new Child();
        c.Display();

        AnotherClass ac = new AnotherClass();
        ac.Test();
    }
}