using System;
using System.Collections.Generic;
using System.Text;

public class ExtractHyperlinks
{
    static int indexOfEqual;
    public static void Main()
    {
        string input = Console.ReadLine();
        StringBuilder allText = new StringBuilder();
        List<string> extractedTags = new List<string>();

        while (input != "END")//We collect all the data , to ensure uncomplete sentence doesn't exists
        {
            allText.Append(input);
            input = Console.ReadLine();
        }
        string result = allText.ToString();

        while (true)
        {
            int indexOfStart = result.IndexOf("<a");
            if (indexOfStart != -1)
            {
                string currentTag = "";
                result = result.Substring(indexOfStart + 2, Math.Max(0, result.Length - indexOfStart - 2));
                int indexOfStop = result.IndexOf(">");
                currentTag = result.Substring(0, indexOfStop);
                result = result.Substring(indexOfStop + 1, Math.Max(0, result.Length - indexOfStop - 1));

                int indexOfHref = realHrefFinder(currentTag); // if return 1 there is href, if return -1 there isn't
                if (indexOfHref != -1)
                {
                    currentTag = currentTag.Substring(indexOfEqual + 1, Math.Max(0, currentTag.Length - indexOfEqual - 1)).Trim();
                    //Find the quotes and extract the info
                    string finalInfo = tagExtractor(currentTag);
                    extractedTags.Add(finalInfo);
                }
            }
            else
            {
                break;
            }
        }

        foreach (string tag in extractedTags)
        {
            Console.WriteLine(tag);
        }
    }

    private static string tagExtractor(string currentTag)
    {
        char quote = currentTag[0];

        if (quote == '\"' || quote == '\'')
        {
            currentTag = currentTag.Substring(1, currentTag.Length - 1);
            int indexOfCloseQuote = currentTag.IndexOf(quote);
            currentTag = currentTag.Substring(0, indexOfCloseQuote);
            return currentTag;
        }
        for (int i = 1; i < currentTag.Length; i++)
        {
            if (currentTag[i] == ' ' || currentTag[i] == '>')
            {
                currentTag = currentTag.Substring(0, i);
                break;
            }
        }
        return currentTag;
    }

    private static int realHrefFinder(string currentTag)
    {
        int indexOfHref = currentTag.IndexOf("href");
        bool isCorrectHref = false;
        for (int i = indexOfHref + 4; i < currentTag.Length; i++)
        {
            if (currentTag[i] == ' ')
            {
                continue;
            }
            else if (currentTag[i] == '=')
            {
                isCorrectHref = true;
                indexOfEqual = i;
                break;
            }
            string temp = currentTag.Substring(i, currentTag.Length - i);
            indexOfHref = temp.IndexOf("href");
            i += indexOfHref + 3;
        }
        if (isCorrectHref)
        {
            return 1;
        }
        else
        {
            return -1;
        }
    }
}