using System;
using System.Collections.Generic;
using System.Text;

namespace HeapTree
{
    class PriorityQueue<T> where T : IComparable<T>
    {
        public struct item
        {
            public item(int priority, T value)
            {
                Priority = priority;
                Value = value;
            }
            public int Priority;
            public T Value;
        }
        item[] data;
        int Count = 0;
        int Capacity;
        bool IsEmpty => data.Length == 0;
        Random rand = new Random();


        public PriorityQueue(int capacity)
        {
            Capacity = capacity;
            data = new item[capacity];
            Count = 0;
        }
        public void Insert(T value)
        {
            Resize();
            data[Count] = (new item(rand.Next(10), value));
            Count++;
            HeapifyUp(Count-1, data);
        }
        void HeapifyUp(int index, item[] heapData)
        {
            int parentIndex = Parent(index);
            if (index == 0)
            {
                return;
            }
            if (heapData[index].Priority.CompareTo(heapData[parentIndex].Priority) < 0)
            {
                item temp = heapData[Parent(index)];
                heapData[Parent(index)] = heapData[index];
                heapData[index] = temp;
            }
            HeapifyUp(parentIndex, heapData);
        }


        public item Pop()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("ur bad");
            }
            item val = data[0];
            data[0] = data[Count - 1];
            data[Count - 1] = default(item);

            Count--;
            HeapifyDown(0);
            return val;
        }

        void HeapifyDown(int index)
        {
            int leftIndex = LeftChild(index);
            if (leftIndex >= Count)
            {
                return;
            }

            int rightIndex = RightChild(index);
            int Other = 0;

            if (rightIndex >= Count)
            {
                Other = leftIndex;
            }
            else
            {
                if (data[leftIndex].Priority.CompareTo(data[rightIndex].Priority) < 0)
                {
                    Other = leftIndex;
                }
                else
                {
                    Other = rightIndex;
                }
            }

            if (data[Other].Priority.CompareTo(data[index].Priority) < 0)
            {
                item temp = data[index];
                data[index] = data[Other];
                data[Other] = temp;
            }

            HeapifyDown(Other);
        }

        public item[] HeapSort(item[] randData)
        {
            item[] finalData = new item[randData.Length];
            for (int i = 0; i < randData.Length; i++)
            {
                finalData[i] = randData[i];
                HeapifyUp(i, finalData);
            }
            return finalData;
        }

        #region UsefullFunctions
        void Resize()
        {
            if (Count == Capacity)
            {
                Capacity = Capacity += 5;
            }
            item[] temp = new item[Capacity];
            for (int i = 0; i < Count; i++)
            {
                temp[i] = data[i];
            }
            data = temp;
        }

        int Parent(int index)
        {
            return (index - 1) / 2;
        }
        int RightChild(int index)
        {
            return (2 * index) + 2;
        }
        int LeftChild(int index)
        {
            return (2 * index) + 1;
        }

        public void Display(int index)
        {
            System.Diagnostics.Debug.WriteLine($"Root: {data[index]}");
            Console.SetBufferSize(500, 500);
            Display(index, x: 60, y: 0, level: 0);
        }

        private void Display(int index, int x, int y, int level)
        {
            Console.SetCursorPosition(x, y);
            Console.Write($"{data[index].Value} : {index} : {data[index].Priority}");

            level++;

            if (LeftChild(index) < Count)
            {
                System.Diagnostics.Debug.WriteLine($"{new string(' ', level)}Left child of {data[index]} : {data[LeftChild(index)]}");
                if (x <= 60)
                {
                    Display(LeftChild(index), x / 2, y + 1, level);
                }
                else
                {
                    Display(LeftChild(index), (60 + x) / 2, y + 1, level);
                }
            }
            if (RightChild(index) < Count)
            {
                System.Diagnostics.Debug.WriteLine($"{new string(' ', level)}Right child of {data[index]} : {data[RightChild(index)]}");
                Display(RightChild(index), x + (x / 2), y + 1, level);
            }
        }
        #endregion 

    }
}
