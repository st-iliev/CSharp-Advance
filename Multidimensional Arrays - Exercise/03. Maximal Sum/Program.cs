using System;
using System.Linq;

namespace _03._Maximal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[,] matrix = ReadMatrix(matrixSize[0], matrixSize[1]);
            int maxMatrixSum = int.MinValue;
            int indexRow = -1;
            int indexCol = -1;
            for (int row = 0; row < matrix.GetLength(0)-2; row++)
            {
                int currentMatrixSum = 0;
                for (int col = 0; col < matrix.GetLength(1)-2; col++)
                {
                    for (int currentRow = row; currentRow <row+3; currentRow++)
                    {
                        for (int currentCol = col; currentCol <col+3; currentCol++)
                        {
                            currentMatrixSum += matrix[currentRow, currentCol];  
                        } 
                    }
                    if (currentMatrixSum > maxMatrixSum)
                    {
                        maxMatrixSum = currentMatrixSum;
                        indexRow = row;
                        indexCol = col;
                    }
                    currentMatrixSum = 0;
                }
            }
            Console.WriteLine($"Sum = {maxMatrixSum}");
            WriteMatrix(indexRow, indexCol, matrix);
        }
        public static int[,] ReadMatrix(int rows, int cols)
        {
            int[,] matrix = new int[rows, cols];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] currentRow = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int col = 0; col < currentRow.Length; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }
            return matrix;
        }
        public static  void WriteMatrix(int rows, int cols,int[,] matrix)
        {
            for (int row = rows; row < rows + 3; row++)
            {
                for (int col = cols; col < cols + 3; col++)
                {
                    Console.Write($"{ matrix[row, col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
