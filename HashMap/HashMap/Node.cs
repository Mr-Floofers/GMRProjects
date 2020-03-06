using System;
using System.Collections.Generic;
using System.Text;

namespace HashMap
{
    class Node<T>
    {
        public T Value;
        public Node<T> Next;
        public Node(T  val, Node<T> next = null)
        {
            Value = val;
            Next = next;
        }
    }
}
