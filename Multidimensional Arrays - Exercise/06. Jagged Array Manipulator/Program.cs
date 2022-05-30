using System;
using System.Linq;
using System.Numerics;

namespace _06._Jagged_Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            long matrixRow = long.Parse(Console.ReadLine());
            double[][] jagged = ReadJaggedArray(matrixRow);
            for (long i = 0; i < jagged.Length - 1; i++)
            {
                if (jagged[i].Length == jagged[i + 1].Length)
                {
                    for (long r = 0; r < jagged[i].Length; r++)
                    {
                        jagged[i][r] *= 2;
                        jagged[i + 1][r] *= 2;
                    }
                }
                else
                {
                    long mostLengthRow = 0;
                    if (jagged[i].Length > jagged[i + 1].Length)
                    {
                        mostLengthRow = jagged[i].Length;
                    }
                    else
                    {
                        mostLengthRow = jagged[i + 1].Length;
                    }
                    for (long r = 0; r < mostLengthRow; r++)
                    {
                        if (jagged[i].Length > r)
                        {
                                jagged[i][r] /= 2;
                        }
                        if (jagged[i+1].Length > r)
                        {
                            jagged[i + 1][r] /= 2;               
                        }
                    }
                }
            }
            string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            while (command[0] != "End")
            {
                long row = long.Parse(command[1]);
                long col = long.Parse(command[2]);
                long value = long.Parse(command[3]);
                if (command[0] == "Add")
                {
                    if (row >= 0 && row < matrixRow && col >= 0 && col < jagged[row].Length)
                    {
                        jagged[row][col] += value;
                    }

                }
                else if (command[0] == "Subtract")
                {
                    if (row >= 0 && row < matrixRow && col >= 0 && col < jagged[row].Length)
                    {
                        jagged[row][col] -= value;
                    }
                }
                command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }
            PrlongJaggedArray(jagged);
        }

        public static double[][] ReadJaggedArray(long rows)
        {
            double[][] jaggedArray = new double[rows][];
            for (long row = 0; row < rows; row++)
            {
                jaggedArray[row] = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
            }
            return jaggedArray;
        }
        public static void PrlongJaggedArray(double[][] jaggedArray)
        {
            for (long row = 0; row < jaggedArray.Length; row++)
            {
                for (long col = 0; col < jaggedArray[row].Length; col++)
                {
                    Console.Write($"{jaggedArray[row][col]} ");
                }
                Console.WriteLine();
            }

        }
    }
}
