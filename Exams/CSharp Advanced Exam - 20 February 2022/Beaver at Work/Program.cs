using System;
using System.Collections.Generic;
using System.Linq;

namespace Beaver_at_Work
{
    class Program
    {
        static int beaverRow;
        static int beaverCol;
        static char[,] matrix;
        static string lastDirection;
        static Stack<char> branches;
        static int woodBranchCount;
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());
            matrix = new char[matrixSize, matrixSize];
            woodBranchCount = 0;
            branches = new Stack<char>();
            for (int row = 0; row < matrixSize; row++)
            {
                char[] currentRow = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                for (int col = 0; col < currentRow.Length; col++)
                {
                    matrix[row, col] = currentRow[col];
                    if (matrix[row, col] == 'B')
                    {
                        beaverRow = row;
                        beaverCol = col;
                    }
                    else if (char.IsLower(matrix[row, col]))
                    {
                        woodBranchCount++;
                    }
                }
            }
            string command = Console.ReadLine();
            while (command != "end")
            {
                if (woodBranchCount == 0)
                {
                    break;
                }
                 lastDirection = command;
                if (command == "up")
                {
                    Move(-1, 0);
                }
                else if (command == "down")
                {
                    Move(1, 0);
                }
                else if (command == "left")
                {
                    Move(0, -1);
                }
                else if (command == "right")
                {
                    Move(0, 1);
                }
                command = Console.ReadLine();
            }
            if (woodBranchCount == 0)
            {
                Console.WriteLine($"The Beaver successfully collect {branches.Count} wood branches: {string.Join(", ",branches.Reverse())}.");
            }
            else
            {
                Console.WriteLine($"The Beaver failed to collect every wood branch. There are {woodBranchCount} branches left.");
            }
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row,col]} ");
                }
                Console.WriteLine();
            }
        }
        public static bool IsInside(int row , int col)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }
        public static void Move(int row, int col)
        {
            if (!IsInside(beaverRow + row, beaverCol + col))
            {
                if (branches.Count > 0)
                {
                    branches.Pop();
                }
                return;
            }
            matrix[beaverRow, beaverCol] = '-';
            beaverRow += row;
            beaverCol += col;
            if (char.IsLower(matrix[beaverRow, beaverCol]))
            {
                branches.Push(matrix[beaverRow, beaverCol]);
                matrix[beaverRow, beaverCol] = 'B';
                woodBranchCount--;
            }
            else if (matrix[beaverRow, beaverCol] == 'F')
            {
                matrix[beaverRow, beaverCol] = '-';
                if (lastDirection == "up")
                {
                    if (beaverRow == 0)
                    {
                        if (char.IsLower(matrix[matrix.GetLength(0)-1, beaverCol]))
                        {
                            branches.Push(matrix[matrix.GetLength(0) - 1, beaverCol]);
                            matrix[matrix.GetLength(0) - 1, beaverCol] = 'B';
                            beaverRow = matrix.GetLength(0) - 1;
                            woodBranchCount--;
                        }
                        else
                        {
                            matrix[matrix.GetLength(0) - 1, beaverCol] = 'B';
                            beaverRow = matrix.GetLength(0) - 1;
                        }
                    }
                    else if (char.IsLower(matrix[0, beaverCol]))
                    {
                        branches.Push(matrix[0, beaverCol]);
                        matrix[0, beaverCol] = 'B';
                        beaverRow = 0;
                        woodBranchCount--;
                    }
                    else
                    {
                        matrix[0, beaverCol] = 'B';
                        beaverRow = 0;
                    }
                }
                else if (lastDirection == "down")
                {
                    if (beaverRow == matrix.GetLength(0)-1)
                    {
                        if (char.IsLower(matrix[0, beaverCol]))
                        {
                            branches.Push(matrix[0, beaverCol]);
                            matrix[0, beaverCol] = 'B';
                            beaverRow = 0;
                            woodBranchCount--;
                        }
                        else
                        {
                            matrix[0, beaverCol] = 'B';
                            beaverRow = 0;
                        }
                    }
                    else if (char.IsLower(matrix[matrix.GetLength(0) - 1, beaverCol]))
                    {
                        branches.Push(matrix[matrix.GetLength(0) - 1, beaverCol]);
                        matrix[matrix.GetLength(0) - 1, beaverCol] = 'B';
                        beaverRow = matrix.GetLength(0) - 1;
                        woodBranchCount--;
                    }
                    else
                    {
                        matrix[matrix.GetLength(0) - 1, beaverCol] = 'B';
                        beaverRow = matrix.GetLength(0) - 1;
                    }
                }
                else if (lastDirection == "left")
                {
                    if (beaverCol == 0)
                    {
                        if (char.IsLower(matrix[beaverRow, matrix.GetLength(1)-1]))
                        {
                            branches.Push(matrix[beaverRow, matrix.GetLength(1) - 1]);
                            matrix[beaverRow, matrix.GetLength(1) - 1] = 'B';
                            beaverCol = matrix.GetLength(1) - 1;
                            woodBranchCount--;
                        }
                        else
                        {
                            matrix[beaverRow, matrix.GetLength(1) - 1] = 'B';
                            beaverCol = 0;
                        }
                    }
                    else if (char.IsLower(matrix[beaverRow, 0]))
                    {
                        branches.Push(matrix[beaverRow, 0]);
                        matrix[beaverRow, 0] = 'B';
                        beaverCol = 0;
                        woodBranchCount--;
                    }
                    else
                    {
                        matrix[beaverRow, 0] = 'B';
                        beaverCol = 0;
                    }
                }
                else if (lastDirection == "right")
                {
                    if (beaverCol == matrix.GetLength(1)-1)
                    {
                        if (char.IsLower(matrix[beaverRow, 0]))
                        {
                            branches.Push(matrix[beaverRow, 0]);
                            matrix[beaverRow, 0] = 'B';
                            beaverCol = 0;
                            woodBranchCount--;
                        }
                        else
                        {
                            matrix[beaverRow, 0] = 'B';
                            beaverCol = 0;
                        }
                    }
                    else if (char.IsLower(matrix[beaverRow, matrix.GetLength(1) - 1]))
                    {
                        branches.Push(matrix[beaverRow, matrix.GetLength(1) - 1]);
                        matrix[beaverRow, matrix.GetLength(1) - 1] = 'B';
                        beaverCol = matrix.GetLength(1) - 1;
                        woodBranchCount--;
                    }
                    else
                    {
                        matrix[beaverRow, matrix.GetLength(1) - 1] = 'B';
                        beaverCol = matrix.GetLength(1) - 1;
                    }
                }
            }
            else
            {
                matrix[beaverRow, beaverCol] = 'B';
            }
        }
    }
}
