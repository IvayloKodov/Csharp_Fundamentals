using System;
using System.Collections.Generic;
using System.Numerics;

public class AMinersTask
{
    public static void Main()
    {
        List<string> resources = new List<string>();
        List<BigInteger> quantity = new List<BigInteger>();
        Dictionary<string, BigInteger> dict = new Dictionary<string, BigInteger>();

        while (true)
        {
            string input = Console.ReadLine();
            if (input == "stop")
            {
                break;
            }
            resources.Add(input);

            input = Console.ReadLine();
            quantity.Add(BigInteger.Parse(input));
        }
        for (int i = 0; i < resources.Count; i++)
        {
            if (!dict.ContainsKey(resources[i]))
            {
                dict.Add(resources[i], 0);
            }
            dict[resources[i]] += quantity[i];
        }

        foreach (var kvp in dict)
        {
            Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
        }
    }
}

