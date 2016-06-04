using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class ValidUsernames
{
    public static void Main()
    {
        //Console.SetIn(new StreamReader(Console.OpenStandardInput(8192)));
        string pattern = @"(?<=^|\s|\\|\/|,|\()\b[A-Za-z]\w{1,24}\b";
        Regex regex = new Regex(pattern);
        List<string> allMatches = new List<string>();
        string input = Console.ReadLine();
        MatchCollection match = regex.Matches(input);
        foreach (Match word in match)
        {
            allMatches.Add(word.Groups[0].Value);
        }
        int maxSum = 0;
        string firstWord = "";
        string secondWord = "";
        for (int i = 0; i < allMatches.Count - 1; i++)
        {
            int sum = 0;
            sum = allMatches[i].Length + allMatches[i + 1].Length;
            if (sum > maxSum)
            {
                maxSum = sum;
                firstWord = allMatches[i];
                secondWord = allMatches[i + 1];
            }
        }
        Console.WriteLine($"{firstWord}\n{secondWord}");
    }
}