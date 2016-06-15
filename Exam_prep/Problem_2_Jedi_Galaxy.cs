using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Program
{
    public static void Main()
    {
        long ivoStarValue = 0;
        int[] matrixDimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
        string ivoInputCoordinates = Console.ReadLine();
        int[,] matrix = new int[matrixDimensions[0], matrixDimensions[1]];
        FillMatrix(matrix);

        while (ivoInputCoordinates != "Let the Force be with you")
        {
            string evilInputCoordinates = Console.ReadLine();
            int[] ivoParsedCoordinates = ivoInputCoordinates.Split().Select(int.Parse).ToArray();
            int[] evilParsedCoordinates = evilInputCoordinates.Split().Select(int.Parse).ToArray();
            int currentIvoRow = ivoParsedCoordinates[0];
            int currentIvoColumn = ivoParsedCoordinates[1];
            int currentEvilRow = evilParsedCoordinates[0];
            int currentEvilColumn = evilParsedCoordinates[1];

            while (currentEvilRow >= 0 && currentEvilColumn >= 0)
            {
                if (IsInMatrix(matrix, currentEvilRow, currentEvilColumn))
                {
                    matrix[currentEvilRow, currentEvilColumn] = 0;
                }
                currentEvilRow--;
                currentEvilColumn--;
            }

            while (currentIvoRow >= 0 && currentIvoColumn < matrix.GetLength(1))
            {
                if (IsInMatrix(matrix, currentIvoRow, currentIvoColumn))
                {
                    ivoStarValue += matrix[currentIvoRow, currentIvoColumn];
                }
                currentIvoRow--;
                currentIvoColumn++;
            }     
            ivoInputCoordinates = Console.ReadLine();
        }
        Console.WriteLine(ivoStarValue);

    }

    private static bool IsInMatrix(int[,] matrix, int givenRow, int givenCol)
    {
        bool result = givenRow >= 0 && givenRow < matrix.GetLength(0) && givenCol >= 0 && givenCol < matrix.GetLength(1);
        return result;
    }


    private static void FillMatrix(int[,] matrix)
    {
        int currentCount = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                matrix[i, j] = currentCount;
                currentCount++;
            }
        }
    }
}