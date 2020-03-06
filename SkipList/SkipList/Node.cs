using System;
using System.Collections.Generic;
using System.Text;

namespace SkipList
{
    public class Node<T>
    {

        public T Value;
        public Node<T>[] Neighbors;
        public int Height
        {
            get { return Neighbors.Length; }
            set { Height = Neighbors.Length; }
        }



        public Node(T value, int height)
        {
            Value = value;
            //Height = height;
            Neighbors = new Node<T>[height];
        }

        public Node(int height) : this(default, height)
        {
        }

        public Node<T> this[int index]
        {
            get
            {
                return Neighbors[index];
            }
            set
            {
                Neighbors[index] = value;
            }
        }

        public void AddHeight()
        {
            //List<Node<T>> temp = new List<Node<T>>(Height + 1);
            var temp = new Node<T>[Height + 1];
            for (int i = 0; i < Neighbors.Length; i++)
            {
                temp[i] = (Neighbors[i]);
            }
            Neighbors = temp;
        }

    }
}
