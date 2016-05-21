using System;
using System.Collections.Generic;

public class FixEmails
{
    public static void Main()
    {
        Dictionary<string, string> emailBook = new Dictionary<string, string>();
        List<string> allInfo = new List<string>();

        while (true)
        {
            string input = Console.ReadLine();
            if (input == "stop")
            {
                break;
            }
            allInfo.Add(input);
        }
        //Read all info and take name and email needed to fill the dictionary

        for (int line = 0; line < allInfo.Count - 1; line += 2)
        {
            string name = allInfo[line];
            string email = allInfo[line + 1];
            string patternToCheck = email.Substring(email.Length - 2).ToLower();
            if (patternToCheck == "us" || patternToCheck == "uk")
            {
                continue;
            }
            else
            {
                emailBook.Add(name, email);
            }
        }
        //Print the result 
        foreach (var kvp in emailBook)
        {
            Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
        }
    }
}

