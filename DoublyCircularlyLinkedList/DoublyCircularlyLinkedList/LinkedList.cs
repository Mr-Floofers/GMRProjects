using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoublyCircularlyLinkedList
{
    public class LinkedList<T> where T : IComparable<T>
    {
        public Node<T> Head;
        public Node<T> Tail
        {
            get
            {
                return Head.pre;
            }
        }

        public int Count { get; private set; }

        public LinkedList()
        {
            Count = 0;
        }

        public void AddFirst(T value)
        {
            Count++;
            if (Head == null)
            {
                Head = new Node<T>(value);
                Head.next = Head;
                Head.pre = Head;

                return;
            }


            Node<T> newNode = new Node<T>(value);
            newNode.next = Head;
            newNode.pre = Tail;
            Head = newNode;
        }
        public void AddLast(T value)
        {
            Count++;
            if (Head == null)
            {
                Head = new Node<T>(value);
                Head.next = Head;
                Head.pre = Head;

                return;
            }
            Node<T> newNode = new Node<T>(value);
            Tail.next = newNode;
            Head.pre = newNode;
        }

        public void AddBefore(T value, int index)
        {
            Count++;
            if (Head == null)
            {
                Head = new Node<T>(value);
                Head.next = Head;
                Head.pre = Head;

                return;
            }

            Node<T> newNode = new Node<T>(value);
            Node<T> current = Head;
            for (int i = 0; i < index-1; i++)
            {
                current = current.next;
            }

            newNode.next = current.next;
            newNode.pre = current;
            current.next.pre = newNode;
            current.next = newNode;
        }

        public void AddAfter(T value, int index)
        {
            Count++;
            if (Head == null)
            {
                Head = new Node<T>(value);
                //Tail = Head;
                Head.pre = Tail;
                Head.next = Tail;
                Tail.next = Head;
                Tail.pre = Head;

                return;
            }

            Node<T> newNode = new Node<T>(value);
            Node<T> current = Head;
            for (int i = 0; i < index; i++)
            {
                current = current.next;
            }
            newNode.pre = current;
            newNode.next = current.next;
            current.next.pre = newNode;
            current.next = newNode;
        }

        public void RemoveFirst()
        {
            if (Head == null)
            {
                return;
            }
            Count--;

            Tail.next = Head.next;
            Head.next.pre = Tail;
            Head = Head.next;
        }

        public void RemoveLast()
        {
            if (Head == null)
            {
                return;
            }
            Count--;

            Head.pre = Tail.pre;
            Tail.pre.next = Head;
            
        }

        public void Remove(T value)
        {
            if (Head == null)
            {
                return;
            }
            Count--;
            Node<T> current = Head;
            while (current.value.CompareTo(value) != 0)
            {
                current = current.next;
            }
            current.pre.next = current.next;
            current.next.pre = current.pre;
            current = null;
        }
        bool isEmpty()
        {
            if (Head == null)
            {
                return true;
            }
            return false;
        }


    }
}
