using System;

namespace Selling
{
    class Program
    {
        private static int meRow;
        private static int meCol;
        private static int firstPillarRow = -1;
        private static int firstPillarCol = -1; 
        private static int secondPillarRow;
        private static int secondPillarCol;
        static void Main(string[] args)
        {
            int bakerySize = int.Parse(Console.ReadLine());
            char[,] bakery = new char[bakerySize, bakerySize];
            for (int row = 0; row < bakery.GetLength(0); row++)
            {
                string currentRow = Console.ReadLine();
                for (int col = 0; col < currentRow.Length; col++)
                {
                    bakery[row, col] = currentRow[col];
                    if(currentRow[col] == 'S')
                    {
                        meRow = row;
                        meCol = col;
                    }
                    if (currentRow[col] == 'O')
                    {
                        if (firstPillarRow == -1)
                        {
                            firstPillarRow = row;
                            firstPillarCol = col;
                        }
                        else
                        {
                            secondPillarRow = row;
                            secondPillarCol = col;
                        }
                    }
                }
            }
            string command = Console.ReadLine();
            int neededMoney = 0;
            while (true)
            {
                bakery[meRow, meCol] = '-';
                if (command == "up")
                {
                    if (OutOfRange(bakery, meRow - 1, meCol))
                    {
                        meRow--;
                        if (char.IsDigit(bakery[meRow, meCol]))
                        {
                            neededMoney += (int)Char.GetNumericValue(bakery[meRow, meCol]);
                        }
                        else if (bakery[meRow, meCol] == 'O')
                        {                         
                            if (meRow == firstPillarRow && meCol == firstPillarCol)
                            {
                                meRow = secondPillarRow;
                                meCol = secondPillarCol;
                                bakery[firstPillarRow, firstPillarCol] = '-';
                            }
                            else if (meRow == secondPillarRow && meCol == secondPillarCol)
                            {
                                meRow = firstPillarRow;
                                meCol = firstPillarCol;
                                bakery[secondPillarRow, secondPillarCol] = '-';
                            }
                        }
                        bakery[meRow, meCol] = 'S';
                        if (neededMoney >= 50)
                        {
                            break;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
                else if(command == "down")
                    {
                        if (OutOfRange(bakery, meRow + 1, meCol))
                        {
                            meRow++;
                            if (char.IsDigit(bakery[meRow, meCol]))
                            {
                                neededMoney += (int)Char.GetNumericValue(bakery[meRow, meCol]);
                            
                        }
                            else if (bakery[meRow, meCol] == 'O')
                            {
                                if (meRow == firstPillarRow && meCol == firstPillarCol)
                                {
                                    meRow = secondPillarRow;
                                    meCol = secondPillarCol;
                                    bakery[firstPillarRow, firstPillarCol] = '-';
                                }
                                else if (meRow == secondPillarRow && meCol == secondPillarCol)
                                {
                                    meRow = firstPillarRow;
                                    meCol = firstPillarCol;
                                    bakery[secondPillarRow, secondPillarCol] = '-';
                                }
                            }
                            bakery[meRow, meCol] = 'S';
                        if (neededMoney >= 50)
                        {
                            break;
                        }
                    }
                        else
                        {
                            break;
                        }
                    }
                else if (command == "left")
                {
                    if (OutOfRange(bakery, meRow, meCol-1))
                    {
                        meCol--;
                        if (char.IsDigit(bakery[meRow, meCol]))
                        {
                            neededMoney += (int)Char.GetNumericValue(bakery[meRow, meCol]);
                        }
                        else if (bakery[meRow, meCol] == 'O')
                        {
                            if (meRow == firstPillarRow && meCol == firstPillarCol)
                            {
                                meRow = secondPillarRow;
                                meCol = secondPillarCol;
                                bakery[firstPillarRow, firstPillarCol] = '-';
                            }
                            else if (meRow == secondPillarRow && meCol == secondPillarCol)
                            {
                                meRow = firstPillarRow;
                                meCol = firstPillarCol;
                                bakery[secondPillarRow, secondPillarCol] = '-';
                            }
                        }
                        bakery[meRow, meCol] = 'S';
                        if (neededMoney >= 50)
                        {
                            break;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
                else if (command == "right")
                {
                    if (OutOfRange(bakery, meRow, meCol + 1))
                    {
                        meCol++;
                        if (char.IsDigit(bakery[meRow, meCol]))
                        {
                            neededMoney += (int)Char.GetNumericValue(bakery[meRow, meCol]);
                            
                        }
                        else if (bakery[meRow, meCol] == 'O')
                        {
                            if (meRow == firstPillarRow && meCol == firstPillarCol)
                            {
                                meRow = secondPillarRow;
                                meCol = secondPillarCol;
                                bakery[firstPillarRow, firstPillarCol] = '-';
                            }
                            else if (meRow == secondPillarRow && meCol == secondPillarCol)
                            {
                                meRow = firstPillarRow;
                                meCol = firstPillarCol;
                                bakery[secondPillarRow, secondPillarCol] = '-';
                            }
                        }
                        bakery[meRow, meCol] = 'S';
                        if (neededMoney >= 50)
                        {
                            break;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
                command = Console.ReadLine();
            }
            if (neededMoney < 50)
            {
                Console.WriteLine($"Bad news, you are out of the bakery.");
            }
            else
            {
                Console.WriteLine($"Good news! You succeeded in collecting enough money!");
            }
            Console.WriteLine($"Money: {neededMoney}");
            for (int row = 0; row < bakery.GetLength(0); row++)
            {
                for (int col = 0; col < bakery.GetLength(1); col++)
                {
                    Console.Write(bakery[row,col]);
                }
                Console.WriteLine();
            }

        }
        public static bool OutOfRange(char [,] matrix , int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }
    }
}
