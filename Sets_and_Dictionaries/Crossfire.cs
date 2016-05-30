using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Crossfire
{
    public static void Main()
    {
        List<List<int>> matrix = new List<List<int>>();
        int[] matrixDimentions = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int rows = matrixDimentions[0];
        int cols = matrixDimentions[1];
        //Fill the matrix 
        int filler = 1;
        for (int i = 0; i < rows; i++)
        {
            List<int> collums = new List<int>();
            for (int j = 0; j < cols; j++)
            {
                collums.Add(filler++);
            }
            matrix.Add(collums);
        }
        //Start shooting until receives command Nuke it from orbit

        string target = Console.ReadLine();
        while (target != "Nuke it from orbit")
        {
            int[] targetInfo = target.Split().Select(int.Parse).ToArray();
            int attackedRow = targetInfo[0];
            int attackedCol = targetInfo[1];
            int radius = targetInfo[2];

            int attackStartRow = attackedRow - radius;
            int attackStopRow = attackedRow + radius;
            int attackStartCol = attackedCol - radius;
            int attackStopCol = attackedCol + radius;

            for (int row = Math.Max(0, attackStartRow); row <= Math.Min(matrix.Count - 1, attackStopRow); row++)
            {
                for (int col = Math.Max(0, attackStartCol); col <= Math.Min(matrix[row].Count - 1, attackStopCol); col++)
                {
                    if (row == attackedRow || col == attackedCol)
                    {
                        matrix[row][col] = 0;
                    }
                }
            }
            //Cleaning the matrix from zeros
            for (int i = matrix.Count - 1; i >= 0; i--)
            {
                for (int j = matrix[i].Count - 1; j >= 0; j--)
                {
                    if (matrix[i][j] == 0)
                    {
                        matrix[i].RemoveAt(j);
                    }
                }
                if (matrix[i].Count == 0)
                {
                    matrix.RemoveAt(i);
                }
            }
            target = Console.ReadLine();
        }
        //Print matrix
        for (int i = 0; i < matrix.Count; i++)
        {
            for (int j = 0; j < matrix[i].Count; j++)
            {
                Console.Write(matrix[i][j] + " ");
            }
            Console.WriteLine();
        }
    }
}

