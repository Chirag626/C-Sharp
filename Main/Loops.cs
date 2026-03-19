using System;

class Loops
{
   public  static void Run()
    {
        // In C# printing is done using Console.WriteLine()
        // Java equivalent → System.out.println()

        // =================================
        // FOR LOOP
        // =================================

        Console.WriteLine("For Loop:");

        // Syntax is exactly same as Java
        for (int i = 1; i <= 5; i++)
        {
            Console.WriteLine(i);  // prints numbers from 1 to 5
        }

        Console.WriteLine();


        // =================================
        // WHILE LOOP
        // =================================

        Console.WriteLine("While Loop:");

        int j = 1;

        // Same concept as Java while loop
        while (j <= 5)
        {
            Console.WriteLine(j);
            j++;   // increment
        }

        Console.WriteLine();


        // =================================
        // DO WHILE LOOP
        // =================================

        Console.WriteLine("Do While Loop:");

        int k = 1;

        // Runs at least once even if condition becomes false
        do
        {
            Console.WriteLine(k);
            k++;
        }
        while (k <= 5);

        Console.WriteLine();


        // =================================
        // FOREACH LOOP WITH ARRAY
        // =================================

        Console.WriteLine("Foreach Loop:");

        // Array declaration in C#
        // Same concept as Java

        string[] names = { "Sumit", "Rianchal", "Chirag" };

        // Java foreach syntax
        // for(String name : names)

        // C# uses "in"
        foreach (string name in names)
        {
            Console.WriteLine(name);
        }

        Console.WriteLine();

        

        // =================================
        // BREAK EXAMPLE
        // =================================

        Console.WriteLine("Break Example:");

        for (int x = 1; x <= 5; x++)
        {
            if (x == 3)
            {
                break; // stops loop completely
            }

            Console.WriteLine(x);
        }

        Console.WriteLine();


        // =================================
        // CONTINUE EXAMPLE
        // =================================

        Console.WriteLine("Continue Example:");

        for (int y = 1; y <= 5; y++)
        {
            if (y == 3)
            {
                continue; // skips this iteration
            }

            Console.WriteLine(y);
        }
    }
}