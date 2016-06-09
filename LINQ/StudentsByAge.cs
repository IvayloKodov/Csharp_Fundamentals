using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Students
{
    public string firstName { get; set; }
    public string secondName { get; set; }
    public string age { get; set; }
}

public class StudentsByAge
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
            .Where(x => int.Parse(x[2]) >= 18 && int.Parse(x[2]) <= 24)
            .ToList();
        foreach (var student in sortedStudents)
        {
            Console.WriteLine($"{student[0]} {student[1]} {student[2]}");
        }
    }
}

