using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class AppliedArithmetics
{
    public static void Main()
    {
        List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

        string input = Console.ReadLine();
        while (input != "end")
        {
            switch (input)
            {
                case "add":
                    Func<List<int>, List<int>> add = x =>
                    {
                        for (int i = 0; i < x.Count; i++)
                        {
                            x[i] = x[i] + 1;
                        }
                        return x;
                    };
                    add(numbers);
                    break;
                case "multiply":
                    Func<List<int>, List<int>> multiply = x =>
                    {
                        for (int i = 0; i < x.Count; i++)
                        {
                            x[i] = x[i] * 2;
                        }
                        return x;
                    };
                    multiply(numbers);
                    break;
                case "subtract":
                    Func<List<int>, List<int>> subtract = x =>
                    {
                        for (int i = 0; i < x.Count; i++)
                        {
                            x[i] = x[i] -1;
                        }
                        return x;
                    };
                    subtract(numbers);
                    break;
                case "print":
                    Console.WriteLine($"{string.Join(" ", numbers)}");
                    break;
            }
            input = Console.ReadLine();
        }
    }
}