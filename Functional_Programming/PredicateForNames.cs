using System;
using System.Collections.Generic;

public class PredicateForNames
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        string[] names = Console.ReadLine().Split();

        Predicate<string> lengthComparer = x => x.Length <= n;
        Func<string[], Predicate<string>, List<string>> filter = (x, y) =>
          {
              List<string> result = new List<string>();
              foreach (var name in x)
              {
                  if (y(name))
                  {
                      result.Add(name);
                  }
              }
              return result;
          };
        foreach (var item in filter(names, lengthComparer))
        {
            Console.WriteLine(item);
        }
    }
}