using System;
using System.Collections.Generic;
using System.Linq;

public class CoffeeCounter
{
    public static void Main()
    {
        string[] delimeters = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        string firstDelimeter = delimeters[0];
        string secondDelimeter = delimeters[1];

        var personCoffee = new Dictionary<string, string>();
        var coffeeStock = new Dictionary<string, long>();

        string input = Console.ReadLine();
        while (input != "end of info")
        {
            int indexOfFirst = input.IndexOf(firstDelimeter);
            int indexOfSecond = input.IndexOf(secondDelimeter);

            if (indexOfFirst != -1)
            {
                string person = input.Substring(0, indexOfFirst);
                string coffee = input.Substring(indexOfFirst + firstDelimeter.Length);
                if (!personCoffee.ContainsKey(person))
                {
                    personCoffee.Add(person, coffee);
                }
            }
            else
            {
                string coffee = input.Substring(0, indexOfSecond);
                int quantity = int.Parse(input.Substring(indexOfSecond + secondDelimeter.Length));
                if (!coffeeStock.ContainsKey(coffee))
                {
                    coffeeStock.Add(coffee, 0);
                }
                coffeeStock[coffee] += quantity;
            }
            input = Console.ReadLine();
        }
        //Need a check if any person doesn't have supply.
        foreach (var coffee in personCoffee)
        {
            if (!coffeeStock.ContainsKey(coffee.Value))
            {
                Console.WriteLine($"Out of {coffee.Value}");
            }
        }

        input = Console.ReadLine();
        while (input != "end of week")//Start reading the consumptions
        {
            string[] consumption = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string person = consumption[0];
            int consumeQuantity = int.Parse(consumption[1]);

            string consumedCoffee = personCoffee[person];
            coffeeStock[consumedCoffee] -= consumeQuantity;
            if (coffeeStock[consumedCoffee] <= 0)
            {
                Console.WriteLine($"Out of {consumedCoffee}");
            }
            input = Console.ReadLine();
        }//End reading the consumption

        //Printing the statics
        Console.WriteLine("Coffee Left:");
        //Print left quantities
        var coffeeLeftQuantities = coffeeStock.Where(x => x.Value > 0).OrderByDescending(x => x.Value);
        foreach (var coffee in coffeeLeftQuantities)
        {
            Console.WriteLine($"{coffee.Key} {coffee.Value}");
        }

        Console.WriteLine("For:");
        //Print persons with coffees
        var sortedPersonCoffees = from coffee in coffeeLeftQuantities
                                  join person in personCoffee on coffee.Key equals person.Value
                                  select new { name = person.Key, drink = person.Value };

        var secondSortPC = sortedPersonCoffees
            .OrderBy(x => x.drink, StringComparer.Ordinal)
            .ThenByDescending(x => x.name).ToList();
        foreach (var person in secondSortPC)
        {
            Console.WriteLine($"{person.name} {person.drink}");
        }
    }
}