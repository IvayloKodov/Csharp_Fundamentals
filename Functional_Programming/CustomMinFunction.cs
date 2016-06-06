using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class CustomMinFunction
{
    public static void Main()
    {
        string[] numbers = Console.ReadLine().Split();
        Func<string[], int> smallest = number =>
        {
            int small = int.MaxValue;
            foreach (var item in number)
            {
                int numToCheck = int.Parse(item);
                if (numToCheck < small)
                {
                    small = numToCheck;
                }
            }
            return small;
        };
        Console.WriteLine(smallest(numbers));
    }
}