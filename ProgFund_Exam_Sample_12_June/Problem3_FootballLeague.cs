using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public class FootballLeague
{
    public static void Main()
    {
        string inputPattern = Console.ReadLine();
        string escapedInputPattern = Regex.Escape(inputPattern);
        string pattern = string.Format(@"{0}(.+?){0}.*?{0}(.+?){0}.*?(\d+:\d+)", escapedInputPattern);
        Regex regex = new Regex(pattern);
        var teamAndGoal = new SortedDictionary<string, int>();
        var teamAndPoints = new SortedDictionary<string, int>();

        string input = Console.ReadLine();
        while (input != "final")
        {
            Match match = regex.Match(input);
            if (match.Success)
            {
                string firstTeam = new string(match.Groups[1].Value.ToUpper().Reverse().ToArray());
                string secondTeam = new string(match.Groups[2].Value.ToUpper().Reverse().ToArray());
                string result = match.Groups[3].Value;
                if (!teamAndPoints.ContainsKey(firstTeam))
                {
                    teamAndPoints.Add(firstTeam, 0);
                    teamAndGoal.Add(firstTeam, 0);
                }
                if (!teamAndPoints.ContainsKey(secondTeam))
                {
                    teamAndPoints.Add(secondTeam, 0);
                    teamAndGoal.Add(secondTeam, 0);
                }
                int firstTeamGoals = int.Parse(result.Split(':')[0]);
                int secondTeamGoals = int.Parse(result.Split(':')[1]);
                teamAndGoal[firstTeam] += firstTeamGoals;
                teamAndGoal[secondTeam] += secondTeamGoals;
                //If return -1  firstteam = 3 points 
                //if return  0  both= 1 points 
                //if return  1  second = 3 points
                int points = FindPoints(firstTeamGoals, secondTeamGoals);
                if (points == -1)
                {
                    teamAndPoints[firstTeam] += 3;
                }
                else if (points == 0)
                {
                    teamAndPoints[firstTeam]++;
                    teamAndPoints[secondTeam]++;
                }
                else
                {
                    teamAndPoints[secondTeam] += 3;
                }
            }
            input = Console.ReadLine();
        }
        //Print and sort
        Console.WriteLine("League standings:");
        int counter = 1;
        teamAndPoints.OrderByDescending(x => x.Value)
                    .ToList()
                    .ForEach(team => Console.WriteLine($"{counter++}. {team.Key} {team.Value}"));

        Console.WriteLine("Top 3 scored goals:");
        teamAndGoal.OrderByDescending(x => x.Value)
                    .Take(3)
                    .ToList()
                    .ForEach(team => Console.WriteLine($"- {team.Key} -> {team.Value}"));
    }

    private static int FindPoints(int firstTeamGoals, int secondTeamGoals)
    {
        if (firstTeamGoals > secondTeamGoals)
        {
            return -1;
        }
        else if (firstTeamGoals < secondTeamGoals)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }
}