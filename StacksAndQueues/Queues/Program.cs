using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queues
{
    class LinkedListQueue
    {
        LinkedList<int> data;
        int count => data.Count;
        public LinkedListQueue ()
        {
            data = new LinkedList<int>();
        }

        public void Enqueue(int value)
        {
            data.AddLast(value);
        }

        public int Dequeue()
        {
            int temp = data.First.Value;
            data.RemoveFirst();
            return temp;
        }

        public int Peek()
        {
            return data.First.Value;
        }

        public bool IsEmpty()
        {
            return count == 0;
        }

        public void Clear()
        {
            data.Clear();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
