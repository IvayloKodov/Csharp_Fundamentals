using System;

public class LettersChangeNumbers
{
    public static void Main()
    {
        string[] words = Console.ReadLine().Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries);
        double total = 0;

        for (int i = 0; i < words.Length; i++)
        {
            char first = words[i][0];
            char second = words[i][words[i].Length - 1];
            double number = double.Parse(words[i].Substring(1, words[i].Length - 2));

            if (char.IsUpper(first))
            {
                total += number / (first % 32);
            }
            else
            {
                total += number * (first % 32);
            }
            if (char.IsUpper(second))
            {
                total -= (second % 32);
            }
            else
            {
                total += (second % 32);
            }
        }
        Console.WriteLine("{0:F2}", total);
    }
}