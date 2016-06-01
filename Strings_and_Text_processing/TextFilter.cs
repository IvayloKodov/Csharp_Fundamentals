using System;

public class TextFilter
{
    public static void Main()
    {
        string[] banList = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
        string text = Console.ReadLine();

        for (int i = 0; i < banList.Length; i++)
        {
            text = text.Replace(banList[i], new string('*', banList[i].Length));
        }
        Console.WriteLine(text);
    }
}

