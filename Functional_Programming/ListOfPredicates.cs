using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



public static class Predicates
{
    public static List<Func<int, bool>> predicates = new List<Func<int, bool>>();

    public static void add(Func<int, bool> predicate)
    {
        predicates.Add(predicate);
    }

    public static List<int> ApplyPredicates(List<int> numbers)
    {
        List<int> result = new List<int>();
        bool legal = true;
        for (int i = 0; i < numbers.Count; i++)
        {
            int currentNumber = numbers[i];
            foreach (var predicate in predicates)
            {
                if (!predicate(currentNumber))
                {
                    legal = false;
                    break;
                }
            }
            if (legal)
            {
                result.Add(currentNumber);
            }
            legal = true;
        }
        return result;
    }
}

public class ListOfPredicates
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        List<int> numbers = new List<int>();
        for (int i = 1; i <= n; i++)
        {
            numbers.Add(i);
        }
        int[] divisors = Console.ReadLine().Split().Select(int.Parse).ToArray();

        foreach (int devisor in divisors)
        {
            Predicates.add(x => x % devisor == 0);
        }
        numbers = Predicates.ApplyPredicates(numbers);
        Console.WriteLine(string.Join(" ", numbers));
    }
}