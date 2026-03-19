#pragma warning disable // to ignore warnings in this file, you can remove it if you want to see warnings.
public class MathHelper
{
    // Static — class ka hai, object banana nahi padta
    public static double Pi = 3.14159;

    public static int Square(int n) => n * n;

    // Instance — object banana padega use karne ke liye
    public string LastOperation { get; set; }

    public int AddAndRemember(int a, int b)
    {
        LastOperation = $"{a} + {b}";
        return a + b;
    }
}
class StaticVSInstance
{
    public static void Run()

    {
        // Static — directly class se
        Console.WriteLine(MathHelper.Pi);           // 3.14159
        Console.WriteLine(MathHelper.Square(5));    // 25

        // Instance — object banana padega
        var math = new MathHelper();
        Console.WriteLine(math.AddAndRemember(3, 4));   // 7
        Console.WriteLine(math.LastOperation);           // 3 + 4
    }
}