using System;

public class MelrahShake
{
    public static void Main()
    {
        string text = Console.ReadLine();
        string pattern = Console.ReadLine();

        while (pattern.Length != 0 && text.Length >= pattern.Length)
        {
            int firstOccurence = text.IndexOf(pattern);
            int lastOccurence = text.LastIndexOf(pattern);
            //firstOccurence!=-1 && lastOccurence!=-1 && firstOccurence!=lastOccurence
            if (firstOccurence >= 0 && lastOccurence >= 0)
            {
                text = text.Remove(lastOccurence, pattern.Length);
                text = text.Remove(firstOccurence, pattern.Length);
                Console.WriteLine("Shaked it.");
                pattern = pattern.Remove(pattern.Length / 2, 1);
            }
            else
            {
                break;
            }
        }
        Console.WriteLine("No shake.");
        Console.WriteLine(text);
    }
}

