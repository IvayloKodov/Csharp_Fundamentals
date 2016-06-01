using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class SumBigNumbers
{
    public static void Main()
    {

        string firstNumber = Console.ReadLine().TrimStart(new[] { '0' });
        string secondNumber = Console.ReadLine().TrimStart(new[] { '0' });

        string bigger = "";
        string smaller = "";
        if (firstNumber.Length > secondNumber.Length)
        {
            bigger = firstNumber;
            smaller = secondNumber;
        }
        else
        {
            bigger = secondNumber;
            smaller = firstNumber;
        }
        char[] finalResult = sumTheNumbers(bigger, smaller).ToCharArray();
        Array.Reverse(finalResult);
        Console.WriteLine(finalResult);
    }

    private static string sumTheNumbers(string bigger, string smaller)
    {
        StringBuilder result = new StringBuilder();
        double reminder = 0;
        char[] smallerNumber = smaller.ToCharArray();
        char[] biggerNumber = bigger.ToCharArray();
        int index = biggerNumber.Length - smallerNumber.Length;

        for (int i = smaller.Length - 1; i >= 0; i--)
        {
            double sum = char.GetNumericValue(smallerNumber[i])
                        + char.GetNumericValue(biggerNumber[i + index]) + reminder;
            reminder = 0;
            if (sum.ToString().Length > 1)
            {
                result.Append(sum.ToString()[1]);
                reminder = char.GetNumericValue(sum.ToString()[0]);
            }
            else
            {
                result.Append(sum.ToString()[0]);
            }
        }
        string leftPartOfnumber = bigger.Substring(0, index);
        for (int i = leftPartOfnumber.Length - 1; i >= 0; i--)
        {
            double sum = char.GetNumericValue(leftPartOfnumber[i]) + reminder;
            reminder = 0;
            if (sum.ToString().Length > 1)
            {
                result.Append(sum.ToString()[1]);
                reminder = char.GetNumericValue(sum.ToString()[0]);
            }
            else
            {
                result.Append(sum.ToString()[0]);
            }
        }
        if (reminder != 0)
        {
            result.Append(reminder);
        }
        return result.ToString();
    }
}

