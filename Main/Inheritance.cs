/*
                virtual vs override — Java se comparison:
                               Java                                    C#
                1. Methods by default override ho sakti hain   1. virtual likhna zaroori hai parent mein
                2. @Override annotation                        2. Override Keyword
                
*/

#pragma warning disable
using System;
// Parent Class (Base Class)
public class Animal
{
    public string Name { get; set; }
    public int Age { get; set; }

    public Animal(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public void Eat()
    {
        Console.WriteLine($"{Name} is eating");
    }

    public virtual void Sleep()
    {
        Console.WriteLine($"base class method : {Name} is sleeping");
    }

    // Virtual — child class override kar sakti hai
    public virtual void MakeSound()
    {
        Console.WriteLine($"{Name} makes a sound");
    }
}

// Child Class — Animal ki sab cheezein milti hain
public class Dog : Animal
{
    public string Breed { get; set; }

    // base — Java mein super tha
    public Dog(string name, int age, string breed)
        : base(name, age)
    {
        Breed = breed;
    }

    // Override — apna version likhna hai OR signature same rakhna hai
    public override void MakeSound()
    {
        Console.WriteLine($"{Name} says Woof!");
    }

    public void Sleep() // Override nahi kiya, bas apna version likh diya without override keyword. This is called method hiding, and it will not override the base class method but will hide it instead. To call the base class method, you can use base.Sleep() inside the Dog class.
    {
        Console.WriteLine($"{Name} is sleeping peacefully.");
    }

    // Dog ka apna method
    public void Fetch()
    {
        Console.WriteLine($"{Name} is fetching the ball!");
    }
}

public class Cat : Animal
{
    public Cat(string name, int age) : base(name, age) { }

    public override void MakeSound()
    {
        Console.WriteLine($"{Name} says Meow!");
    }

