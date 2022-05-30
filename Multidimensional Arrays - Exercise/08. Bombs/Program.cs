using System;
using System.Linq;

namespace _08._Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());
            int[,] matrix = ReadMatrix(matrixSize);
            string[] bombIndexes = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            foreach (var item in bombIndexes)
            {
                int firstIndex = int.Parse(item.Split(",")[0]);
                int secondIndex = int.Parse(item.Split(",")[1]);
                if (matrix[firstIndex, secondIndex] <= 0)
                {
                    continue;
                }
                else
                {
                    BombExplodes(matrix, firstIndex, secondIndex);
                    matrix[firstIndex, secondIndex] = 0;
                }
            }
            AlliveCellsSum(matrix);
            PrintMatrix(matrix);
        }
        public static int[,] ReadMatrix(int rows)
        {
            int[,] matrix = new int[rows, rows];
            for (int row = 0; row < rows; row++)
            {
                int[] currentRow = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int col = 0; col < currentRow.Length; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }
            return matrix;
        }
        public static void BombExplodes(int[,] matrix, int row, int col)
        {
            if (row - 1 >= 0)
            {
                if (matrix[row - 1, col] > 0)
                {
                matrix[row - 1, col] -= matrix[row, col];
                }
                if (col - 1 >= 0)
                {
                    if (matrix[row - 1, col - 1] > 0)
                    {
                    matrix[row - 1, col - 1] -= matrix[row, col];
                    }
                }
                if (col + 1 < matrix.GetLength(1))
                {
                    if (matrix[row - 1, col + 1] > 0)
                    {
                    matrix[row - 1, col + 1] -= matrix[row, col];
                    }
                }
            }
            if (col - 1 >= 0)
            {
                if (matrix[row, col - 1] > 0)
                {
                matrix[row, col - 1] -= matrix[row, col];
                }
            }
            if (col + 1 < matrix.GetLength(1))
            {
                if (matrix[row, col + 1] > 0)
                {
                matrix[row, col + 1] -= matrix[row, col];
                }
            }
            if (row + 1 < matrix.GetLength(0))
            {
                if (matrix[row + 1, col] > 0)
                {
                matrix[row + 1, col] -= matrix[row, col];
                }
                if (col - 1 >= 0)
                {
                    if (matrix[row + 1, col - 1] > 0)
                    {
                    matrix[row + 1, col - 1] -= matrix[row, col];
                    }
                }
                if (col + 1 < matrix.GetLength(1))
                {
                    if (matrix[row + 1, col + 1] > 0)
                    {
                    matrix[row + 1, col + 1] -= matrix[row, col];
                    }
                }
            }
        }
        public static void AlliveCellsSum(int[,] matrix)
        {
            int aliveCells = 0;
            int sum = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] > 0)
                    {
                        sum += matrix[row, col];
                        aliveCells++;
                    }
                }
            }
            Console.WriteLine($"Alive cells: {aliveCells}");
            Console.WriteLine($"Sum: {sum}");
        }
        public static void PrintMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {

                    Console.Write($"{matrix[row, col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
