using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

public class JediCode
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        StringBuilder allText = new StringBuilder();

        for (int i = 0; i < n; i++)
        {
            string input = Console.ReadLine();
            allText.Append(input);
        }
        string firstPattern = Console.ReadLine();
        string secondPattern = Console.ReadLine();
        int[] numbers = Console.ReadLine()
            .Trim()
            .Split(new[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();


        string firstPat = $@"{BuildPattern(firstPattern)}([A-Za-z]{{{firstPattern.Length}}})(?![a-zA-Z])";
        string secondPat = $@"{BuildPattern(secondPattern)}([A-Za-z0-9]{{{secondPattern.Length}}})(?![a-zA-Z0-9])";
        var jedai = new List<string>();
        var messages = new List<string>();
        messages.Add("");
        MatchCollection first = Regex.Matches(allText.ToString(), firstPat);
        foreach (Match match in first)
        {
            jedai.Add(match.Groups[1].Value);
        }
        MatchCollection second = Regex.Matches(allText.ToString(), secondPat);
        foreach (Match match in second)
        {
            messages.Add(match.Groups[1].Value);
        }
        //Print messages 
        int counter = 0;

        for (int i = 0; i < numbers.Length; i++)
        {
            try
            {
                Console.WriteLine($"{jedai[counter++]} - {messages[numbers[i]]}");
            }
            catch (Exception)
            {
                counter--;
                continue;
            }
        }
    }

    private static string BuildPattern(string firstPattern)
    {
        StringBuilder result = new StringBuilder();
        for (int i = 0; i < firstPattern.Length; i++)
        {
            if (firstPattern[i] == '.' || firstPattern[i] == '-' || firstPattern[i] == '+' || firstPattern[i] == '*'
                || firstPattern[i] == '\\' || firstPattern[i] == '?' || firstPattern[i] == '(' || firstPattern[i] == ')'
                || firstPattern[i] == '|' || firstPattern[i] == '[' || firstPattern[i] == ']' || firstPattern[i] == '{'
                || firstPattern[i] == '}' || firstPattern[i] == '^' || firstPattern[i] == '$' || firstPattern[i] == '/')
            {
                result.Append("\\");
            }
            result.Append(firstPattern[i]);
        }
        return result.ToString();
    }
}