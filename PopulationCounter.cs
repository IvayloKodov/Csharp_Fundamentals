using System;
using System.Collections.Generic;
using System.Linq;

public class PopulationCounter
{
    public static void Main()
    {   //         country             city     population
        Dictionary<string, Dictionary<string, long>> populationCounter = new Dictionary<string, Dictionary<string, long>>();
        string input = Console.ReadLine();

        while (input != "report")
        {
            string[] populationInfo = input.Split('|');
            string city = populationInfo[0].Trim();
            string country = populationInfo[1].Trim();
            int population = int.Parse(populationInfo[2].Trim());

            if (!populationCounter.ContainsKey(country))
            {
                populationCounter.Add(country, new Dictionary<string, long>());
            }
            if (!populationCounter[country].ContainsKey(city))
            {
                populationCounter[country][city] = population;
            }
            input = Console.ReadLine();
        }

        foreach (var country in populationCounter.OrderByDescending(x => x.Value.Values.Sum()))
        {
            long countryValueSum = populationCounter[country.Key].Values.Sum();
            Console.WriteLine($"{country.Key} (total population: {countryValueSum})");

            foreach (var city in populationCounter[country.Key].OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"=>{city.Key}: {city.Value}");
            }
        }
    }
}

