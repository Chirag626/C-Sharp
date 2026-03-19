using System;

public class Arrays_Example
{
    public static void Run()
    {
        // RECTANGULAR ARRAY (fixed rows and columns)

        Console.WriteLine("Rectangular Array:");

        int[,] rectArray =
        {
            {1, 2, 3},
            {4, 5, 6}
        };

        // Get rows and columns
        int rows = rectArray.GetLength(0);
        int cols = rectArray.GetLength(1);

        for(int i = 0; i < rows; i++)
        {
            for(int j = 0; j < cols; j++)
            {
                Console.Write(rectArray[i, j] + " ");
            }
            Console.WriteLine();
        }

        Console.WriteLine("\nJagged Array:");

        // JAGGED ARRAY (array of arrays)

        int[][] jaggedArray = new int[2][];

        jaggedArray[0] = new int[] {1, 2, 3};
        jaggedArray[1] = new int[] {4, 5};

        // Notice second row has different size

        for(int i = 0; i < jaggedArray.Length; i++)
        {
            for(int j = 0; j < jaggedArray[i].Length; j++)
            {
                Console.Write(jaggedArray[i][j] + " ");
            }
            Console.WriteLine();
        }
    }
}