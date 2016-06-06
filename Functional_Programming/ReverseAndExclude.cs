using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ReverseAndExclude
{
    public static void Main()
    {
        List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
        int n = int.Parse(Console.ReadLine());

        Predicate<int> isDivisible = x => x % n != 0;
        Func<List<int>, Predicate<int>, List<int>> myFunc = (x, y) =>
        {
            List<int> result = new List<int>();
            for (int i = x.Count - 1; i >= 0; i--)
            {
                if (y(x[i]))
                {
                    result.Add(x[i]);
                }
            }
            return result;
        };
        Console.WriteLine("{0}", string.Join(" ", myFunc(numbers, isDivisible)));
    }
}