using System;
using System.Collections.Generic;
using System.Linq;

public class SortStudents
{
    public static void Main()
    {
        List<string> allStudents = new List<string>();
        string input = Console.ReadLine();
        while (input != "END")
        {
            allStudents.Add(input);
            input = Console.ReadLine();
        }
        var sortedStudents = allStudents.Select(x => x.Split())
            .OrderBy(x => x[1]).ThenByDescending(x => x[0]).ToList();
        foreach (var student in sortedStudents)
        {
            Console.WriteLine($"{student[0]} {student[1]}");
        }
    }
}