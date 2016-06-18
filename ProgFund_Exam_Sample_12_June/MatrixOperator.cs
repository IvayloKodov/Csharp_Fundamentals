using System;
using System.Collections.Generic;
using System.Linq;

public class MatrixOperator
{
    public static void Main()
    {
        int rows = int.Parse(Console.ReadLine());
        var matrix = new List<List<long>>();
        for (int i = 0; i < rows; i++)
        {
            var currentList =
            Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse).ToList();
            matrix.Add(currentList);
        }
        string input = Console.ReadLine().Trim();
        while (input != "end")
        {
            string[] info = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string command = info[0];
            switch (command)
            {
                case "remove":
                    string type = info[1];
                    string rowCol = info[2];
                    int index = int.Parse(info[3]);
                    RemoveIndex(matrix, type, rowCol, index);
                    break;
                case "swap":
                    int firstRow = int.Parse(info[1]);
                    int secondRow = int.Parse(info[2]);
                    SwapRows(matrix, firstRow, secondRow);
                    break;
                case "insert":
                    int insertRow = int.Parse(info[1]);
                    long number = long.Parse(info[2]);
                    InsertNumber(matrix, insertRow, number);
                    break;
            }
            input = Console.ReadLine().Trim();
        }
        PrintMatrix(matrix);
    }

    private static void PrintMatrix(List<List<long>> matrix)
    {
        for (int i = 0; i < matrix.Count; i++)
        {
            for (int j = 0; j < matrix[i].Count; j++)
            {
                Console.Write(matrix[i][j] + " ");
            }
            Console.WriteLine();
        }
    }

    //type = even,odd,negative, positive      row/col   index
    private static void RemoveIndex(List<List<long>> matrix, string type, string rowCol, int index)
    {
        switch (type)
        {
            case "even":
                Predicate<long> even = x => x % 2 == 0;
                Remover(matrix, rowCol, index, even);
                break;
            case "odd":
                Predicate<long> odd = x => x % 2 != 0;
                Remover(matrix, rowCol, index, odd);
                break;
            case "negative":
                Predicate<long> negative = x => x < 0;
                Remover(matrix, rowCol, index, negative);
                break;
            case "positive":
                Predicate<long> positive = x => x > 0;
                Remover(matrix, rowCol, index, positive);
                break;
        }
    }

    private static void Remover(List<List<long>> matrix, string rowCol, int index, Predicate<long> comparer)
    {
        if (rowCol == "row" && index >= 0 && index < matrix.Count)
        {
            matrix[index].RemoveAll(comparer);
        }
        else//rowCol = "col"
        {
            for (int i = 0; i < matrix.Count; i++)
            {
                if (matrix[i].Count > index)
                {
                    if (comparer(matrix[i][index]))
                    {
                        matrix[i].RemoveAt(index);
                    }
                }
            }
        }
    }

    private static void InsertNumber(List<List<long>> matrix, int insertRow, long number)
    {
        if (insertRow >= 0 && insertRow <= matrix.Count)
        {
            matrix[insertRow].Insert(0, number);
        }
    }

    private static void SwapRows(List<List<long>> matrix, int firstRow, int secondRow)
    {
        if (firstRow >= 0 && firstRow < matrix.Count && secondRow >= 0 && secondRow < matrix.Count)
        {
            var firstRowList = matrix[firstRow];
            var secondRowList = matrix[secondRow];
            matrix[firstRow] = secondRowList;
            matrix[secondRow] = firstRowList;
        }
    }
}