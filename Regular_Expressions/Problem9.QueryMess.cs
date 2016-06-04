using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class QueryMess
{
    public static void Main()
    {
        string input = Console.ReadLine();
        Dictionary<string, List<string>> queryMess = new Dictionary<string, List<string>>();

        while (input != "END")
        {
            int indexOfQuestion = input.IndexOf('?');
            if (indexOfQuestion != -1)
            {
                input = input.Substring(indexOfQuestion + 1);
            }
            input = Regex.Replace(input, @"%20", " ");
            input = Regex.Replace(input, @"\+", " ");
            input = Regex.Replace(input, @"\s+", " ");

            string[] pairs = input.Split('&');

            foreach (var pair in pairs)
            {
                string[] keyValuePair = pair.Split('=');
                string key = keyValuePair[0].Trim();
                string value = keyValuePair[1].Trim();
                if (!queryMess.ContainsKey(key))
                {
                    queryMess.Add(key, new List<string>());
                }
                queryMess[key].Add(value);
            }
            //Print the result
            foreach (var kvp in queryMess)
            {
                Console.Write("{0}=[{1}]", kvp.Key, String.Join(", ", kvp.Value));
            }
            Console.WriteLine();
            queryMess.Clear();
            input = Console.ReadLine();
        }
    }
}