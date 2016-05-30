using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class TargetPractice
{
    static int rows;
    static int cols;
    static char[][] snake;
    static string word;
    static int shotRow;
    static int shotCol;
    static int radius;

    public static void Main()
    {
        int[] dimentions = Console.ReadLine().Split().Select(int.Parse).ToArray();
        rows = dimentions[0];
        cols = dimentions[1];
        snake = new char[rows][];
        word = Console.ReadLine();
        fillSnake();
        int[] shotParameters = Console.ReadLine().Split().Select(int.Parse).ToArray();
        shotRow = shotParameters[0];
        shotCol = shotParameters[1];
        radius = shotParameters[2];
        //Make the shot and destroy the elements with  ' '
        shotTheSnake();
        //ReArrange snake
        reArrangeSnake();
        //Print the result
        printMatrix();
    }

    private static void reArrangeSnake()
    {
        for (int row = snake.Length - 1; row >= 0; row--)
        {
            for (int col = 0; col < snake[row].Length; col++)
            {
                if (snake[row][col] == ' ')
                {
                    //search char to replace the free space
                    for (int i = row; i >= 0; i--)
                    {
                        if (snake[i][col] != ' ')
                        {
                            snake[row][col] = snake[i][col];
                            snake[i][col] = ' ';
                            break;
                        }
                    }
                }
            }
        }
    }

    private static void shotTheSnake()
    {
        for (int row = 0; row < snake.Length; row++)
        {
            for (int col = 0; col < snake[row].Length; col++)
            {
                if (Math.Pow(row - shotRow, 2) + Math.Pow(col - shotCol, 2) <= Math.Pow(radius, 2))
                {
                    snake[row][col] = ' ';
                }
            }
        }
    }
    private static void printMatrix()
    {
        for (int i = 0; i < snake.Length; i++)
        {
            for (int j = 0; j < snake[i].Length; j++)
            {
                Console.Write(snake[i][j]);
            }
            Console.WriteLine();
        }
    }
    private static void fillSnake()
    {
        int index = 0;
        for (int row = rows - 1; row >= 0; row--)
        {
            snake[row] = new char[cols];

            for (int col = cols - 1; col >= 0; col--)//left movement
            {
                snake[row][col] = word[index++];
                if (index == word.Length)
                {
                    index = 0;
                }
            }
            if (row > 0)
            {
                row--;
                snake[row] = new char[cols];
                for (int col = 0; col < cols; col++)//right movement
                {
                    snake[row][col] = word[index++];
                    if (index == word.Length)
                    {
                        index = 0;
                    }
                }
            }
        }
    }
}


