using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._Radioactive_Mutant_Vampire_Bunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            char[,] matrix = ReadMatrix(matrixSize[0], matrixSize[1]);
            string command = Console.ReadLine();
            int playerRow = -1;
            int playerCol = -1;
            bool playerWin = false;
            bool playerDead = false;
            for (int i = 0; i < command.Length; i++)
            {
                if (playerWin)
                {
                    break;
                }
                else if (playerDead)
                {
                    break;
                }
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if (matrix[row, col] == 'P')
                        {
                            playerRow = row;
                            playerCol = col;
                        }
                    }
                }
                if (command[i] == 'U')
                {
                    if (playerRow - 1 >= 0)
                    {
                       
                        if (matrix[playerRow - 1, playerCol] == '.')
                        {
                            matrix[playerRow - 1, playerCol] = matrix[playerRow, playerCol];
                            matrix[playerRow, playerCol] = '.';
                            playerRow -= 1;
                        }
                        else
                        {
                            playerDead = true;
                            matrix[playerRow, playerCol] = '.';
                            playerRow -= 1;

                        }
                    }
                    else
                    {
                        playerWin = true;
                        matrix[playerRow, playerCol] = '.';
                    }
                }
                else if (command[i] == 'D')
                {
                    if (playerRow + 1 < matrix.GetLength(0))
                    {                      
                        if (matrix[playerRow + 1, playerCol] == '.')
                        {
                            matrix[playerRow + 1, playerCol] = matrix[playerRow, playerCol];
                            matrix[playerRow, playerCol] = '.';
                            playerRow += 1;
                        }
                        else
                        {
                            playerDead = true;
                            matrix[playerRow, playerCol] = '.';
                            playerRow += 1;
                        }
                    }
                    else
                    {
                        playerWin = true;
                        matrix[playerRow, playerCol] = '.';
                    }
                }
                else if (command[i] == 'L')
                {
                    if (playerCol - 1 >= 0)
                    {
                        if (matrix[playerRow, playerCol - 1] == '.')
                        {   
                            matrix[playerRow, playerCol - 1] = matrix[playerRow, playerCol];
                            matrix[playerRow, playerCol] = '.';
                            playerCol -= 1;
                        }
                        else
                        {              
                            playerDead = true;
                            matrix[playerRow, playerCol] = '.';
                            playerCol -= 1;
                        }
                    }
                    else
                    {
                        playerWin = true;
                        matrix[playerRow, playerCol] = '.';
                    }
                }
                else if (command[i] == 'R')
                {
                    if (playerCol + 1 < matrix.GetLength(1))
                    {
                        if (matrix[playerRow, playerCol + 1] == '.')
                        {
                            matrix[playerRow, playerCol + 1] = matrix[playerRow, playerCol];
                            matrix[playerRow, playerCol] = '.';
                            playerCol += 1;
                        }
                        else
                        {
                            playerDead = true;
                            matrix[playerRow, playerCol] = '.';
                            playerCol += 1;
                        }
                    }
                    else
                    {
                        playerWin = true;
                        matrix[playerRow, playerCol] = '.';
                    }
                }
                List<int> bunniesCoordinates = BunniesLocation(matrix);
                while (bunniesCoordinates.Count > 0)
                {
                    int bunnyRow = bunniesCoordinates[0];
                    int bunnyCol = bunniesCoordinates[1];
                    if (bunnyRow - 1 >= 0)
                    {
                        if (matrix[bunnyRow - 1, bunnyCol] == '.')
                        {
                            matrix[bunnyRow - 1, bunnyCol] = 'B';
                        }
                        else if (matrix[bunnyRow - 1, bunnyCol] == 'P')
                        {
                            matrix[bunnyRow - 1, bunnyCol] = 'B';
                            playerDead = true;
                        }
                    }
                    if (bunnyRow + 1 < matrix.GetLength(0))
                    {
                        if (matrix[bunnyRow + 1, bunnyCol] == '.')
                        {
                            matrix[bunnyRow + 1, bunnyCol] = 'B';
                        }
                        else if (matrix[bunnyRow + 1, bunnyCol] == 'P')
                        {
                            matrix[bunnyRow + 1, bunnyCol] = 'B';
                            playerDead = true;
                        }
                    }
                    if (bunnyCol - 1 >= 0)
                    {
                        if (matrix[bunnyRow, bunnyCol - 1] == '.')
                        {
                            matrix[bunnyRow, bunnyCol - 1] = 'B';
                        }
                        else if (matrix[bunnyRow, bunnyCol - 1] == 'P')
                        {
                            matrix[bunnyRow, bunnyCol - 1] = 'B';
                            playerDead = true;
                        }
                    }
                    if (bunnyCol + 1 < matrix.GetLength(1))
                    {
                        if (matrix[bunnyRow, bunnyCol + 1] == '.')
                        {
                            matrix[bunnyRow, bunnyCol + 1] = 'B';
                        }
                        else if (matrix[bunnyRow, bunnyCol + 1] == 'P')
                        {
                            matrix[bunnyRow, bunnyCol + 1] = 'B';
                            playerDead = true;
                        }
                    }
                    bunniesCoordinates.RemoveAt(0);
                    bunniesCoordinates.RemoveAt(0);
                }

            }
            if (playerWin)
            {
                PrintMatrix(matrix);
                Console.WriteLine($"won: {playerRow} {playerCol}");
            }
            else if (playerDead)
            {
                PrintMatrix(matrix);
                Console.WriteLine($"dead: {playerRow} {playerCol}");
            }
        }
        public static char[,] ReadMatrix(int rows, int cols)
        {
            char[,] matrix = new char[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                string currentRow = Console.ReadLine();
                for (int col = 0; col < currentRow.Length; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }
            return matrix;
        }
        public static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        public static List<int> BunniesLocation(char[,] matrix)
        {
            List<int> bunnyCoordinate = new List<int>();
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'B')
                    {
                        bunnyCoordinate.Add(row);
                        bunnyCoordinate.Add(col);

                    }
                }
            }
            return bunnyCoordinate;
        }

    }
}
