using System;
using System.Collections.Generic;
using System.Linq;

public class StudentsByFirstAndLastName
{
    public static void Main()
    {
        string input = Console.ReadLine();
        var result = new List<string>();

        while (input != "END")
        {
            result.Add(input);
            input = Console.ReadLine();
        }

        var sorted = result.Select(x => x.Split())
            .Where(x => x[0].CompareTo(x[1]) < 0)
            .ToList();
        foreach (var name in sorted)
        {
            Console.WriteLine($"{name[0]} {name[1]}");
        }
    }
}