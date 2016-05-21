using System;
using System.Collections.Generic;
using System.Linq;

public class LegendaryFarming
{
    static int Shadowmourne = 250;
    static int Valanyr = 250;
    static int Dragonwrath = 250;

    public static void Main()
    {
        SortedDictionary<string, int> items = new SortedDictionary<string, int>();
        items.Add("shards", 0);
        items.Add("fragments", 0);
        items.Add("motes", 0);
        SortedDictionary<string, int> junks = new SortedDictionary<string, int>();

        int shards = 0;
        int fragments = 0;
        int motes = 0;

        while (true)
        {
            if (shards >= Shadowmourne || fragments >= Valanyr || motes >= Dragonwrath)
            {
                break;
            }
            string[] input = Console.ReadLine().Trim().Split();
            for (int i = 0; i < input.Length - 1; i += 2)
            {
                int quantity = int.Parse(input[i]);
                string item = input[i + 1].ToLower();

                switch (item)
                {
                    case "shards":
                        shards += quantity;
                        items["shards"] += quantity; break;
                    case "fragments":
                        fragments += quantity;
                        items["fragments"] += quantity; break;
                    case "motes":
                        motes += quantity;
                        items["motes"] += quantity; break;
                    default:
                        if (!junks.ContainsKey(item))
                        {
                            junks.Add(item, 0);
                        }
                        junks[item] += quantity; break;
                }
                if (shards >= Shadowmourne || fragments >= Valanyr || motes >= Dragonwrath)
                {
                    break;
                }
            }
        }
        if (shards >= Shadowmourne)
        {
            Console.WriteLine("Shadowmourne obtained!");
            items["shards"] -= Shadowmourne;
        }
        else if (fragments >= Valanyr)
        {
            Console.WriteLine("Valanyr obtained!");
            items["fragments"] -= Valanyr;
        }
        else
        {
            Console.WriteLine("Dragonwrath obtained!");
            items["motes"] -= Dragonwrath;
        }
        //Print items
        foreach (var item in items.OrderByDescending(x => x.Value))
        {
            Console.WriteLine($"{item.Key}: {item.Value}");
        }

        //Print junks
        foreach (var junk in junks)
        {
            Console.WriteLine($"{junk.Key}: {junk.Value}");
        }
    }
}

