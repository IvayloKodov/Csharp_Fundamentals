using System;
using System.Collections.Generic;

public class CountSymbols
{
    public static void Main()
    {
        //Write a program that reads some text from the console and counts the occurrences of each character 
        //in it.Print the results in alphabetical(lexicographical) order.

        SortedDictionary<char, int> charCounter = new SortedDictionary<char, int>();
        string text = Console.ReadLine();

        for (int i = 0; i < text.Length; i++)
        {
            char currentChar = text[i];

            if (!charCounter.ContainsKey(currentChar))
            {
                charCounter.Add(currentChar, 0);
            }
            charCounter[currentChar]++;
        }
        foreach (var kvp in charCounter)
        {
            Console.WriteLine($"{kvp.Key}: {kvp.Value} time/s");
        }
    }
}

