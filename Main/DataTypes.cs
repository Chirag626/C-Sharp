public class DataTypes
{
    public  static void Run()
    {
        // data - types 
        int age = 21;
        long l = 1234567890123456789L;
        float pi = 3.14f;
        double price = 99.99;
        decimal salary = 50000.75m;
        bool isStudent = true;
        string name = "Chirag";
        char grade = 'A';
        uint x = 123; // unsigned integer, can only hold non-negative values (0 and positive integers)
        ulong y = 12345678901234567890UL; // unsigned long, can only hold non-negative values (0 and positive integers)

        Console.WriteLine($"Name: {name}");
        Console.WriteLine($"Age: {age}");
        Console.WriteLine($"Long Value: {l}");
        Console.WriteLine($"Pi: {pi}");
        Console.WriteLine($"Decimal Salary: {salary}");
        Console.WriteLine($"Price: {price}");
        Console.WriteLine($"Is Student: {isStudent}");
        Console.WriteLine($"Grade: {grade}");
        Console.WriteLine($"Unsigned Integer: {x}");
        Console.WriteLine($"Unsigned Long: {y}");

        // var keyword : compiler automatically infers the type of the variable based on the value assigned to it. 
        // It provides a way to declare variables without explicitly specifying their types, while still maintaining strong typing and type safety.
        // var city; // error : implicitly-typed local variables must be initialized which mean "var only works when value is assigned."
        var city = "Delhi";  // must be initialized at the time of declaration, and the type of 'city' will be inferred as 'string' based on the assigned value "Delhi".
        var temperature = 30.5;
        var isRaining = false;

        Console.WriteLine($"City: {city}, Temperature: {temperature}, Is Raining: {isRaining}");
    }
}