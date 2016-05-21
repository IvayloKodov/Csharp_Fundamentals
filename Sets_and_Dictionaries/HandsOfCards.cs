using System;
using System.Collections.Generic;
using System.Linq;

public class HandsOfCards
{
    public static void Main()
    {
        string input = Console.ReadLine();
        Dictionary<string, int> scores = new Dictionary<string, int>();
        Dictionary<string, List<string>> playerCards = new Dictionary<string, List<string>>();

        while (input != "JOKER")
        {
            string name = input.Split(':')[0];
            string[] cards = input.Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries)[1]
                .Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (!playerCards.ContainsKey(name))
            {
                playerCards.Add(name, new List<string>());
                scores.Add(name, 0);
            }

            foreach (string card in cards)
            {
                if (!playerCards[name].Contains(card))
                {
                    playerCards[name].Add(card);
                }
            }
            input = Console.ReadLine();
        }
        //Calculate the scores and add them to "scores" dictionary
        //Foreach each player
        foreach (var kvp in playerCards)
        {
            //Foreach each cards of the player
            int result = 0;
            foreach (string card in kvp.Value)
            {
                string powerOfCard = card.Substring(0, card.Length - 1);
                string typeOfCard = card.Substring(card.Length - 1);
                int powerMultiplier = 0;
                int typeMultiplier = 0;

                switch (powerOfCard)
                {
                    case "2":
                    case "3":
                    case "4":
                    case "5":
                    case "6":
                    case "7":
                    case "8":
                    case "9":
                    case "10":
                        powerMultiplier = int.Parse(powerOfCard); break;
                    case "J":
                        powerMultiplier = 11; break;
                    case "Q":
                        powerMultiplier = 12; break;
                    case "K":
                        powerMultiplier = 13; break;
                    case "A":
                        powerMultiplier = 14; break;
                }
                switch (typeOfCard)
                {
                    case "C":
                        typeMultiplier = 1; break;
                    case "D":
                        typeMultiplier = 2; break;
                    case "H":
                        typeMultiplier = 3; break;
                    case "S":
                        typeMultiplier = 4; break;
                }
                result += powerMultiplier * typeMultiplier;
            }
            //Add the result;
            scores[kvp.Key] = result;
        }
        //Print the result
        foreach (var player in scores)
        {
            Console.WriteLine($"{player.Key}: {player.Value}");
        }
    }
}

