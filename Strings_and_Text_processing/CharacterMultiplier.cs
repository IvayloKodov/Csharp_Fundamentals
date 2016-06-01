using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CharacterMultiplier
{
    public static void Main()
    {
        string[] input = Console.ReadLine().Split();
        string bigger = input[0];
        string smaller = input[1];

        if (bigger.Length < smaller.Length)
        {
            string temp = bigger;
            bigger = smaller;
            smaller = temp;
        }
        //Multiply each char
        double sum = 0;
        for (int i = 0; i < bigger.Length; i++)
        {
            if (i >= smaller.Length)
            {
                sum += bigger[i];
                continue;
            }
            sum += bigger[i] * smaller[i];
        }
        Console.WriteLine(sum);
    }
}

