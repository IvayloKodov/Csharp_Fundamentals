using System;
using System.Collections.Generic;
using System.Linq;

public class Palindromes
{
    public static void Main()
    {
        string[] input = Console.ReadLine()
            .Split(new char[] { ' ', ',', '.', '?', '!' }, StringSplitOptions.RemoveEmptyEntries);
        List<string> palindromes = new List<string>();
        foreach (string word in input)
        {
            string testWord = word;
            bool palindrom = true;
            while (testWord.Length > 1)
            {
                char first = testWord.First();
                char last = testWord.Last();
                if (testWord.First() == testWord.Last())
                {
                    testWord = testWord.Remove(0, 1);
                    testWord = testWord.Remove(testWord.Length - 1, 1);
                }
                else
                {
                    palindrom = false;
                    break;
                }
            }
            if (palindrom)
            {
                if (!palindromes.Contains(word))
                {
                    palindromes.Add(word);
                }
            }
        }
        palindromes.Sort();
        Console.WriteLine("[{0}]", string.Join(", ", palindromes));
    }
}