using System;
using System.Linq;

public class LegoBlocks
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[][] firstArray = new int[n][];
        int[][] secondArray = new int[n][];
        //Fill first array
        for (int i = 0; i < n; i++)
        {
            firstArray[i] = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        }
        //Fill second array
        for (int i = 0; i < n; i++)
        {
            secondArray[i] = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        }

        //Compare the lengths of the arrays 
        bool isLegoBlocks = true;
        int squareIndex = firstArray[0].Length + secondArray[0].Length;

        for (int i = 1; i < n; i++)
        {
            if (firstArray[i].Length + secondArray[i].Length != squareIndex)
            {
                isLegoBlocks = false;
            }
        }

        //Print the result
        if (isLegoBlocks)
        {
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("[{0}, {1}]",
                string.Join(", ", firstArray[i]), string.Join(", ", secondArray[i].Reverse()));
            }
        }
        else
        {
            int counter = 0;
            for (int i = 0; i < n; i++)
            {
                counter += firstArray[i].Length;
                counter += secondArray[i].Length;
            }
            Console.WriteLine($"The total number of cells is: {counter}");
        }
    }
}

