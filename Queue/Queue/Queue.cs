using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue
{
    public class Queue<T>
    {
        public List<T> data;
        public int Count;
        public T Head;
        public T Tail;

        public Queue()
        {
            data = new List<T>();
        }

        public void Enqueue(T value)
        {
            data.Add(value);
            Count++;
        }

        public void Dequeue()
        {
            List<T> newData = new List<T>();
            for(int i = 1; i < Count; i++)
            {
                newData.Add(data[i]);
            }
            data = newData;
            Count--;
        }

        public T Peek()
        {
            return data[0];
        }

        public void Clear()
        {
            data.Clear();
            Count = 0;
        }
    }
}
