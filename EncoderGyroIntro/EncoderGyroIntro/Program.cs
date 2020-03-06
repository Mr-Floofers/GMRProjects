using System;

namespace EncoderGyroIntro
{
    class Program
    {

        static float EncoderGyroStuff(float Right, float Left, float D)//all units are centimeters
        {
            float L, B, R;

            if (Right < Left)
            {
                L = Right;
                B = Left;
            }
            else if (Left < Right)
            {
                B = Right;
                L = Left;
            }
            else
            {
                return 0f;
            }

            
            if(L == 0)
            {
                R = -(B * D) / -B;
            }
            else
            {
                R = (L * D) / (B - L);
            }
            //float littleR = (L * D) / (B - L);
            float C = (float)(2 * Math.PI * R);
            return (float)(360 * (L / C));
            //r = Ld/b-L
            //theta = 360(L/2pir)

        }

        static void Main(string[] args)
        {
            Console.WriteLine("Right");
            float Right = float.Parse(Console.ReadLine());
            Console.WriteLine("Left");
            float Left = float.Parse(Console.ReadLine());
            Console.WriteLine("D");
            float D = float.Parse(Console.ReadLine());
            Console.WriteLine($"{EncoderGyroStuff(Right, Left, D)}");
        }
    }
}
