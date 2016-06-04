using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class SemanticHTML
{
    public static void Main()
    {
        string line = Console.ReadLine();
        string divsExtract = @"(<div(.+?)>|<\/div>\s*<.*?([a-z]+).*>)";
        //all div's , group 1-whole sentence , group 2-with no div tags,  group 3 close tag info
        Regex regex1 = new Regex(divsExtract);
        string openTag = string.Empty;
        List<string> results = new List<string>();

        while (line != "END")
        {
            Match divMatch = regex1.Match(line);
            if (divMatch.Success)//if it success there is div tags, and need to check for open or close tag
            {
                string firstTwoChars = divMatch.Groups[1].Value.Trim().Substring(0, 2);
                if (firstTwoChars == "<d")//if tag is open
                {
                    //Extract all info of id and class ="group1" and  group2- between " "
                    string idClassExtractor = @"((?:id\s*=|class\s*=)\s*""(.+?)""\s*)";
                    Match idClassMatch = Regex.Match(divMatch.Groups[2].Value, idClassExtractor);
                    openTag = idClassMatch.Groups[2].Value;
                    string replacement = $@"<{openTag}{Regex.Replace(divMatch.Groups[2].Value, idClassMatch.Groups[1].Value, "")}";
                    line = regex1.Replace(line, Regex.Replace(replacement.Trim(), "\\s+", " "));
                    line = line + ">";//because the trim of "replacement" after it add ">"
                    results.Add(line);
                }
                else if (firstTwoChars == "</")//if tag is close,divmatch group 3 is close tag
                {
                    string closeTag = divMatch.Groups[3].Value;
                    string replacement = $@"</{closeTag}>";
                    line = regex1.Replace(line, replacement.Trim());
                    results.Add(line);
                }
            }
            else//if not success, there is no div tags,then add the current line
            {
                results.Add(line);
            }
            line = Console.ReadLine();
        }
        foreach (string newLine in results)
        {
            Console.WriteLine("{0}", newLine);
        }
    }
}