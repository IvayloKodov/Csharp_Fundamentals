using System;
using System.Text.RegularExpressions;

public class SentenceExtractor
{
    public static void Main()
    {
        string word = Console.ReadLine();
        string text = Console.ReadLine();

        string pattern = $@"[A-Za-z0-9\s]+\b{word}\b[A-Za-z0-9\s]*[!|.|?]";
        Regex regex = new Regex(pattern);
        MatchCollection match = regex.Matches(text);
        foreach (Match sentence in match)
        {
            Console.WriteLine(sentence);
        }
    }
}