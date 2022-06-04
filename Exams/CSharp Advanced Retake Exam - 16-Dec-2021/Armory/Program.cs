using System;
using System.Linq;

namespace Armory
{
    class Program
    {
        private static int officerRow;
        private static int officerCol;
        private static char[,] matrix;
        private static int gold;
        private static string direction;
        private static int firstMirrorRow = -1;
        private static int firstMirrorCol ;
        private static int secondMirrorRow ;
        private static int secondMirrorCol ;
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());
            matrix = new char[matrixSize, matrixSize];
           
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string currentRow = Console.ReadLine();
                for (int col = 0; col < currentRow.Length; col++)
                {
                    matrix[row, col] = currentRow[col];
                    if (matrix[row, col] == 'A')
                    {
                        officerRow = row;
                        officerCol = col;
                    }
                    else if (matrix[row, col] == 'M')
                    {
                        if (firstMirrorRow == -1)
                        {
                            firstMirrorRow = row;
                            firstMirrorCol = col;
                        }
                        else
                        {
                            secondMirrorRow = row;
                            secondMirrorCol = col;
                        }
                    }
                }
            }
            string command = Console.ReadLine();
            bool outOfArmory = false;
            while (true)
            {
                direction = command;
                if (command == "up")
                {
                    if (!OutOfArmory(officerRow - 1, officerCol))
                    {
                        outOfArmory = true;
                        matrix[officerRow, officerCol] = '-';
                        break;
                    }
                    Move(-1, 0);
                }
                else if (command == "down")
                {
                    if (!OutOfArmory(officerRow + 1, officerCol))
                    {
                        outOfArmory = true;
                        matrix[officerRow, officerCol] = '-';
                        break;
                    }
                    Move(1, 0);
                }
                else if (command == "left")
                {
                    if (!OutOfArmory(officerRow, officerCol - 1))
                    {
                        outOfArmory = true;
                        matrix[officerRow, officerCol] = '-';
                        break;
                    }
                    Move(0, -1);
                }
                else if (command == "right")
                {
                    if (!OutOfArmory(officerRow, officerCol + 1))
                    {
                        outOfArmory = true;
                        matrix[officerRow, officerCol] = '-';
                        break;
                    }
                    Move(0, 1);
                }
                if (gold >= 65)
                {
                    break;
                }
                command = Console.ReadLine();
            }
            if (outOfArmory)
            {
                Console.WriteLine($"I do not need more swords!");
            }
            else
            {
                Console.WriteLine($"Very nice swords, I will come back for more!");
            }
            Console.WriteLine($"The king paid {gold} gold coins. ");
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row,col]}");
                }
                Console.WriteLine();
            }
        }
        public static void Move(int row, int col)
        {
            if (direction == "up")
            {
                if (matrix[officerRow - 1, officerCol] == 'M')
                {
                    MirrorFound(officerRow - 1, officerCol);
                }
               else  if (char.IsDigit(matrix[officerRow-1, officerCol]))
                {
                    gold += (int)Char.GetNumericValue((matrix[officerRow - 1, officerCol]));
                    matrix[officerRow, officerCol] = '-';
                    matrix[officerRow-1, officerCol] = 'A';
                    officerRow = officerRow - 1;
                }
                else
                {
                    matrix[officerRow, officerCol] = '-';
                    matrix[officerRow - 1, officerCol] = 'A';
                    officerRow = officerRow + 1;
                }
            }
            else if (direction == "down")
            {
                if (matrix[officerRow +1, officerCol] == 'M')
                {
                    MirrorFound(officerRow + 1, officerCol);
                }
                else if (char.IsDigit(matrix[officerRow + 1, officerCol]))
                {
                    gold += (int)Char.GetNumericValue((matrix[officerRow + 1, officerCol]));
                    matrix[officerRow, officerCol] = '-';
                    matrix[officerRow + 1, officerCol] = 'A';
                    officerRow = officerRow + 1;
                }
                else
                {
                    matrix[officerRow, officerCol] = '-';
                    matrix[officerRow + 1, officerCol] = 'A';
                    officerRow = officerRow + 1;
                }
            }
            else if (direction == "left")
            {
                if (matrix[officerRow, officerCol-1] == 'M')
                {
                    MirrorFound(officerRow, officerCol-1);
                }
                else if (char.IsDigit(matrix[officerRow, officerCol-1]))
                {
                    gold += (int)Char.GetNumericValue((matrix[officerRow, officerCol - 1]));
                    matrix[officerRow, officerCol] = '-';
                    matrix[officerRow, officerCol-1] = 'A';
                    officerCol = officerCol - 1;
                }
                else
                {
                    matrix[officerRow, officerCol] = '-';
                    matrix[officerRow, officerCol-1] = 'A';
                    officerCol = officerCol - 1;
                }
            }
            else if (direction == "right")
            {
                if (matrix[officerRow, officerCol+1] == 'M')
                {
                    MirrorFound(officerRow, officerCol+1);
                }
               else  if (char.IsDigit(matrix[officerRow, officerCol + 1]))
                {
                    gold += (int)Char.GetNumericValue((matrix[officerRow, officerCol + 1]));
                    matrix[officerRow, officerCol] = '-';
                    matrix[officerRow, officerCol + 1] = 'A';
                    officerCol = officerCol + 1;
                }
                else
                {
                    matrix[officerRow, officerCol] = '-';
                    matrix[officerRow, officerCol + 1] = 'A';
                    officerCol = officerCol + 1;
                }
            }
     
        }
        public static bool OutOfArmory(int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }
        public static void MirrorFound(int mirRow , int mirCol)
        {
            matrix[officerRow, officerCol] = '-';
           if (firstMirrorRow == mirRow && firstMirrorCol == mirCol)
            {
                officerRow = secondMirrorRow;
                officerCol = secondMirrorCol;
                matrix[mirRow, mirCol] = '-';
                matrix[officerRow, officerCol] = 'A';
            }
           else if (secondMirrorRow == mirRow && secondMirrorCol == mirCol)
            {
                officerRow = firstMirrorRow;
                officerCol = firstMirrorCol;
                matrix[mirRow, mirCol] = '-';
                matrix[officerRow, officerCol] = 'A';
            }
        }

    }
}
