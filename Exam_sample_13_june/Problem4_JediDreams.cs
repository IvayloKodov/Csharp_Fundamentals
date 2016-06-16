using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public class JediDreams
{
    public static void Main()
    {
        
        string pattern = @"([a-zA-Z]*[A-Z]+[a-zA-Z]*)\s*\(";
        Regex regex = new Regex(pattern);
        var jediCounter = new Dictionary<string, List<string>>();
        string key = "";

        int lines = int.Parse(Console.ReadLine());

        for (int i = 0; i < lines; i++)
        {
            string input = Console.ReadLine();

            if (input.Contains(" static "))
            {
                Match match = regex.Match(input);
                key = match.Groups[1].Value;
                jediCounter.Add(key, new List<string>());
            }
            else
            {
                MatchCollection matchCollection = regex.Matches(input);
                foreach (Match match in matchCollection)
                {
                    jediCounter[key].Add(match.Groups[1].Value);
                }
            }
        }

        var sortedByCount = jediCounter.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key);
        foreach (var method in sortedByCount)
        {
            if (method.Value.Count > 0)
            {
                Console.Write($"{method.Key} -> {method.Value.Count} -> ");
                var sortedInvokeMethods = method.Value.OrderBy(x => x);
                Console.WriteLine(string.Join(", ", sortedInvokeMethods));
            }
            else
            {
                Console.WriteLine($"{method.Key} -> None");
            }
        }
    }
}