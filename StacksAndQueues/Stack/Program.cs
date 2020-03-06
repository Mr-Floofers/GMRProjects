using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    class ArrayStack
    {
        int[] data;
        int compacity;
        int count;
        public ArrayStack(int compacity = 10)
        {
            data = new int[compacity];
        }

        public void resize()
        {
            int[] newData = new int[data.Length * 2];
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = newData[i];
            }
            data = newData;
        }

        public int Pop()
        {
            count--;
            return data[count];
        }

        public void Push(int value)
        {
            if(count == data.Length)
            {
                resize();
            }
            data[count] = value;
            count++;
        }
        public int Peek()
        {
            return data[count--];
        }
        public bool Empty()
        {
            return count == 0;
        }
    }

    class LinkedListStack
    {
        LinkedList<int> data;
        int count => data.Count;
        public LinkedListStack()
        {
            data = new LinkedList<int>();
        }
        public void Push(int value)
        {
            data.AddFirst(value);
        }
        public int Pop()
        {
            int temp = data.First.Value;
            data.RemoveFirst();
            return temp;
        }
        public int peek()
        {
            return data.First.Value;
        }
        public bool Empty()
        {
            return count == 0;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
