using System;
using System.Numerics;

public class BaseNToBase10
{
    public static void Main()
    {
        string[] input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        int fromBase = int.Parse(input[0]);
        BigInteger toTenBase = BigInteger.Parse(input[1]);
        BigInteger result = new BigInteger();

        for (int i = toTenBase.ToString().Length - 1, j = 0; i >= 0; i--, j++)
        {
            double number = Char.GetNumericValue(toTenBase.ToString()[j]);
            result += (BigInteger)number * BigInteger.Pow(fromBase, i);
        }
        Console.WriteLine(result);
    }
}

