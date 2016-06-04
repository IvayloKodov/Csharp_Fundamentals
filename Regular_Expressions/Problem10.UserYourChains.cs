using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

public class UserYourChains
{
    public static void Main()
    {
        Console.SetIn(new StreamReader(Console.OpenStandardInput(8192)));
        string input = Console.ReadLine();
        string extractBetweenTags = @"<p>(.*?)<\/p>";
        Regex regex = new Regex(extractBetweenTags);
        MatchCollection match = regex.Matches(input);
        StringBuilder result = new StringBuilder();
        foreach (Match item in match)
        {
            StringBuilder currentResult = new StringBuilder();
            string text = item.Groups[1].Value;
            for (int i = 0; i < text.Length; i++)
            {
                char currentChar = text[i];
                if (char.IsLower(currentChar) || char.IsDigit(currentChar))
                {
                    currentResult.Append(currentChar);
                }
                else
                {
                    currentResult.Append(" ");
                }
            }
            for (int i = 0; i < currentResult.ToString().Length; i++)
            {
                char current = currentResult[i];
                if (!char.IsWhiteSpace(currentResult[i]))
                {
                    if (currentResult[i] >= 'a' && currentResult[i] <= 'm')//+13
                    {
                        currentResult[i] = (char)(current + 13);
                    }
                    else if (currentResult[i] >= 'n' && currentResult[i] <= 'z')
                    {
                        currentResult[i] = (char)(current - 13);
                    }
                }
            }
            result.Append(currentResult);
        }
        string finalResult = Regex.Replace(result.ToString(), "\\s+", " ");
        Console.WriteLine(finalResult);
    }
}