using System;
using System.Text.RegularExpressions;

public class ReplaceATag
{
    public static void Main()
    {
        string input = Console.ReadLine();
        string pattern = string.Format(@"<a\s*href=""(.*?)"">(.*?)<\/a>");
        Regex regex = new Regex(pattern);

        while (input != "end")
        {
            Match match = regex.Match(input);
            string replacement = string.Format($@"[URL href=""{match.Groups[1]}""]{match.Groups[2]}[/URL]");
            input = regex.Replace(input, replacement);
            Console.WriteLine(input);
            input = Console.ReadLine();
        }
    }
}