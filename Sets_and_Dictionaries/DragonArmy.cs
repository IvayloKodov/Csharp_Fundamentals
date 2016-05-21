using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public class DragonArmy
{
    public static void Main()
    {
        //         type                  Dragon Name    stats    0- damage, 1-health , 2-armor
        Dictionary<string, SortedDictionary<string, int[]>> dragonArmy = new Dictionary<string, SortedDictionary<string, int[]>>();
        Regex regex = new Regex(@"([A-Z][a-z]+)\s([A-Z][a-z]+)\s(\d+|null)\s(\d+|null)\s(\d+|null)");
        int lines = int.Parse(Console.ReadLine());

        for (int i = 0; i < lines; i++)
        {
            string input = Console.ReadLine();
            Match match = regex.Match(input);
            if (match.Success)
            {
                string typeOfDragon = match.Groups[1].Value;
                string nameOfDragon = match.Groups[2].Value;
                int[] stats = new int[3];
                int number;
                stats[0] = int.TryParse(match.Groups[3].Value, out number) ? number : 45;   //damage
                stats[1] = int.TryParse(match.Groups[4].Value, out number) ? number : 250;  //health
                stats[2] = int.TryParse(match.Groups[5].Value, out number) ? number : 10;   //armor

                if (!dragonArmy.ContainsKey(typeOfDragon))
                {
                    dragonArmy.Add(typeOfDragon, new SortedDictionary<string, int[]>());
                }
                if (!dragonArmy[typeOfDragon].ContainsKey(nameOfDragon))
                {
                    dragonArmy[typeOfDragon].Add(nameOfDragon, new int[3]);
                }
                dragonArmy[typeOfDragon][nameOfDragon][0] = stats[0];       //damage
                dragonArmy[typeOfDragon][nameOfDragon][1] = stats[1];       //health
                dragonArmy[typeOfDragon][nameOfDragon][2] = stats[2];       //armor
            }
        }
        //Print the result - dragonArmy
        foreach (var typeOfDragon in dragonArmy)
        {
            double averageDamage = typeOfDragon.Value.Select(x => x.Value[0]).Average();
            double averageHealth = typeOfDragon.Value.Select(x => x.Value[1]).Average();
            double averageArmor = typeOfDragon.Value.Select(x => x.Value[2]).Average();
            Console.WriteLine("{0}::({1:F2}/{2:F2}/{3:F2})",
               typeOfDragon.Key, averageDamage, averageHealth, averageArmor);
            foreach (var dragon in typeOfDragon.Value)
            {
                Console.WriteLine("-{0} -> damage: {1}, health: {2}, armor: {3}",
                    dragon.Key, dragon.Value[0], dragon.Value[1], dragon.Value[2]);
            }
        }
    }
}

