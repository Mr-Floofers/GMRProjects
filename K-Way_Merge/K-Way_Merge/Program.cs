using System;
using System.Collections.Generic;

namespace K_Way_Merge
{
    class Program
    {
        static Queue<T> ConvertToQueue<T>(List<T> data) where T : IComparable<T>
        {
            Queue<T> queue = new Queue<T>();
            for (int i = 0; i < data.Count; i++)
            {
                queue.Enqueue(data[i]);
            }
            return queue;
        }

        static List<T> SmallestList<T>(List<List<T>> listList) where T : IComparable<T>
        {
            int index = 0;
            for (int i = 0; i < listList.Count; i++)
            {
                if (listList[i].Count != 0 && listList[index].Count != 0)
                {
                    if (listList[i][0].CompareTo(listList[index][0]) < 0)
                    {
                        index = i;
                    }
                }
                else if(listList[i].Count != 0)
                {
                    index = i;
                }


            }
            return listList[index];
        }

        static List<T> Merge<T>(List<List<T>> data) where T : IComparable<T>
        {
            int totalSum = 0;
            for (int i = 0; i < data.Count; i++)
            {
                for (int k = 0; k < data[i].Count; k++)
                {
                    totalSum++;
                }
            }
            List<T> finalList = new List<T>();
            List<T> current;
            for (int i = 0; i < totalSum + 1; i++)
            {
                current = SmallestList(data);
                if (current.Count != 0)
                {
                    finalList.Add(ConvertToQueue(current).Dequeue());
                    current.RemoveAt(0);
                }
            }
            return finalList;
        }

        static Random gen = new Random();
        static List<int> GetNLengthList(int n)
        {
            List<int> list = new List<int>();

            for (int i = 0; i < n; i++)
            {
                list.Add(gen.Next(100));
            }
            list.Sort();

            return list;
        }


        public static void Main(string[] args)
        {
            //List<int> list1 = new List<int>() { 1, 4, 6, 8 };
            //List<int> list2 = new List<int>() { 2, 3, 7, 9 };
            //List<int> list3 = new List<int>() { 5 };
            //List<List<int>> totalList = new List<List<int>>() { list1, list2, list3 };

            List<List<int>> totalList = new List<List<int>>();

            int size = gen.Next(5, 15);
            for (int i = 0; i < size; i++)
            {
                totalList.Add(GetNLengthList(gen.Next(5,20)));
            }

            List<int> finalList = Merge<int>(totalList);
            Console.ReadKey();
        }
    }
}