    public override void Sleep() // Override karke apna version likh diya
    {
        base.Sleep(); // Base class ka Sleep method bhi call kar diya
        Console.WriteLine($"{Name} is sleeping on the couch.");
    }

}

// ---------------------------------------------------
// 2. MULTILEVEL INHERITANCE
// A → B → C (Chain)
// Same as Java
// ---------------------------------------------------

class Vehicle
{
    public void Start() => Console.WriteLine("Vehicle started");
}

class Car : Vehicle
{
    public void Drive() => Console.WriteLine("Car is driving");
}

class ElectricCar : Car
{
    public void Charge() => Console.WriteLine("Electric car is charging");
}


// ---------------------------------------------------
// 3. HIERARCHICAL INHERITANCE
// One parent, multiple children
// Same as Java
// ---------------------------------------------------

class Shape1
{
    public void Draw1() => Console.WriteLine("Drawing a Shape");
}

class Circle1 : Shape1
{
    public void DrawCircle1() => Console.WriteLine("Drawing a Circle");
}

class Rectangle1 : Shape1
{
    public void DrawRectangle1() => Console.WriteLine("Drawing a Rectangle");
}

class Triangle1 : Shape1
{
    public void DrawTriangle1() => Console.WriteLine("Drawing a Triangle");
}


// ---------------------------------------------------
// 4. MULTIPLE INHERITANCE — Classes se nahi hoti C# mein!
// Java mein bhi nahi hoti classes se
// Sirf Interfaces se hoti hai — dono mein same rule!
// ---------------------------------------------------

interface ISwimmable
{
    // void swim(); // Interface method — koi body nahi, bas signature
    void Swim() => Console.WriteLine("Default Swimming");   // Default implementation
}

interface IFlyable
{
    void Fly() => Console.WriteLine("Flying");      // Default implementation
}


class Fish : ISwimmable  // Implement nahi kiya. Swim method ka default implementation use karega.
{
    // no need to implement Swim() because it has a default implementation in the interface but we can implement it if we want to provide a specific behavior for Fish. For example:
    // public void Swim() => Console.WriteLine("Fish is swimming in the water");.
}
// Duck dono interfaces implement karta hai — Multiple Inheritance!
class Duck : ISwimmable, IFlyable
{
    public void Quack() => Console.WriteLine("Duck is quacking");
}


// ---------------------------------------------------
// 5. HYBRID INHERITANCE
// Mix of above types — Class + Interface
// ---------------------------------------------------

class Person
{
    public string Name { get; set; }
    public void Introduce() => Console.WriteLine($"Hi, I am {Name}");
}

interface IWorker
{
    void Work();
}

interface IStudent
{
    void Study();
}

// Employee — Person se inherit + 2 interfaces implement
class Employee : Person, IWorker, IStudent
{
    public void Work() => Console.WriteLine($"{Name} is working");
    public void Study() => Console.WriteLine($"{Name} is studying");
}


class Inheritance
{
    public static void Run()
    {
        Console.WriteLine("----- Single Inheritance Example -----");
        var dog = new Dog("Bruno", 3, "Labrador");
        dog.Eat();         // Animal ka method — Bruno is eating
        dog.MakeSound();   // Dog ka override — Bruno says Woof!
        dog.Fetch();       // Dog ka apna — Bruno is fetching the ball!
        dog.Sleep();       // Dog ka apna Sleep method — Bruno is sleeping peacefully.

        var cat = new Cat("Whiskers", 2);
        cat.MakeSound();   // Whiskers says Meow!
        cat.Sleep();       // Cat ka apna Sleep method — Whiskers is sleeping on the couch.


        Console.WriteLine("\n===== 2. MULTILEVEL INHERITANCE =====");
        var eCar = new ElectricCar();
        eCar.Start();   // Vehicle ka method
        eCar.Drive();   // Car ka method
        eCar.Charge();  // ElectricCar ka method

        Console.WriteLine("\n===== 3. HIERARCHICAL INHERITANCE =====");
        var circle = new Circle1();
        var rectangle = new Rectangle1();
        var triangle = new Triangle1();
        circle.Draw1();             // Shape ka method
        circle.DrawCircle1();       // Circle ka method
        rectangle.Draw1();          // Shape ka method
        rectangle.DrawRectangle1(); // Rectangle ka method
        triangle.DrawTriangle1();   // Triangle ka method

        Console.WriteLine("\n===== 4. MULTIPLE INHERITANCE (Interfaces) =====");
       // ✅ Fish — Interface reference chahiye kyunki implement nahi ki
        ISwimmable fish = new Fish();
        fish.Swim();        // Swimming — default

// Agar Fish class mein Swim method implement kar dete to wo apna version execute karta instead of default. For example, agar Fish class mein ye method add kar dete:
        // Fish fish1 = new Fish();
        // fish1.Swim();          // Fish is swimming in the water — apna override
        
        Console.WriteLine();

        // ✅ Duck — Interface reference chahiye kyunki implement nahi ki
        ISwimmable swimmingDuck = new Duck();
        swimmingDuck.Swim();   // Swimming — default

        IFlyable flyingDuck = new Duck();
        flyingDuck.Fly();      // Flying — default

        // Quack ke liye Duck reference chahiye
        Duck duck = new Duck();
        duck.Quack();          // Duck is quacking


        Console.WriteLine();

        // ❌ Yeh nahi chalega — Error aayega
        // duck.Swim();   // Duck ne implement nahi ki
        // duck.Fly();    // Duck ne implement nahi ki


        Console.WriteLine("\n===== 5. HYBRID INHERITANCE =====");
        var emp = new Employee { Name = "Chirag" };
        emp.Introduce();  // Person ka method
        emp.Work();       // IWorker ka method
        emp.Study();      // IStudent ka method
    }
}


// -------------------------------------------------------
// QUICK SUMMARY
// -------------------------------------------------------
// Type           | Structure              | C# Support
// ---------------|------------------------|------------------
// Single         | A → B                  | ✅ Classes
// Multilevel     | A → B → C              | ✅ Classes
// Hierarchical   | A → B, A → C           | ✅ Classes
// Multiple       | A + B → C              | ✅ Interfaces only
// Hybrid         | Mix of above           | ✅ Class + Interface
// ---------------------------------------------------------------