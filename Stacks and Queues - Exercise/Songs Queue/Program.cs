using System;
using System.Collections.Generic;

namespace _6
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> songList = new Queue<string>(Console.ReadLine().Split(", "));
            string[] command = Console.ReadLine().Split();
            while (songList.Count>0)
            {
                if (command[0] == "Play")
                {
                    songList.Dequeue();
                    if (songList.Count == 0)
                    {
                        break;
                    }
                }
                else if (command[0] == "Add")
                {
                    string songName = "";
                    if (command.Length > 2)
                    {
                        for (int i = 1; i < command.Length; i++)
                        {
                            if (i > 1)
                            {
                                songName += " ";
                            }
                            songName += command[i];
                        }
                    }
                    else
                    {
                        songName = command[1];
                    }
                    if (!songList.Contains(songName))
                    {
                        songList.Enqueue(songName);
                    }
                    else
                    {
                        Console.WriteLine($"{songName} is already contained!");
                    }
                }
                else if (command[0] == "Show")
                {
                    Console.WriteLine(string.Join(", ",songList));
                }
                    command = Console.ReadLine().Split();
            }
            Console.WriteLine($"No more songs!");
        }
    }
}
