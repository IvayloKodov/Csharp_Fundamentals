using System;

public class KnightsOfHonor
{
    public static void Main()
    {
        string[] names = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        Action<string> myAction = name => Console.WriteLine($"Sir {name}");

        foreach (var name in names)
        {
            myAction(name);
        }
    }
}