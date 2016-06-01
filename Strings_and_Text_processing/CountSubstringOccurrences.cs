using System;

public class CountSubstringOccurrences
{
    public static void Main()
    {
        //Write a program to find how many times a given string appears in a given text as 
        //substring.The text is given at the first input line.The search string is given
        //at the second input line.The output is an integer number. Please ignore the character
        //casing.

        string text = Console.ReadLine();
        string pattern = Console.ReadLine();
        int counter = 0;

        for (int i = 0; i <= text.Length - pattern.Length; i++)
        {
            string test = text.Substring(i, pattern.Length);
            if (string.Compare(pattern, test, true) == 0)
            {
                counter++;
            }
        }
        Console.WriteLine(counter);
    }
}
