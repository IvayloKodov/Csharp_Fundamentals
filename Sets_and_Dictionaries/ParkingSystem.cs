using System;
using System.Collections.Generic;
using System.Linq;

public class ParkingSystem
{
    static Dictionary<int, HashSet<int>> parking;
    static int rows;
    static int cols;

    public static void Main()
    {
        int[] dimentions = Console.ReadLine().Split().Select(int.Parse).ToArray();
        rows = dimentions[0];
        cols = dimentions[1];
        parking = new Dictionary<int, HashSet<int>>();

        string input = Console.ReadLine();
        while (input != "stop")
        {
            int[] parkingInfo = input.Split().Select(int.Parse).ToArray();
            int entry = parkingInfo[0];
            int parkRow = parkingInfo[1];
            int parkCol = parkingInfo[2];
            int distance = Math.Abs(entry - parkRow) + 1;

            if (IsPlaceFree(parkRow, parkCol))// if its free
            {
                Console.WriteLine(distance + parkCol);
                OccupyThePlace(parkRow, parkCol);
            }
            else// If the place is occupied, start searching the better place
            {
                int newPlace = FindPlace(parkRow, parkCol);
                if (newPlace != 0)
                {
                    Console.WriteLine(distance + newPlace);
                    OccupyThePlace(parkRow, newPlace);
                }
                else
                {
                    Console.WriteLine($"Row {parkRow} full");
                }
            }
            input = Console.ReadLine();
        }
    }

    private static void OccupyThePlace(int parkRow, int parkCol)
    {
        if (!parking.ContainsKey(parkRow))
        {
            parking.Add(parkRow, new HashSet<int>());
        }
        parking[parkRow].Add(parkCol);
    }

    private static int FindPlace(int parkRow, int parkCol)
    {
        int newPlace = 0;
        int closerPlace = int.MaxValue;
        for (int i = 1; i < cols; i++)
        {
            if (!parking[parkRow].Contains(i))
            {
                int currentDistance = Math.Abs(i - parkCol);
                if (currentDistance < closerPlace)
                {
                    closerPlace = currentDistance;
                    newPlace = i;
                }
            }
        }
        return newPlace;
    }

    private static bool IsPlaceFree(int parkRow, int parkCol)
    {
        if (!parking.ContainsKey(parkRow))
        {
            parking.Add(parkRow, new HashSet<int>());
        }

        if (!parking[parkRow].Contains(parkCol))
        {
            return true;
        }
        return false;
    }
}

