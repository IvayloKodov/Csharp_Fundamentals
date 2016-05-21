using System;
using System.Collections.Generic;

public class UniqueUsernames
{
    public static void Main()
    {
        //Write a simple program that reads from the console a sequence of usernames and keeps a collection
        //with only the unique ones. Print the collection on the console:

        int count = int.Parse(Console.ReadLine());
        HashSet<string> usernameSet = new HashSet<string>();
        for (int i = 0; i < count; i++)
        {
            string userName = Console.ReadLine();
            usernameSet.Add(userName);
        }
        foreach (string name in usernameSet)
        {
            Console.WriteLine(name);
        }
    }
}


