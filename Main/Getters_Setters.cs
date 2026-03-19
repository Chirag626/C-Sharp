
#pragma warning disable

using System;
class Student_1
{
    // 1️⃣ Normal Property (Read + Write)
    public int Id { get; set; }
    
    private string _name;
    public string Name { get => _name; set => _name = value; } // or public string Name { get; set; } with auto-implemented property

    // 2️⃣ Read Only Property
    public string College { get; } = "ABC University";

    // 3️⃣ Private Setter (can modify only inside class)
    public int Age { get; private set; }

    // 4️⃣ Write Only Property
    private int marks;
    public int Marks
    {
        set { marks = value; }
    }

    // 5️⃣ Property with Validation
    private int percentage;
    public int Percentage
    {
        get { return percentage; }
        set
        {
            if (value >= 0 && value <= 100)
                percentage = value;
            else
                Console.WriteLine("Invalid Percentage");
        }
    }

    // 6️⃣ Expression Bodied Property
    public bool IsPassed => percentage >= 40;

    // Constructor
    public Student_1(int id, int age)
    {
        Id = id;
        Age = age;
    }
}

class Getters_Setters
{
    public static void Run()
    {
        Student_1 s = new Student_1(101, 22)
        {
            Name = "Chirag", // using the Name property to set the name of the student
            Marks = 90,         // write only property or s.Marks = 90; // This will set the value of marks to 90 using the write-only property Marks.
            Percentage = 85     // validation property
        };
        // s.College = "ITM"; // This will give an compile time error bcz It is a read-only property, so we can only read its value but cannot modify it. The value of College property is set to "ABC University" by default in the class definition, and it cannot be changed from outside the class. 
        
        Console.WriteLine("Name: " + s.Name); // using the Name property to get the name of the student
        Console.WriteLine("Id: " + s.Id);
        Console.WriteLine("College: " + s.College);
        Console.WriteLine("Age: " + s.Age);
        Console.WriteLine("Percentage: " + s.Percentage);
        Console.WriteLine("Passed: " + s.IsPassed);
    }
}

