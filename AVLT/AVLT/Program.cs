using System;

namespace AVLT
{



    class Point
    {
        int x;
        int y;

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int GetX() => x;
        public int GetY() => y;

        public static Point operator+(Point first, Point second)
        {
            return new Point(first.GetX() + second.GetX(), first.GetY() + second.GetY());
        }

        public override string ToString()
        {
            return $"({x},{y})";
        }

    }


    class Program
    {

        static void PrintMessage()
        {
            Console.WriteLine("meow");
        }


        void OtherMessage()
        {
            Console.WriteLine("woof");

        }

        static void Main(string[] args)
        {
            //Point p = new Point(5, 6);
            //Point p2 = new Point(1, 1);
            //Console.WriteLine(p + p2);

            var tree = new AVLT.Tree<int>();
            tree.Add(10);
            tree.Add(15);
            tree.Add(5);
            tree.Add(20);
            tree.Add(1);
            tree.Add(7);
            tree.Add(12);
            tree.Draw(tree.Root);
        }
    }
}
