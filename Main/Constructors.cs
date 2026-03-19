#pragma warning disable // to ignore warnings in this file, you can remove it if you want to see warnings.
using System;
class Student
{
    public int Id;
    public string Name;

    // ------------------------------------------------
    // 1️.  Default Constructor
    // - No parameters
    // - Automatically called when object is created
    // - Same concept exists in Java
    // ------------------------------------------------
    public Student()
    {
        Console.WriteLine("Default constructor called");
    }


    // ------------------------------------------------
    // 2️. Parameterized Constructor
    // - Used to initialize values during object creation
    // - Same as Java
    // ------------------------------------------------
    public Student(int id, string name)
    {
        Console.WriteLine("Parameterized constructor called : ");
        Id = id; // 'this' keyword is used to refer to the current object's members, it helps to differentiate between local variables and class members when they have the same name. In this case, it assigns the value of the parameter 'Id' to the class member 'Id' of the current object. which mean 
        Name = name;
    }


    // ------------------------------------------------
    // 3️. Copy Constructor
    // - Creates a new object using another object's data
    // - C# supports it easily
    // - Java doesn't have built-in copy constructor concept
    // ------------------------------------------------
    public Student(Student s)
    {
        Console.WriteLine("Copy constructor called");
        Id = s.Id;
        Name = s.Name;
    }


    // ------------------------------------------------
    // 4️. Static Constructor
    // - Runs ONLY ONCE when class is loaded
    // - Cannot take parameters
    // - Cannot use access modifier
    // - Mostly used for initializing static data
    // ------------------------------------------------
    static Student()
    {
        Console.WriteLine("Static constructor executed");
    }


    // ------------------------------------------------
    // 5️. Private Constructor
    // - Prevents object creation from outside the class
    // - Used in Singleton pattern
    // ------------------------------------------------
    private Student(string secret)
    {
        Console.WriteLine("Private constructor called");
    }


    public void Display()
    {
        Console.WriteLine($"Id: {Id}, Name: {Name}");
    }
}



class Constructors
{
    public static void Run()
    {
        // Default constructor
        Student s1 = new Student();

        // Parameterized constructor
        Student s2 = new Student(101, "Chirag");
        s2.Display();

        // Copy constructor
        Student s3 = new Student(s2);
        s3.Display();

        // Private constructor cannot be accessed outside class
        // Student s4 = new Student("secret"); ❌ ERROR
    }
}