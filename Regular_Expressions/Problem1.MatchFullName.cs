using System;
using System.Text.RegularExpressions;

public class MatchFullName
{
    public static void Main()
    {
        string input = Console.ReadLine();
        Regex regex = new Regex(@"\b[A-Z][a-z]+\s[A-Z][a-z]+\b");

        while (input != "end")
        {
            Match match = regex.Match(input);
            if (match.Success)
            {
                Console.WriteLine(match.Groups[0]);
            }
            input = Console.ReadLine();
        }
    }
}