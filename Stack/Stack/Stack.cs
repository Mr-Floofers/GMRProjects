using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    public class Stack <T>
    {
        public List<T> data;
        public int count;
        int capacity = 10;

        public Stack()
        {
            data = new List<T>();
        }

        public void Push(T value)
        {
            if(count+1 == capacity)
            {
                resize(capacity*2);
            }
            data.Add(value);
            count++;
        }
        public void Pop()
        {
            count--;
            data.RemoveAt(count);
        }
        public T peek()
        {
            return data[count - 1];
        }
        public void resize(int newMax)
        {
            data.Capacity = newMax;
        }

        public void clear()
        {
            data.Clear();
            capacity = 10;
            resize(capacity);
            count = 0;
        }
    }
}
