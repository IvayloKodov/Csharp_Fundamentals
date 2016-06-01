using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class StringLength
{
    public static void Main()
    {
        string text = Console.ReadLine();
        string result = "";
        if (text.Length < 20)
        {
            result = text.PadRight(20, '*');
        }
        else
        {
            for (int i = 0; i < 20; i++)
            {
                result += text[i];
            }
        }
        Console.WriteLine(result);
    }
}

