using System;
using System.Collections.Generic;
using System.Linq;

public class JediMeditation
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var result = new List<string>();
        var allJedis = new List<string>();
        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine().Split();
            allJedis.AddRange(input);
        }
        int master = allJedis.Count(x => x.StartsWith("y"));

        var persons = allJedis.Where(x => x.StartsWith("t") || x.StartsWith("s")).ToList();
        var masters = allJedis.Where(x => x.StartsWith("m")).ToList();
        var knights = allJedis.Where(x => x.StartsWith("k")).ToList();
        var paduans = allJedis.Where(x => x.StartsWith("p")).ToList();

        if (master == 0)
        {
            result.AddRange(persons);
            result.AddRange(masters);
            result.AddRange(knights);
            result.AddRange(paduans);
        }
        else
        {
            result.AddRange(masters);
            result.AddRange(knights);
            result.AddRange(persons);
            result.AddRange(paduans);
        }
        Console.WriteLine(string.Join(" ", result));
    }
}