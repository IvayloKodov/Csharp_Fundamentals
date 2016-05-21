using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

public class SrybskoUnleashed
{
    public static void Main()
    {//             venue           singer  money
        Dictionary<string, Dictionary<string, long>> venueAggregator = new Dictionary<string, Dictionary<string, long>>();
        Regex regex = new Regex(@"^(\w+|\w+\s\w+|\w+\s\w+\s\w+)\s@(\w+|\w+\s\w+|\w+\s\w+\s\w+)\s(\d+)\s(\d+)");

        string input = Console.ReadLine();
        while (input != "End")
        {
            Match match = regex.Match(input);
            if (match.Success)
            {//singer @venue ticketsPrice ticketsCount
                string singer = match.Groups[1].Value;
                string venue = match.Groups[2].Value;
                int ticketPrice = int.Parse(match.Groups[3].Value);
                int ticketsCount = int.Parse(match.Groups[4].Value);
                //Fill the data
                if (!venueAggregator.ContainsKey(venue))
                {
                    venueAggregator.Add(venue, new Dictionary<string, long>());
                }
                if (!venueAggregator[venue].ContainsKey(singer))
                {
                    venueAggregator[venue].Add(singer, 0);
                }
                long totalIncome = ticketPrice * ticketsCount;
                venueAggregator[venue][singer] += totalIncome;
            }
            input = Console.ReadLine();
        }
        //Print the result 
        foreach (var venue in venueAggregator)
        {
            Console.WriteLine(venue.Key);
            var sortedSingers = venue.Value.OrderByDescending(x => x.Value);
            foreach (var singer in sortedSingers)
            {
                Console.WriteLine($"#  {singer.Key} -> {singer.Value}");
            }
        }
    }
}

