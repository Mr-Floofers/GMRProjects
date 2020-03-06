using System;
using System.Collections.Generic;
using System.Text;

namespace RBTree
{
    public class Node<T>
    {
        public T Value;
        public Node<T> Right;
        public Node<T> Left;
        public bool Red = true;

        public Node(T value)
        {
            Value = value;
        }
    }
}
