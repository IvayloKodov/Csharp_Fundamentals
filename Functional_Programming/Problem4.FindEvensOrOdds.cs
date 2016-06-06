using System;

public class FindEvensOrOdds
{
    public static void Main()
    {
        string[] input = Console.ReadLine().Split();
        int start = int.Parse(input[0]);
        int stop = int.Parse(input[1]);
        string command = Console.ReadLine();

        Predicate<int> even = x => x % 2 == 0;

        for (int i = start; i <= stop; i++)
        {
            if (command == "even" && even(i))
            {
                Console.Write(i+" ");
            }
            else if (command == "odd" && !even(i))
            {
                Console.Write(i+" ");
            }
        }
        Console.WriteLine();
    }
}