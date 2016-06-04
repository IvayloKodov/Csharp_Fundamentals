using System;
using System.Text.RegularExpressions;

public class MatchPhoneNumber
{
    public static void Main()
    {
        string input = Console.ReadLine();
        Regex regex = new Regex(@"(\s*\+359-2-\d{3,3}-\d{4}$)|(\s*\+359 2 \d{3} \d{4}$)");

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

