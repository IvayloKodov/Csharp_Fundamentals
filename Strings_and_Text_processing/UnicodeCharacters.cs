using System;

public class UnicodeCharacters
{
    public static void Main()
    {
        string text = Console.ReadLine();
        string result = string.Empty;
        foreach (char letter in text)
        {
            result+=String.Format(@"\u{0:X4}", Convert.ToInt16(letter));
        }
        Console.WriteLine(result.ToLower());
    }
}

