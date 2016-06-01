using System;

public class ReverseString
{
    public static void Main()
    {
        char[] input = Console.ReadLine().ToCharArray();
        Array.Reverse(input);
        Console.WriteLine(input);
    }
}

