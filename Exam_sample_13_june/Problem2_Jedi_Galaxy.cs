using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Program
{
    static void Main()
    {
        int[] matrixDimentions = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int rows = matrixDimentions[0];
        int cols = matrixDimentions[1];
        int[,] galaxy = new int[rows, cols];
        //Fill the matrix
        int counter = 0;
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                galaxy[row, col] = counter++;
            }
        }

        long stars = 0;
        while (true)
        {
            string input = Console.ReadLine();
            if (input == "Let the Force be with you")
            {
                break;
            }
            int[] ivoDimentions = input.Split().Select(int.Parse).ToArray();
            int ivoRow = ivoDimentions[0];
            int ivoCol = ivoDimentions[1];

            input = Console.ReadLine();
            int[] evilDimentions = input.Split().Select(int.Parse).ToArray();
            int evilRow = evilDimentions[0];
            int evilCol = evilDimentions[1];
            //Evil force :D
            while (evilRow >= rows || evilCol >= cols)
            {
                evilRow--;
                evilCol--;
            }
            while (evilRow >= 0 && evilCol >= 0)
            {
                galaxy[evilRow, evilCol] = 0;
                evilRow--;
                evilCol--;
            }
            //PrintGalaxy(galaxy);
            //Ivo force :D
            while (ivoRow >= rows || ivoCol < 0)
            {
                ivoRow--;
                ivoCol++;
            }
            while (ivoRow >= 0 && ivoCol < cols)
            {
                stars += galaxy[ivoRow, ivoCol];
                ivoRow--;
                ivoCol++;
            }
        }
        Console.WriteLine(stars);
    }

    public static void PrintGalaxy(int[,] galaxy)
    {
        for (int i = 0; i < galaxy.GetLength(0); i++)
        {
            for (int j = 0; j < galaxy.GetLength(1); j++)
            {
                Console.Write(galaxy[i, j].ToString().PadLeft(2, ' ') + "  ");
            }
            Console.WriteLine();
        }
    }
}