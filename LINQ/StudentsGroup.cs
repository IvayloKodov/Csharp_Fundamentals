using System;
using System.Collections.Generic;
using System.Linq;

public class StudentsGroup
{
    public static void Main()
    {
        string input = Console.ReadLine();
        List<string> persons = new List<string>();
        while (input != "END")
        {
            persons.Add(input);
            input = Console.ReadLine();
        }

        var sorted = persons.Select(x => x.Split())
             .Where(x => x[2] == "2")
             .OrderBy(x => x[0]).ToList();
        foreach (var person in sorted)
        {
            Console.WriteLine($"{person[0]} {person[1]}");
        }
    }
}