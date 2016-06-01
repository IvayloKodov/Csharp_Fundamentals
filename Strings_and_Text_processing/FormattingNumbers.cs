using System;

public class FormattingNumbers
{
    public static void Main()
    {
        string[] numbers = Console.ReadLine().Split(new char[] { ' ','\t' },StringSplitOptions.RemoveEmptyEntries);
        int a = int.Parse(numbers[0]);
        double b = double.Parse(numbers[1]);
        double c = double.Parse(numbers[2]);

        Console.Write("|" + "{0,-10:X}", a);
        Console.Write("|" + "{0}" + "|", Convert.ToString(a, 2).PadLeft(10, '0').Substring(0,10));
        Console.WriteLine("{0,10:F2}" + "|" + "{1,-10:F3}" + "|", b, c);
    }
}

