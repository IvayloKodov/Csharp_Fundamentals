using System;
using System.Collections.Generic;
using System.Linq;

public class StudentSpecialty
{
    public string specialtyName { get; set; }
    public string facultyNumber { get; set; }
}

public class Student
{
    public string studentName { get; set; }
    public string facultyNumber { get; set; }
}

public class StudentsJoinedToSpecialties
{
    public static void Main()
    {
        string input = Console.ReadLine();
        List<Student> allStudents = new List<Student>();
        List<StudentSpecialty> allSpecialties = new List<StudentSpecialty>();

        while (input != "Students:")
        {
            string[] specialtyInfo = input.Trim().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            StudentSpecialty newSpecialty = new StudentSpecialty();
            newSpecialty.specialtyName = specialtyInfo[0] + " " + specialtyInfo[1];
            newSpecialty.facultyNumber = specialtyInfo[2];
            allSpecialties.Add(newSpecialty);
            input = Console.ReadLine();
        }
        input = Console.ReadLine();
        while (input != "END")
        {
            string[] studentInfo = input.Trim().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            Student newStudent = new Student();
            newStudent.facultyNumber = studentInfo[0];
            newStudent.studentName = studentInfo[1] + " " + studentInfo[2];
            allStudents.Add(newStudent);
            input = Console.ReadLine();
        }

        var query = from specialty in allSpecialties
                    join Student in allStudents on specialty.facultyNumber equals Student.facultyNumber
                    select new { Student.studentName, Student.facultyNumber, specialty.specialtyName };
        foreach (var group in query.OrderBy(x => x.studentName))
        {
            Console.WriteLine($"{group.studentName} {group.facultyNumber} {group.specialtyName}");
        }
    }
}