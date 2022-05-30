using System;
using System.Linq;

namespace _07._Knight_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());
            char[][] jagged = ReadMatrix(matrixSize);
            int removedKnight = 0;
            int knightAttacks = 0;
            for (int maxAttacks = 8; maxAttacks > 0; maxAttacks--)
            {
                for (int row = 0; row < jagged.Length; row++)
                {
                    for (int col = 0; col < jagged[row].Length; col++)
                    {
                        if (jagged[row][col] == 'K')
                        {
                            knightAttacks = 0;
                            if (col - 1 >= 0)
                            {
                                if (row - 2 >= 0)
                                {
                                    if (jagged[row - 2][col - 1] == 'K')
                                    {
                                        knightAttacks++;
                                    }
                                }
                                if (row + 2 < jagged.Length)
                                {
                                    if (jagged[row + 2][col - 1] == 'K')
                                    {
                                        knightAttacks++;
                                    }
                                }
                            }
                            if (col + 1 < jagged[row].Length)
                            {
                                if (row - 2 >= 0)
                                {
                                    if (jagged[row - 2][col + 1] == 'K')
                                    {
                                        knightAttacks++;
                                    }
                                }
                                if (row + 2 < jagged.Length)
                                {
                                    if (jagged[row + 2][col + 1] == 'K')
                                    {
                                        knightAttacks++;
                                    }
                                }
                            }
                            if (col - 2 >= 0)
                            {
                                if (row - 1 >= 0)
                                {
                                    if (jagged[row - 1][col - 2] == 'K')
                                    {
                                        knightAttacks++;
                                    }
                                }
                                if (row + 1 < jagged.Length)
                                {
                                    if (jagged[row + 1][col - 2] == 'K')
                                    {
                                        knightAttacks++;
                                    }
                                }
                            }
                            if (col + 2 < jagged[row].Length)
                            {
                                if (row - 1 >= 0)
                                {
                                    if (jagged[row - 1][col + 2] == 'K')
                                    {
                                        knightAttacks++;
                                    }
                                }
                                if (row + 1 < jagged.Length)
                                {
                                    if (jagged[row + 1][col + 2] == 'K')
                                    {
                                        knightAttacks++;
                                    }
                                }
                            }
                            if (knightAttacks == maxAttacks)
                            {
                                jagged[row][col] = '0';
                                removedKnight++;
                                knightAttacks = 0;
                            }
                        }
                        
                    }
                }
            }
            Console.WriteLine(removedKnight);
        }
        public static char[][] ReadMatrix(int rows)
        {
            char[][] jaggedArray = new char[rows][];
            for (int row = 0; row < jaggedArray.Length; row++)
            {
                jaggedArray[row] = Console.ReadLine().Trim().ToCharArray();
            }
            return jaggedArray;
        }

    }
}
