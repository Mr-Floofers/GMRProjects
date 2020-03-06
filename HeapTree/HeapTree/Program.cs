using System;

namespace HeapTree
{
    class Program
    {
        static void Main(string[] args)
        {
            PriorityQueue<int> tree = new PriorityQueue<int>(5);
            tree.Insert(16);
            tree.Insert(39);
            tree.Insert(36);
            tree.Insert(14);
            tree.Insert(30);
            tree.Pop();
            tree.Pop();
            tree.Pop();
            tree.Display(0);

            //int[] data = new int[] { 8, 3, 6, 1, 7, 2 };
            //data = tree.HeapSort(data);

            Console.ReadKey();
        }
    }
}
