using System;
using System.Collections.Generic;
using System.Linq;

public class Student
{
    public string firstName { get; set; }
    public string secondName { get; set; }
    public List<int> marks { get; set; }
}
public class WeakStudents
{
    public static void Main()
    {
        string input = Console.ReadLine();
        List<Student> allStudents = new List<Student>();
        while (input != "END")
        {
            string[] studentInfo = input.Split();
            Student newStudent = new Student();
            newStudent.firstName = studentInfo[0];
            newStudent.secondName = studentInfo[1];
            List<int> allMarks = new List<int>();
            for (int i = 2; i < studentInfo.Length; i++)
            {
                allMarks.Add(int.Parse(studentInfo[i]));
            }
            newStudent.marks = allMarks;
            allStudents.Add(newStudent);
            input = Console.ReadLine();
        }
        var sortedStudents = allStudents.Where(x => x.marks.Count(mark => mark <= 3) >= 2).ToList();

        foreach (var student in sortedStudents)
        {
            Console.WriteLine($"{student.firstName} {student.secondName}");
        }
    }
}