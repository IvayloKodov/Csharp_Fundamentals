using System;
using System.Text;
using System.Text.RegularExpressions;

public class ExtractHyperlinks
{
    public static void Main()
    {
        string pattern = @"<a\s.*?href\s*=(.+?)>";
        string input = Console.ReadLine();
        StringBuilder allText = new StringBuilder();

        while (input != "END")
        {
            allText.Append(input);
            input = Console.ReadLine();
        }
        Regex regex = new Regex(pattern);
        MatchCollection matchCollection = regex.Matches(allText.ToString());

        foreach (Match match in matchCollection)
        {
            char paranthese = match.Groups[1].Value.Trim()[0];
            int invalidTags = match.Groups[1].Value.IndexOf('<');
            string extractBetweenPattern = @"^(.+?)(?:\s+|$)";
            if (paranthese.Equals('"') || paranthese.Equals('\''))
            {
                extractBetweenPattern = string.Format(@"^\s*{0}(.+?){0}", paranthese);
            }
            Regex regex2 = new Regex(extractBetweenPattern);
            Match matcher = regex2.Match(match.Groups[1].Value);
            if (invalidTags == -1)
            {
                Console.WriteLine(matcher.Groups[1].Value);
            }
        }
    }
}