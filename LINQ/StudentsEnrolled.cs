using System;
using System.Collections.Generic;
using System.Linq;

public class Student
{
    public string facultyNumber { get; set; }
    public List<int> marks { get; set; }
}
public class StudentsEnrolled
{
    public static void Main()
    {
        string input = Console.ReadLine();
        List<Student> allStudents = new List<Student>();
        while (input != "END")
        {
            string[] studentInfo = input.Split();
            Student newStudent = new Student();
            newStudent.facultyNumber = studentInfo[0];
            newStudent.marks = new List<int>();
            for (int i = 1; i < studentInfo.Length; i++)
            {
                newStudent.marks.Add(int.Parse(studentInfo[i]));
            }
            allStudents.Add(newStudent);
            input = Console.ReadLine();
        }

        var sortedStudents = allStudents.Where(x => x.facultyNumber.EndsWith("14") || x.facultyNumber.EndsWith("15"))
            .ToList();

        foreach (var student in sortedStudents)
        {
            Console.WriteLine(string.Join(" ", student.marks));
        }
    }
}