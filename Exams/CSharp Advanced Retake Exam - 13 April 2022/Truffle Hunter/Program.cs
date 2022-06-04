using System;

namespace Truffle_Hunter
{
    class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());
            string[,] matrix = new string[matrixSize, matrixSize];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] currentRow = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                for (int col = 0; col < currentRow.Length; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }
            string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int peterBlackTrufflesCount = 0;
            int peterSummerTrufflesCount = 0;
            int peterWhiteTrufflesCount = 0;
            int boardEatenTrufflesCount = 0;
            while (command[0] != "Stop" && command[1] != "the" && command[2] != "hunt")
            {
                int row = int.Parse(command[1]);
                int col = int.Parse(command[2]);
                string direction = "";
                if (command.Length == 4)
                {
                    direction = command[3];
                }
                if (command[0] == "Collect")
                {
                    if (matrix[row, col] == "B")
                    {
                        peterBlackTrufflesCount += 1;
                        matrix[row, col] = "-";
                    }
                    else if (matrix[row, col] == "S")
                    {
                        peterSummerTrufflesCount += 1;
                        matrix[row, col] = "-";
                    }
                    else if (matrix[row, col] == "W")
                    {
                        peterWhiteTrufflesCount += 1;
                        matrix[row, col] = "-";
                    }
                }
                else
                {
                    if (direction == "up")
                    {
                        for (int i = row; i >= 0; i -= 2)
                        {
                            if (matrix[i, col] == "B")
                            {
                                boardEatenTrufflesCount += 1;
                                matrix[i, col] = "-";
                            }
                            else if (matrix[i, col] == "S")
                            {
                                boardEatenTrufflesCount += 1;
                                matrix[i, col] = "-";
                            }
                            else if (matrix[i, col] == "W")
                            {
                                boardEatenTrufflesCount += 1;
                                matrix[i, col] = "-";
                            }
                        }
                    }
                    else if (direction == "down")
                    {
                        for (int i = row; i < matrix.GetLength(0); i += 2)
                        {
                            if (matrix[i, col] == "B")
                            {
                                boardEatenTrufflesCount += 1;
                                matrix[i, col] = "-";
                            }
                            else if (matrix[i, col] == "S")
                            {
                                boardEatenTrufflesCount += 1;
                                matrix[i, col] = "-";
                            }
                            else if (matrix[i, col] == "W")
                            {
                                boardEatenTrufflesCount += 1;
                                matrix[i, col] = "-";
                            }
                        }
                    }
                    else if (direction == "left")
                    {
                        for (int i = col; i >= 0; i-=2)
                        {
                            if (matrix[row, i] == "B")
                            {
                                boardEatenTrufflesCount += 1;
                                matrix[row, i] = "-";
                            }
                            else if (matrix[row, i] == "S")
                            {
                                boardEatenTrufflesCount += 1;
                                matrix[row, i] = "-";
                            }
                            else if (matrix[row, i] == "W")
                            {
                                boardEatenTrufflesCount += 1;
                                matrix[row, i] = "-";
                            }
                        }
                    }
                    else if (direction == "right")
                    {
                        for (int i = col; i < matrix.GetLength(1); i += 2)
                        {
                            if (matrix[row, i] == "B")
                            {
                                boardEatenTrufflesCount += 1;
                                matrix[row, i] = "-";
                            }
                            else if (matrix[row, i] == "S")
                            {
                                boardEatenTrufflesCount += 1;
                                matrix[row, i] = "-";
                            }
                            else if (matrix[row, i] == "W")
                            {
                                boardEatenTrufflesCount += 1;
                                matrix[row, i] = "-";
                            }
                        }

                    }
                }
                command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }
            Console.WriteLine($"Peter manages to harvest {peterBlackTrufflesCount} black, {peterSummerTrufflesCount} summer, and {peterWhiteTrufflesCount} white truffles.");
            Console.WriteLine($"The wild boar has eaten {boardEatenTrufflesCount} truffles.");
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row,col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
