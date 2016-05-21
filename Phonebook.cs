using System;
using System.Collections.Generic;

public class Phonebook
{
    public static void Main()
    {
        string input = Console.ReadLine();
        Dictionary<string, string> phonebook = new Dictionary<string, string>();

        while (input != "search")
        {
            string[] info = input.Split(new[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
            string name = info[0];
            string phone = info[1];

            if (!phonebook.ContainsKey(name))
            {
                phonebook.Add(name, phone);
            }
            phonebook[name] = phone;
            input = Console.ReadLine();
        }
        input = Console.ReadLine();
        while (input != "stop")
        {
            string searchedName = input;
            if (phonebook.ContainsKey(searchedName))
            {
                Console.WriteLine($"{searchedName} -> {phonebook[searchedName]}");
            }
            else
            {
                Console.WriteLine($"Contact {searchedName} does not exist.");
            }
            input = Console.ReadLine();
        }
    }
}

