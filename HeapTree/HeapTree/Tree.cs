using System;
using System.Collections.Generic;
using System.Text;

namespace HeapTree
{
    class Tree<T> where T : IComparable<T>
    {
        T[] data;
        int Count;
        int Capacity;
        bool IsEmpty => data.Length == 0;

        public Tree(int capacity)
        {
            Capacity = capacity;
            data = new T[capacity];
            Count = 0;
        }

        public void Insert(T value)
        {
            Resize();
            data[Count] = value;
            Count++;
            HeapifyUp(Count - 1, data);
        }

        void HeapifyUp(int index, T[] heapData)
        {
            int parentIndex = Parent(index);
            if (index == 0)
            {
                return;
            }
            if (heapData[index].CompareTo(heapData[parentIndex]) < 0)
            {
                T temp = heapData[Parent(index)];
                heapData[Parent(index)] = heapData[index];
                heapData[index] = temp;
            }
            HeapifyUp(parentIndex, heapData);
        }


        public T Pop()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("ur bad");
            }
            T val = data[0];
            data[0] = data[Count - 1];
            data[Count - 1] = default(T);

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
                if (data[leftIndex].CompareTo(data[rightIndex]) < 0)
                {
                    Other = leftIndex;
                }
                else
                {
                    Other = rightIndex;
                }
            }

            if(data[Other].CompareTo(data[index]) <0)
            {
                T temp = data[index];
                data[index] = data[Other];
                data[Other] = temp;
            }

            HeapifyDown(Other);
        }

        public T[] HeapSort(T[] randData)
        {
            T[] finalData = new T[randData.Length];
            for(int i = 0; i < randData.Length; i++)
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
            T[] temp = new T[Capacity];
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
            Console.Write($"{data[index]} : {index}");

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
                    Display(LeftChild(index), (60+x)/2, y + 1, level);
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
