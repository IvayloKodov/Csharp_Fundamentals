using System;
using System.Collections.Generic;
using System.Linq;

public class Numbers
{
    public static void Main()
    {
        List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
        double average = numbers.Average();
        var resultNumbers = numbers.Where(x => x > average).OrderByDescending(x => x).Take(5).ToList();
        Console.WriteLine("{0}", resultNumbers.Count > 0 ? string.Join(" ", resultNumbers) : "No");
    }
}