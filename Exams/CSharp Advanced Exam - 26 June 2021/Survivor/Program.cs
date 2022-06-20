using System;
using System.Linq;

namespace Survivor
{
    class Program
    {
        static void Main(string[] args)
        {
            int matrixRow = int.Parse(Console.ReadLine());
            char[][] jagged = new char[matrixRow][];
            for (int row = 0; row < jagged.Length; row++)
            {
               char[] currentRow = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                jagged[row] = new char[currentRow.Length];
                for (int col = 0; col < jagged[row].Length; col++)
                {
                    jagged[row][col] += currentRow[col];
                }  
            }
            string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int myTokens = 0;
            int opponentToekns = 0;
            while (command[0] != "Gong")
            {
                int row = int.Parse(command[1]);
                int col = int.Parse(command[2]);
                if (command[0] == "Find")
                {
                   
                    if (InRange(row, col, jagged) && jagged[row][col] == 'T')
                    {
                        myTokens++;
                        jagged[row][col] = '-';
                    }
                }
                else if (command[0] == "Opponent")
                {
                    string direction = command[3];
                    if (InRange(row, col, jagged) && jagged[row][col] == 'T')
                    {
                        opponentToekns++;
                        jagged[row][col] = '-';
                        if (direction == "up")
                        {
                            for (int i = 1; i < 4; i++)
                            {
                                if (InRange(row-i, col, jagged))
                                {
                                    if (jagged[row - i][col] == 'T')
                                    {
                                    opponentToekns++;
                                    jagged[row-i][col] = '-';
                                    }
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                        else if (direction == "down")
                        {
                            for (int i = 1; i < 4; i++)
                            {
                                if (InRange(row + i, col, jagged))
                                {
                                    if (jagged[row + i][col] == 'T')
                                    {
                                    opponentToekns++;
                                    jagged[row + i][col] = '-';
                                    }
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                        else if (direction == "left")
                        {
                            for (int i = 1; i < 4; i++)
                            {
                                if (InRange(row , col-i, jagged))
                                {
                                   if (jagged[row][col - i] == 'T')
                                    {
                                    opponentToekns++;
                                    jagged[row][col - i] = '-';
                                    }
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                        else if (direction == "right")
                        {
                            for (int i = 1; i < 4; i++)
                            {
                                if (InRange(row, col + i, jagged))
                                {
                                    if (jagged[row][col + i] == 'T')
                                    {
                                    opponentToekns++;
                                    jagged[row][col + i] = '-';
                                    }
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                    }
                }
                command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }
            for (int row = 0; row < jagged.GetLength(0); row++)
            {
                for (int col = 0; col < jagged[row].Length; col++)
                {
                    Console.Write(jagged[row][col]+" ");
                }
                Console.WriteLine();
            }
            Console.WriteLine($"Collected tokens: {myTokens}");
            Console.WriteLine($"Opponent's tokens: {opponentToekns}");
        }
        public static bool InRange(int row , int col , char[][] jagged)
        {
           if (row >= 0 && row < jagged.Length && col >= 0 && col < jagged[row].Length)
            {
                return true;
            }
            return false;
        }
    }
}
