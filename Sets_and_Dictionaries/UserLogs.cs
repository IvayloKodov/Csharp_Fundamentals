using System;
using System.Collections.Generic;
using System.Linq;

public class UserLogs
{
    public static void Main()
    {
        string input = Console.ReadLine();
        SortedDictionary<string, Dictionary<string, int>> userLogs = new SortedDictionary<string, Dictionary<string, int>>();

        while (input!="end")
        {
            string[] log = input.Split(new[] { ' ' ,'='},StringSplitOptions.RemoveEmptyEntries);
            string ipAdress = log[1];
            string user = log[5];

            if (!userLogs.ContainsKey(user))
            {
                userLogs.Add(user, new Dictionary<string, int>());
            }
            if (!userLogs[user].ContainsKey(ipAdress))
            {
                userLogs[user].Add(ipAdress, 0);
            }
            userLogs[user][ipAdress]++;
            input = Console.ReadLine();
        }
        //Print the result
        foreach (var outerPair in userLogs)
        {
            Console.WriteLine($"{outerPair.Key}:");
            Console.WriteLine("{0}.",string.Join(", ",outerPair.Value.Select(x=>$"{x.Key} => {x.Value}")));
        }
    }
}

