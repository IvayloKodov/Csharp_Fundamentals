using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Person
{
    public string name { get; set; }
    public int group { get; set; }
}

public class GroupByGroup
{
    public static void Main()
    {
        string input = Console.ReadLine();
        List<Person> allPersons = new List<Person>();
        while (input != "END")
        {
            string[] info = input.Split();
            Person newPerson = new Person();
            newPerson.name = $"{info[0]} {info[1]}";
            newPerson.group = int.Parse(info[2]);
            allPersons.Add(newPerson);
            input = Console.ReadLine();
        }
        var sortedByGroup = allPersons
            .GroupBy(x => x.group)
            .OrderBy(x=>x.Key).ToList();

        foreach (var itemGroup in sortedByGroup)
        {
            Console.Write("{0} - ", itemGroup.Key);
            List<string> grouppedPersons = new List<string>();
            foreach (var person in itemGroup)
            {
                grouppedPersons.Add(person.name);
            }
            Console.WriteLine(string.Join(", ",grouppedPersons));
        }
    }
}