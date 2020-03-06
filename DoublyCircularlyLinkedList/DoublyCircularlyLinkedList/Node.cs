using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoublyCircularlyLinkedList
{
    public class Node<T>
    {
        public T value;
        public Node<T> next;
        public Node<T> pre;

        public Node(T value)
        {
            this.value = value;
        }
    }
}
