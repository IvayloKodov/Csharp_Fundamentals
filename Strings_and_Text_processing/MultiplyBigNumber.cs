using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class MultiplyBigNumber
{
    public static void Main()
    {
        string firstNumber = Console.ReadLine().TrimStart(new[] { '0' });
        string secondNumber = Console.ReadLine();
        StringBuilder result = new StringBuilder();
        double reminder = 0;

        for (int i = firstNumber.Length - 1; i >= 0; i--)
        {
            double sum = char.GetNumericValue(firstNumber[i]) * int.Parse(secondNumber) + reminder;
            reminder = 0;
            if (sum.ToString().Length > 1)
            {
                result.Append(sum.ToString()[1]);
                reminder = char.GetNumericValue(sum.ToString()[0]);
            }
            else
            {
                result.Append(sum.ToString());
            }
        }

        if (reminder != 0)
        {
            result.Append(reminder);
        }

        char[] reversedResult = result.ToString().ToCharArray();
        Array.Reverse(reversedResult);
        if (secondNumber == "0")
        {
            Console.WriteLine(0);
        }
        else
        {
            Console.WriteLine(reversedResult);
        }
    }
}

