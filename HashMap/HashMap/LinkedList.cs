using System;
using System.Collections.Generic;
using System.Text;

namespace HashMap
{
    class LinkedList<T>
    {
        int Count = 0;
        Node<T> Head;



        public void AddLast(T val)
        {
            Count += 1;
            if(Head == null)
            {
                Head = new Node<T>(val);
                return;
            }
            Node<T> current = Head;
            Node<T> newNode = new Node<T>(val);
            for(int i = 0; i < Count; i++)
            {
                current = Head.Next;
            }
            current.Next = newNode;
        }
        public int GetCount()
        {
            return Count;
        }
    }
}
