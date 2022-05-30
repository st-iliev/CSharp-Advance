using System;
using System.Linq;

namespace _09._Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());
            string[] commands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            char[,] matrix = ReadMatrix(matrixSize);
            int currentRow = 0;
            int currentCol = 0;
            int totalCoals = 0;
            int currentCoals = 0;
            bool eIsFound = false;
            for (int i = 0; i < commands.Length; i++)
            {
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if (matrix[row, col] == 's')
                        {
                            currentRow = row;
                            currentCol = col;
                        }
                        if (i == 0)
                        {
                            if (matrix[row, col] == 'c')
                            {
                                totalCoals++;
                            }
                        }

                    }
                }
                if (commands[i] == "up")
                {
                    if (currentRow - 1 >=0)
                    {
                        if (matrix[currentRow - 1, currentCol] == 'c')
                        {
                            currentCoals++;
                            if (currentCoals == totalCoals)
                            {
                                currentRow -= 1;
                                break;
                            }
                        }
                        else if (matrix[currentRow - 1, currentCol] == 'e')
                        {
                            currentRow -= 1;
                            Console.WriteLine($"Game over! ({currentRow}, {currentCol})");
                            return;
                        }
                            matrix[currentRow - 1, currentCol] = matrix[currentRow, currentCol];
                        
                            matrix[currentRow, currentCol] = '*';
                        currentRow -= 1;
                    }                  
                }
                else if (commands[i] == "down")
                {
                    if (currentRow + 1 < matrix.GetLength(0))
                    {
                        if (matrix[currentRow +1, currentCol] == 'c')
                        {
                            currentCoals++;
                            if (currentCoals == totalCoals)
                            {
                                currentRow += 1;
                                break;
                            }
                        }
                        else if (matrix[currentRow + 1, currentCol] == 'e')
                        {
                            currentRow += 1;
                            Console.WriteLine($"Game over! ({currentRow}, {currentCol})");
                            return;
                        }
                        matrix[currentRow + 1, currentCol] = matrix[currentRow, currentCol];
                            matrix[currentRow, currentCol] = '*';
                        currentRow += 1;
                    }
                }
                else if (commands[i] == "left")
                {
                    if (currentCol - 1 >= 0)
                    {
                        if (matrix[currentRow , currentCol-1] == 'c')
                        {
                            currentCoals++;
                            if (currentCoals == totalCoals)
                            {
                                currentCol -= 1;
                                break;
                            }
                        }
                        else if (matrix[currentRow , currentCol-1] == 'e')
                        {
                            currentCol -= 1;
                            Console.WriteLine($"Game over! ({currentRow}, {currentCol})");
                            return;
                        }
                        matrix[currentRow, currentCol - 1] = matrix[currentRow, currentCol];
                        matrix[currentRow, currentCol] = '*';
                        currentCol -= 1;
                    }
                }
                else if (commands[i] == "right")
                {
                    if (currentCol +1 < matrix.GetLength(1))
                    {
                        if (matrix[currentRow, currentCol + 1] == 'c')
                        {
                            currentCoals++;
                            if (currentCoals == totalCoals)
                            {
                                currentCol += 1;
                                break;
                            }
                        }
                        else if (matrix[currentRow, currentCol + 1] == 'e')
                        {
                            currentCol += 1;
                            Console.WriteLine($"Game over! ({currentRow}, {currentCol})");
                            return;
                           
                        }
                        matrix[currentRow, currentCol+1] = matrix[currentRow, currentCol];
                        matrix[currentRow, currentCol] = '*';
                        currentCol += 1;
                    }
                }
            }
            if (totalCoals == currentCoals)
            {
                Console.WriteLine($"You collected all coals! ({currentRow}, {currentCol})");
            }
            else
            {
                Console.WriteLine($"{totalCoals-currentCoals} coals left. ({currentRow}, {currentCol})");
            }

        }
        public static char[,] ReadMatrix(int rows)
        {
            char[,] matrix = new char[rows, rows];
            for (int row = 0; row < rows; row++)
            {
                char[] currentRow = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                for (int col = 0; col < currentRow.Length; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }
            return matrix;
        }
       
    }
}
