using System;

namespace Wall_Destroyer
{
    class Program
    {
        private static int createdHoles = 1;
        private static int hitRods;
        private static int vankoRow;
        private static int vankoCol;
        private static char[,] wall;
        private static bool isElectrocuted = false;
        static void Main(string[] args)
        {
            int sizeOfWall = int.Parse(Console.ReadLine());

            wall = new char[sizeOfWall, sizeOfWall];
            for (int row = 0; row < wall.GetLength(0); row++)
            {
                string currentRow = Console.ReadLine();
                for (int col = 0; col < currentRow.Length; col++)
                {
                    wall[row, col] = currentRow[col];
                    if (currentRow[col] == 'V')
                    {
                        vankoRow = row;
                        vankoCol = col;
                    }
                }
            }
            string command = Console.ReadLine();
            while (command != "End")
            {
                if (command == "up")
                {
                    if (OurOfRange(-1, 0))
                    {
                        Move(-1, 0);
                    }
                }
                else if (command == "down")
                {
                    if (OurOfRange(1, 0))
                    {
                        Move(1, 0);
                    }
                }
                else if (command == "left")
                {
                    if (OurOfRange(0, -1))
                    {
                        Move(0, -1);
                    }
                }
                else if (command == "right")
                {
                    if (OurOfRange(0, 1))
                    {
                        Move(0, 1);
                    }
                }
                if (isElectrocuted)
                {
                    Console.WriteLine($"Vanko got electrocuted, but he managed to make {createdHoles} hole(s).");
                    break;
                }
                command = Console.ReadLine();
            }
            if (!isElectrocuted)
            {
                Console.WriteLine($"Vanko managed to make {createdHoles} hole(s) and he hit only {hitRods} rod(s).");
            }
            for (int row = 0; row < wall.GetLength(0); row++)
            {
                for (int col = 0; col < wall.GetLength(1); col++)
                {
                    Console.Write(wall[row,col]);
                }
                Console.WriteLine();
            }

        }
        public static bool OurOfRange(int row, int col)
        {
            return vankoRow + row >= 0 && vankoRow + row < wall.GetLength(0) && vankoCol + col >= 0 && vankoCol + col < wall.GetLength(1);
        }
        public static void Move(int row, int col)
        {
            if (wall[vankoRow+row, vankoCol+col] == 'R')
            {
                hitRods++;
                Console.WriteLine("Vanko hit a rod!");
            }
            else if (wall[vankoRow+row, vankoCol+col] == 'C')
            {
                createdHoles++;
                wall[vankoRow + row, vankoCol + col] = 'E';
                wall[vankoRow, vankoCol] = '*'; 
                isElectrocuted = true;
            }
            else if (wall[vankoRow + row, vankoCol + col] == '*')
            {
                Console.WriteLine($"The wall is already destroyed at position [{vankoRow + row}, {vankoCol + col}]!");
                wall[vankoRow, vankoCol] = '*';
                wall[vankoRow + row, vankoCol + col] = 'V';
                vankoRow += row;
                vankoCol += col;
            }
            else if (wall[vankoRow + row, vankoCol + col] == '-')
            {
                createdHoles++;
                wall[vankoRow, vankoCol] = '*';
                wall[vankoRow + row, vankoCol + col] = 'V';
                vankoRow += row;
                vankoCol += col;
            }
        }
    }
}
