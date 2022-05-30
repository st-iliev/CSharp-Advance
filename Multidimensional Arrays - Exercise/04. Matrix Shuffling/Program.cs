using System;
using System.Linq;

namespace _04._Matrix_Shuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            string[,] matrix = ReadMatrix(matrixSize[0], matrixSize[1]);
            string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            while (command[0]!="END")
            {
                if (command.Length != 5)
                {
                    Console.WriteLine("Invalid input!");
                    
                }
                else if (command[0] == "swap")
                {
                    int row1 = int.Parse(command[1]);
                    int col1 = int.Parse(command[2]);
                    int row2 = int.Parse(command[3]);
                    int col2 = int.Parse(command[4]);
                  if (row1 >= 0 && row2 >= 0 && row1 <= matrixSize[0] && row2 <= matrixSize[0] && col1 >= 0 && col2 >= 0 && col2 <= matrixSize[1] && col1 <= matrixSize[1])
                    {
                        string firstElement = matrix[row1, col1];
                        string secondElement = matrix[row2, col2];
                        matrix[row1, col1] = matrix[row2, col2];
                        matrix[row2, col2] = firstElement;
                        WriteMatrix(matrix);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                    }           
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
                command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

        }
        public static string[,] ReadMatrix(int rows, int cols)
        {
            string[,] matrix = new string[rows, cols];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] currentRow = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                for (int col = 0; col < currentRow.Length; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }
            return matrix;
        }
        public static void WriteMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{ matrix[row, col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
