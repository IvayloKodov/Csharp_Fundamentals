using System;
using System.Collections.Generic;
using System.Linq;

public static class Validator
{

    public static List<string> FinalGuests(List<string> quest, Predicate<string> condition)
    {
        List<string> result = new List<string>();
        for (int i = 0; i < quest.Count; i++)
        {
            if (condition(quest[i]))
            {
                result.Add(quest[i]);
            }
        }
        return result;
    }

    public static List<string> CommandInterpreter(string command, List<string> guests, Predicate<string> validator)
    {

        if (command == "Remove")// we have to remove from the guests .. the result list
        {
            var result = guests.Except(FinalGuests(guests, validator));
            return result.ToList();
        }
        else
        {
            List<string> result = guests;
            foreach (var person in FinalGuests(guests, validator))
            {
                result.Add(person);
            }
            return result;
        }
    }
}

public class PredicateParty
{
    public static void Main()
    {
        List<string> guests = Console.ReadLine().Split(new [] {' '},StringSplitOptions.RemoveEmptyEntries).ToList();
        string commands = Console.ReadLine().Trim();

        while (commands != "Party!")
        {
            string command = commands.Split()[0];
            string criteria = commands.Split()[1];
            string definition = commands.Split()[2];

            if (criteria == "StartsWith")
            {
                guests = Validator.CommandInterpreter(command, guests, x => x.StartsWith(definition));
            }
            else if (criteria == "EndsWith")
            {
                guests = Validator.CommandInterpreter(command, guests, x => x.EndsWith(definition));
            }
            else
            {
                guests = Validator.CommandInterpreter(command, guests, x => x.Length == int.Parse(definition));
            }
            commands = Console.ReadLine().Trim();
        }
        guests.Sort();
        if (guests.Count > 0)
        {
            Console.WriteLine("{0} are going to the party!", string.Join(", ", guests));
        }
        else
        {
            Console.WriteLine("Nobody is going to the party!");
        }
    }
}