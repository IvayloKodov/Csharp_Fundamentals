using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

public class Gunit
{
    public static void Main()
    {
        string pattern = @"^([A-Z][a-zA-Z0-9]+)\s\|\s([A-Z][a-zA-Z0-9]+)\s\|\s([A-Z][a-zA-Z0-9]+)$";
        Regex regex = new Regex(pattern);
        //         class   method  unit
        SortedDictionary<string, SortedDictionary<string, List<string>>> gUnit = new SortedDictionary<string, SortedDictionary<string, List<string>>>();

        string input = Console.ReadLine();

        while (input != "It's testing time!")
        {
            Match match = regex.Match(input);
            if (match.Success)
            {
                string className = match.Groups[1].Value;
                string methodName = match.Groups[2].Value;
                string unit = match.Groups[3].Value;

                if (!gUnit.ContainsKey(className))
                {
                    gUnit.Add(className, new SortedDictionary<string, List<string>>());
                }
                if (!gUnit[className].ContainsKey(methodName))
                {
                    gUnit[className].Add(methodName, new List<string>());
                }
                if (!gUnit[className][methodName].Contains(unit))
                {
                    gUnit[className][methodName].Add(unit);
                }
            }
            input = Console.ReadLine();
        }

        //The classes should be ordered first by the amount of unit tests it has – descending, then by the 
        //amount of methods it has – ascending, and then alphabetically.The methods should be ordered by the 
        //amount of unit tests they have - descending, and then alphabetically.The unit tests should be ordered 
        //by the length of their names – ascending and then by alphabetically.

        var sortedClasses = gUnit.OrderByDescending(x => x.Value.Select(y => y.Value.Count).Sum())
                                .ThenBy(x => x.Value.Count);

        foreach (var item in sortedClasses)
        {
            Console.WriteLine($"{item.Key}:");
            var sortedMethods = gUnit[item.Key].OrderByDescending(x => x.Value.Count);
            foreach (var method in sortedMethods)
            {
                Console.WriteLine($"##{method.Key}");
                foreach (var unit in method.Value.OrderBy(x => x.Length).ThenBy(x => x, StringComparer.Ordinal))
                {
                    Console.WriteLine($"####{unit}");
                }
            }
        }
    }
}
