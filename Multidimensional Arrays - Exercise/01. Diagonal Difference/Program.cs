using System;
using System.Linq;

namespace Multidimensional_Arrays___Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());
            int[,] matrix = new int[matrixSize, matrixSize];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] currentRow = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int col = 0; col < currentRow.Length; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }
            int sumLeft = 0;
            int sumRight = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                sumLeft += matrix[row, row];
            }
            for (int row = 0; row < matrix.GetLength(0); row++)
            {     
                sumRight += matrix[row, matrixSize-1];
                matrixSize--;
            }
            Console.WriteLine(Math.Abs(sumLeft - sumRight));
        }
    }
}
