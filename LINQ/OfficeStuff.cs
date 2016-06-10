using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class OfficeStuff
{
    public static void Main()
    {
        string pattern = @"^\|([A-Za-z]+) - (\d+) - ([A-Za-z]+)\|$";
        Regex regex = new Regex(pattern);
        var officeStuff = new SortedDictionary<string, Dictionary<string, int>>();

        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            string input = Console.ReadLine().Trim();
            Match match = regex.Match(input);
            if (match.Success)
            {
                string company = match.Groups[1].Value;
                int quantity = int.Parse(match.Groups[2].Value);
                string product = match.Groups[3].Value;

                if (!officeStuff.ContainsKey(company))
                {
                    officeStuff.Add(company, new Dictionary<string, int>());
                }
                if (!officeStuff[company].ContainsKey(product))
                {
                    officeStuff[company].Add(product, 0);
                }
                officeStuff[company][product] += quantity;
            }
        }
        foreach (var company in officeStuff)
        {
            Console.Write($"{company.Key}: ");
            int counter = 0;
            foreach (var product in company.Value)
            {
                if (counter == company.Value.Count - 1)
                {
                    Console.Write($"{product.Key}-{product.Value}");
                }
                else
                {
                    Console.Write($"{product.Key}-{product.Value}, ");
                }
                counter++;
            }
            Console.WriteLine();
        }
    }
}