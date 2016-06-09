using System;
using System.Collections.Generic;
using System.Linq;

public class StudentsByDomain
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
            .Where(x => x[2].EndsWith("@gmail.com")).ToList();

        foreach (var student in sortedStudents)
        {
            Console.WriteLine($"{student[0]} {student[1]}");
        }
    }
}