using System;

class Student1
{
    public int Id;
    public string Name;
    public int Marks;

    static int count = 1;
    // Parameterized constructor
    public Student1(int Id, string Name)
    {
        Console.WriteLine("Parameterized Constructor Called "+ count++);

        // using this to differentiate
        this.Id = Id;
        this.Name = Name;
    }

    // Default constructor calling another constructor
    public Student1() : this(0, "Unknown") // here we are calling the parameterized constructor with default values, so when we create an object using default constructor, it will call the parameterized constructor with these default values and initialize the object accordingly.
    {
        
        Console.WriteLine("Default Constructor Called");
    }

    // Method returning current object
    public Student1 AddMarks(int m)
    {
        Marks += m;
        return this;
    }

    // Passing current object
    public void Show()
    {
        Print(this);
    }

    public static void Print(Student1 s)
    {
        Console.WriteLine($"Id: {s.Id}");
        Console.WriteLine($"Name: {s.Name}");
        Console.WriteLine($"Marks: {s.Marks}");
        Console.WriteLine();
    }
}

class This_Keyword
{
    public static void Run()
    {
        // object creation
        Student1 s = new Student1(101, "Chirag");

        // method chaining
        s.AddMarks(10).AddMarks(20).AddMarks(30);

        // passing current object
        s.Show();

        // calling default constructor
        Student1 s2 = new Student1();
        s2.Show();
    }
}

