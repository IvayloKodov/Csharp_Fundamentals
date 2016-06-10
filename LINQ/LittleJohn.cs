using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

public class LittleJohn
{
    public static void Main()
    {
        string pattern = @"([>]{3}-----[>]{2})|([>]{2}-----[>]{1})|([>]{1}-----[>]{1})";
        Regex regex = new Regex(pattern);
        string input = Console.ReadLine();
        // large medium small
        Dictionary<string, int> counter = new Dictionary<string, int>();
        counter.Add("large", 0);
        counter.Add("medium", 0);
        counter.Add("small", 0);

        for (int i = 0; i < 4; i++)
        {
            MatchCollection match = regex.Matches(input);
            if (match.Count > 0)
            {
                foreach (Match arrow in match)
                {
                    if (arrow.Value == ">>>----->>")//large
                    {
                        counter["large"]++;
                    }
                    else if (arrow.Value == ">>----->")//medium
                    {
                        counter["medium"]++;
                    }
                    else
                    {
                        counter["small"]++;
                    }
                }
            }
            input = Console.ReadLine();
        }
        string result = counter["small"].ToString() + counter["medium"] + counter["large"];
        int resultInDec = int.Parse(result);
        result = Convert.ToString(resultInDec, 2);

        StringBuilder finalResult = new StringBuilder(result);
        for (int i = result.Length - 1; i >= 0; i--)
        {
            finalResult.Append(result[i]);
        }
        double finalResultInDecimal = 0;
        Console.WriteLine(Convert.ToInt32(finalResult.ToString(), 2));
    }
}