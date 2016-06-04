using System;
using System.Text.RegularExpressions;

public class ExtractEmails
{
    public static void Main()
    {
        string input = Console.ReadLine();
        string pattern = @"((?<=^|\s|[\\\/\,])\b[A-Za-z][\w]{1,24}\b)";
        Regex regex = new Regex(pattern);
        MatchCollection match = regex.Matches(input);
        foreach (Match mail in match)
        {
            Console.WriteLine(mail.Groups[1]);
        }
    }
}