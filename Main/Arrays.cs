class Arrays
{
    public static void Run()
    {
        // Arrays in C# are similar to Java, but they are reference types and can hold any type of data, including objects.
        // They are fixed in size once created, and they can be multidimensional.

        // Array declaration in C#
        // Same concept as Java and there are 3 ways to declare and initialize arrays in C#.

        // 1. int [] numbers = new int[5]; // declaring an array of integers with size 5

        // 2. int [] numbers = new int[] { 10, 20, 30, 40, 50 }; // declaring and initializing an array of integers

        int[] numbers = { 10, 20, 30, 40, 50 }; // 3. shorthand syntax for declaring and initializing an array
        // Java syntax is almost the same

        Console.WriteLine("Printing using FOR loop");

        // In C# we use numbers.Length
        // In Java it is numbers.length

        for (int i = 0; i < numbers.Length; i++)
        {
            Console.WriteLine(numbers[i]); // accessing elements using index
        }

        Console.WriteLine("-----");

        Console.WriteLine("Printing using FOREACH loop");

        // Java syntax:
        // for(int num : numbers)

        // C# syntax uses "in"
        foreach (int num in numbers)
        {
            Console.WriteLine(num);
        }

        Console.WriteLine("-----");

        // Example: calculating sum of array elements

        int sum = 0;

        foreach (int num in numbers)
        {
            sum += num; // adding each element to sum
        }

        Console.WriteLine("Total Sum = " + sum);



        // Multidimensional array declaration in C#
        int[,] matrix = { { 1, 2 }, { 3, 4 } };

        // Accessing elements in a multidimensional array
        Console.WriteLine(matrix[0, 0]); // Output: 1
        Console.WriteLine(matrix[0, 1]); // Output: 2
        Console.WriteLine(matrix[1, 0]); // Output: 3
        Console.WriteLine(matrix[1, 1]); // Output: 4
    }
}