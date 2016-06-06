using System;

public class Program
{
    public static void Main()
    {
        string[] names = Console.ReadLine().Split();
        Action<string> print = name => Console.WriteLine(name);
        foreach (var name in names)
        {
            print(name);
        }
    }
}