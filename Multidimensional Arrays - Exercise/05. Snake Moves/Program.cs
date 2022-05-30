using System;
using System.Linq;

namespace _05._Snake_Moves
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int matrixRow = matrixSize[0];
            int matrixCol = matrixSize[1];
            char[,] matrix = new char[matrixRow, matrixCol];
            string snake = Console.ReadLine();
            int snakeIndex = 0;
            for (int row = 0; row < matrixRow; row++)
            {
                if (row % 2 == 0)
                {
                    for (int col = 0; col < matrixCol; col++)
                    {
                        matrix[row, col] = snake[snakeIndex];
                        snakeIndex++;
                        if (snakeIndex >= snake.Length)
                        {
                            snakeIndex = 0;
                        }
                    }
                }
                else
                {
                    for (int col = matrixCol - 1; col >= 0; col--)

                    {
                        matrix[row, col] = snake[snakeIndex];
                        snakeIndex++;
                        if (snakeIndex >= snake.Length)
                        {
                            snakeIndex = 0;
                        }
                    }
                }
            }
            for (int row = 0; row < matrix.GetLength(0); row++)
            {

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row,col] );
                }
                Console.WriteLine();
            }
        }
    }
}
