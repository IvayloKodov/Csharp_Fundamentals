using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;


public class RoyalAccounting
{
    public static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-GB");

        //{employeeName};{workHoursPerDay};{dailyPayment};{team}
        string pattern = @"^([A-Za-z]+);(\d+|-\d+);(\d+\.\d+|-\d+\.\d+|\d+|-\d+);([A-Za-z]+)$";
        Regex regex = new Regex(pattern);
        // team             ((daily payment * work hours) / 24) * 30
        Dictionary<string, decimal> teams = new Dictionary<string, decimal>();
        //              employee          workHours   dailyPay (daily payment * work hours) / 24 
        SortedDictionary<string, Dictionary<decimal, decimal>> employees = new SortedDictionary<string, Dictionary<decimal, decimal>>();
        //Team members          employees
        Dictionary<string, List<string>> teamMembers = new Dictionary<string, List<string>>();

        string input = Console.ReadLine();
        while (input != "Pishi kuf i da si hodim")
        {
            Match match = regex.Match(input);
            if (match.Success)
            {
                string employee = match.Groups[1].Value;
                decimal hoursPerDay = decimal.Parse(match.Groups[2].Value);
                decimal dailyPayment = decimal.Parse(match.Groups[3].Value);
                string team = match.Groups[4].Value;

                decimal monthPayment = ((dailyPayment * hoursPerDay) / 24) * 30;// team
                decimal dailyEmployeePayment = (dailyPayment * hoursPerDay) / 24; //employee

                if (!teams.ContainsKey(team))
                {
                    teams.Add(team, 0);
                    teamMembers.Add(team, new List<string>());
                }
                if (!employees.ContainsKey(employee))
                {
                    employees.Add(employee, new Dictionary<decimal, decimal>());
                    employees[employee].Add(hoursPerDay, dailyEmployeePayment);
                    teams[team] += monthPayment;
                    teamMembers[team].Add(employee);
                }
            }
            input = Console.ReadLine();
        }
   
        foreach (var team in teams.OrderByDescending(x => x.Value))
        {
            Console.WriteLine($"Team - {team.Key}");
            //Sort employees and print them foreach team

            SortedDictionary<string, Dictionary<decimal, decimal>> sortTeamEmployees = new SortedDictionary<string, Dictionary<decimal, decimal>>();

            foreach (var employee in teamMembers[team.Key])
            {
                sortTeamEmployees.Add(employee, new Dictionary<decimal, decimal>());
                sortTeamEmployees[employee].Add(employees[employee].Keys.First(), employees[employee].Values.First());
            }
            var sortedEmployees = sortTeamEmployees.OrderByDescending(x => x.Value.Keys.First()).ThenByDescending(x => x.Value.Values.First());
            foreach (var emp in sortedEmployees)
            {
                Console.WriteLine("$$${0} - {1} - {2:0.000000}", emp.Key, emp.Value.Keys.First(),emp.Value.Values.First());
            }
        }
    }
}