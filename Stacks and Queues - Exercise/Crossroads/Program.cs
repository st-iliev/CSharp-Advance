using System;
using System.Collections.Generic;

namespace _10
{
    class Program
    {
        static void Main(string[] args)
        {
            int durationOfGreenLine = int.Parse(Console.ReadLine());
            int durationOfFreeWindow = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();
            Queue<string> cars = new Queue<string>();
            int passedCars = 0;
            while (command != "END")
            {
                if (command == "green")
                {
                    int greenLine = durationOfGreenLine;
                    int freeWindow = durationOfFreeWindow;
                    int partLeft = 0;
                    while (cars.Count > 0)
                    {
                        string currentCar = cars.Peek();
                        if (greenLine == 0)
                        {
                            break;
                        }
                        if (greenLine >= currentCar.Length)
                        {
                            greenLine -= currentCar.Length;
                            cars.Dequeue();
                            passedCars++;
                        }
                        else
                        {
                            partLeft = currentCar.Length - greenLine;
                            greenLine = 0;
                            if (freeWindow >= partLeft)
                            {
                                freeWindow -= partLeft;
                                cars.Dequeue();
                                passedCars++;
                                break;
                            }
                            else
                            {
                                Console.WriteLine($"A crash happened!");
                                Console.WriteLine($"{currentCar} was hit at {currentCar[greenLine + freeWindow+1]}.");
                                return;
                            }
                        }
                    }
                }
                else
                {
                    cars.Enqueue(command);
                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"Everyone is safe.");
            Console.WriteLine($"{passedCars} total cars passed the crossroads.");
        }
    }
}
