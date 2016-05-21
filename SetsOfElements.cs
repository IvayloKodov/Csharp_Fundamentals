using System;
using System.Collections.Generic;
using System.Linq;

public class ProSetsOfElementsgram
{
    public static void Main()
    {
        //On the first line you are given the length of two sets n and m.On the next n +m lines there are n numbers 
        //that are in the first set and m numbers that are in the second one.Find all non - repeating element that 
        //appears in both of them, and print them at the console:

        int[] lenghts = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
        HashSet<int> firstSet = new HashSet<int>();
        HashSet<int> secondSet = new HashSet<int>();

        for (int i = 0; i < lenghts[0] + lenghts[1]; i++)
        {
            int number = int.Parse(Console.ReadLine());
            if (i < lenghts[0])
            {
                firstSet.Add(number);
            }
            else
            {
                secondSet.Add(number);
            }
        }
        foreach (int number in firstSet.Intersect(secondSet))
        {
            Console.Write(number + " ");
        }
        Console.WriteLine();
    }
}

