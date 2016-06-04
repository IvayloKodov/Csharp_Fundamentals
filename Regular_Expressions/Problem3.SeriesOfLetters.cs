using System;
using System.Text.RegularExpressions;

public class SeriesOfLetters
{
    public static void Main()
    {
        string input = Console.ReadLine();
        string pattern;
        Regex regex;
        string replacement;

        for (int i = 0; i < input.Length; i++)
        {
            pattern = string.Format($@"{input[i]}+");
            replacement = string.Format($@"{input[i]}");
            regex = new Regex(pattern);
            input = regex.Replace(input, replacement);
        }
        Console.WriteLine(input);
    }
}