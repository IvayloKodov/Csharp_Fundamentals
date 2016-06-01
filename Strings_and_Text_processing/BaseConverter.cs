using System;
using System.Numerics;
using System.Text;

public class BaseConverter
{
    public static void Main()
    {
        string[] input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        int toBase = int.Parse(input[0]);
        BigInteger number = BigInteger.Parse(input[1]);

        StringBuilder numberToBaseReversed = new StringBuilder();
        while (number > 0)
        {
            numberToBaseReversed.Append(number % toBase);
            number = number / toBase;
        }
        char[] result = numberToBaseReversed.ToString().ToCharArray();
        Array.Reverse(result);
        Console.WriteLine(result);
    }
}

