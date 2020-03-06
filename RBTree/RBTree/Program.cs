using System;

namespace RBTree
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree<int> tree = new Tree<int>();
            tree.Add(10);
            tree.Add(15);
            tree.Add(5);
            tree.Add(20);
            tree.Add(1);
            tree.Add(7);
            tree.Add(12);
            tree.Remove(12);
            tree.Remove(5);
            tree.Remove(7);
            //Console.BackgroundColor = ConsoleColor.White;
            tree.Draw(tree.Root);

            Console.ReadKey();
        }
    }
}
