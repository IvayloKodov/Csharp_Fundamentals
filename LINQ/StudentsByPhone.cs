using System;
using System.Collections.Generic;
using System.Linq;

public class Student
{
    public string firstName { get; set; }
    public string secondName { get; set; }
    public string phone { get; set; }
}

public class StudentsByPhone
{
    public static void Main()
    {
        string input = Console.ReadLine();
        var allStudents = new List<Student>();
        while (input != "END")
        {
            string[] studentInfo = input.Split();
            var newStudent = new Student();
            newStudent.firstName = studentInfo[0];
            newStudent.secondName = studentInfo[1];
            newStudent.phone = studentInfo[2];
            allStudents.Add(newStudent);
            input = Console.ReadLine();
        }
        var sortedStudents =
            allStudents.Where(student => student.phone.StartsWith("02") || student.phone.StartsWith("+3592"))
                        .ToList();

        foreach (var student in sortedStudents)
        {
            Console.WriteLine($"{student.firstName} {student.secondName}");
        }
    }
}

