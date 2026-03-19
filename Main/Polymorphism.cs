using System;

class Calculator
{
    // ---------------------------------------------------
    // METHOD OVERLOADING (Compile-time polymorphism)
    // Same method name but different parameters
    // Compiler decides which method to call
    // Same concept exists in Java
    // ---------------------------------------------------

    public int Add(int a, int b)
    {
        return a + b;
    }

    public double Add(double a, double b)
    {
        return a + b;
    }

    public int Add(int a, int b, int c)
    {
        return a + b + c;
    }
}


// ---------------------------------------------------
// RUNTIME POLYMORPHISM (Method Overriding)
// Uses inheritance
// Parent method must be 'virtual'
// Child method must be 'override'
// In Java you don't need 'virtual'
// ---------------------------------------------------

class Shape
{
    // Virtual — child class override kar sakti hai
    public virtual double GetArea()
    {
        return 0;
    }

    public virtual void PrintInfo()
    {
        Console.WriteLine("I am a Shape");
    }
}

class Circle : Shape
{
    public double Radius { get; set; }

    public Circle(double radius)
    {
        Radius = radius;
    }

    public override double GetArea()
    {
        return Math.PI * Radius * Radius;
    }

    public override void PrintInfo()
    {
        Console.WriteLine($"Circle — Radius: {Radius}, Area: {GetArea():F2}");
    }
}

class Rectangle : Shape
{
    public double Width { get; set; }
    public double Height { get; set; }

    public Rectangle(double width, double height)
    {
        Width = width;
        Height = height;
    }

    public override double GetArea()
    {
        return Width * Height;
    }

    public override void PrintInfo()
    {
        Console.WriteLine($"Rectangle — Width: {Width}, Height: {Height}, Area: {GetArea():F2}");
    }
}

class Triangle : Shape
{
    public double Base { get; set; }
    public double Height { get; set; }

    public Triangle(double base_, double height)
    {
        Base = base_;
        Height = height;
    }

    public override double GetArea()
    {
        return 0.5 * Base * Height;
    }

    public override void PrintInfo()
    {
        Console.WriteLine($"Triangle — Base: {Base}, Height: {Height}, Area: {GetArea():F2}");
    }
}


class Polymorphism
{
    public static void Run()
    {
        // -------------------------------
        // Compile-time Polymorphism
        // -------------------------------

        Console.WriteLine("----- Compile-time Polymorphism -----");
        Calculator c = new Calculator();

        Console.WriteLine("Int Version : " + c.Add(5, 3));          // int version
        Console.WriteLine("Double Version : " + c.Add(2.5, 3.5));   // double version
        Console.WriteLine("3 Parameter Version : " + c.Add(10, 20, 30)); // 3 parameter version

        Console.WriteLine();

        // -------------------------------
        // Runtime Polymorphism
        // Parent reference → different objects
        // -------------------------------

        Console.WriteLine("----- Runtime Polymorphism -----");
        Shape shape;

        shape = new Circle(5);
        shape.PrintInfo();      // Circle version executes

        shape = new Rectangle(4, 6);
        shape.PrintInfo();      // Rectangle version executes

        shape = new Triangle(3, 8);
        shape.PrintInfo();      // Triangle version executes

        Console.WriteLine();

        // -------------------------------
        // Real Power — List mein alag alag shapes
        // Ek loop mein sab handle!
        // -------------------------------

        Console.WriteLine("----- Polymorphism using Collections -----");
        var shapes = new List<Shape>
        {
            new Circle(7),
            new Rectangle(5, 10),
            new Triangle(4, 9)
        };

        foreach (var s in shapes)
        {
            s.PrintInfo();  // Automatically sahi version chalega
        }
    }
}