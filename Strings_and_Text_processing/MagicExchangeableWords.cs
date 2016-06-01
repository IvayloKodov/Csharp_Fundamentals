using System;
using System.Collections.Generic;

public class MagicExchangeableWords
{
    public static void Main()
    {
        string[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        string smallerWord = input[0];
        string biggerWord = input[1];
        bool isExchangable = true;

        Dictionary<char, char> magic = new Dictionary<char, char>();
        if (biggerWord.Length < smallerWord.Length)
        {
            string temp = smallerWord;
            smallerWord = biggerWord;
            biggerWord = temp;

        }
        for (int i = 0; i < smallerWord.Length; i++)
        {
            if (!magic.ContainsKey(smallerWord[i]))
            {
                if (!magic.ContainsValue(biggerWord[i]))
                {
                    magic.Add(smallerWord[i], biggerWord[i]);
                }
                else
                {
                    isExchangable = false;
                }
            }
            else
            {
                if (magic[smallerWord[i]] != biggerWord[i])
                {
                    isExchangable = false;
                }
            }
        }
        //Check the rest chars from bigger word
        for (int i = smallerWord.Length; i < biggerWord.Length; i++)
        {
            if (!magic.ContainsValue(biggerWord[i]))
            {
                isExchangable = false;
            }
        }
        //Print the result
        if (isExchangable)
        {
            Console.WriteLine("true");
        }
        else
        {
            Console.WriteLine("false");
        }
    }
}

