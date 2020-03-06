using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingTextFromFileExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines(@"D:\FOR DENNIS\KnightPack\valiant_knight\style_B\spritesheet\spritesheet.txt");

            for (int i = 0; i < lines.Length; i++)
            {
                string[] items = lines[i].Split('/', '=');

                string state = items[0];

                int index = int.Parse(items[1].Replace("frame", "").TrimEnd());

                string[] rectangle = items[2].TrimStart().Split(' ');
                int[] betterRect = new int[rectangle.Length];
                if(state == "run")
                {
                    for (int j = 0; j < rectangle.Length; j++)
                    {
                        betterRect[j] = int.Parse(rectangle[j]);
                    }
                    //frames.Add(new Rectangle(betterRect[0], betterRect[1], betterRect[2], betterRect[3]));
                    Console.WriteLine(lines[i]);
                    Console.WriteLine(state);
                    for (int k = 0; k < betterRect.Length; k++)
                    {
                        Console.WriteLine(betterRect[k]);
                    }
                    for (int k = 0; k < rectangle.Length; k++)
                    {
                        Console.WriteLine(rectangle[k]);
                    }
                }
                
            }

            Console.ReadKey();
        }
    }
}
