using System;
using System.Collections.Generic;

public class PeriodicTable
{
    public static void Main()
    {
        //You are given an n number of chemical compounds.You need to keep track of all chemical elements 
        //used in the compounds and at the end print all unique ones in ascending order:
        int n = int.Parse(Console.ReadLine());
        SortedSet<string> sortRadioactiveElements = new SortedSet<string>();

        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine().Split();
            for (int j = 0; j < input.Length; j++)
            {
                sortRadioactiveElements.Add(input[j]);
            }
        }
        foreach (string element in sortRadioactiveElements)
        {
            Console.Write(element + " ");
        }
        Console.WriteLine();
    }
}

