using System;
using System.Collections.Generic;
using System.Linq;

public class ParkingSystem
{
    static bool[,] parking;
    static int closestPlace;

    public static void Main()
    {
        int[] dimentions = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int rows = dimentions[0];
        int cols = dimentions[1];
        parking = new bool[rows, cols];

        string input = Console.ReadLine();
        while (input != "stop")
        {
            int[] parkingInfo = input.Split().Select(int.Parse).ToArray();
            int entry = parkingInfo[0];
            int parkRow = parkingInfo[1];
            int parkCol = parkingInfo[2];
            int distance = Math.Abs(entry - parkRow) + 1;

            if (!parking[parkRow, parkCol])
            {
                parking[parkRow, parkCol] = true;
                Console.WriteLine(distance + parkCol);
            }
            else
            {
                if (!isParkingFull(parkRow, parkCol))
                {
                    parking[parkRow, closestPlace] = true;
                    Console.WriteLine(distance + closestPlace);
                }
                else
                {
                    Console.WriteLine($"Row {parkRow} full");
                }
            }
            input = Console.ReadLine();
        }
    }
    public static bool isParkingFull(int parkRow, int parkCol)
    {
        SortedDictionary<int, int> finder = new SortedDictionary<int, int>();
        for (int i = 1; i < parking.GetLength(1); i++)
        {
            if (!parking[parkRow, i])
            {
                int distance = Math.Abs(parkCol - i);
                if (!finder.ContainsKey(distance))
                {
                    finder.Add(distance, i);
                }
            }
        }

        if (finder.Count != 0)
        {
            closestPlace = finder.First().Value;
            return false;
        }
        else
        {
            return true;
        }
    }
}

