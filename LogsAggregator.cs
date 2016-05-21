using System;
using System.Collections.Generic;

public class LogsAggregator
{
    public static void Main()
    {     //            user    time
        SortedDictionary<string, int> userTime = new SortedDictionary<string, int>();
        //              user         IPs
        Dictionary<string, SortedSet<string>> userIps = new Dictionary<string, SortedSet<string>>();

        int amountOfLines = int.Parse(Console.ReadLine());
        for (int i = 0; i < amountOfLines; i++)
        {
            string[] input = Console.ReadLine().Split();
            string ipAdress = input[0];
            string user = input[1];
            int time = int.Parse(input[2]);

            if (!userTime.ContainsKey(user))
            {
                userTime.Add(user, 0);
                userIps.Add(user, new SortedSet<string>());
            }
            userIps[user].Add(ipAdress);
            userTime[user] += time;
        }
        //print the  result
        foreach (var user in userTime)
        {
            Console.WriteLine($"{user.Key}: {user.Value} [{string.Join(", ", userIps[user.Key])}]");
        }
    }
}

