using System;
using System.Collections.Generic;

namespace BST
{
    public class Tree<T> where T : IComparable<T>
    {
        public Node<T> Head;
        public int Count { get; private set; }
        public Tree()
        {

        }
        public void Add(T value)
        {
            Count++;
            if (Head == null)
            {
                Head = new Node<T>(value);
                return;
            }
            Node<T> current = Head;

            while (true)
            {
                if (value.CompareTo(current.Value) < 0)
                {
                    if (current.Left == null)
                    {
                        current.Left = new Node<T>(value);
                        current.Left.Parent = current;
                        return;
                    }

                    current = current.Left;
                }
                else
                {
                    if (current.Right == null)
                    {
                        current.Right = new Node<T>(value);
                        current.Right.Parent = current;
                        return;
                    }
                    current = current.Right;
                }
            }
        }

        public Node<T> Find(T value)
        {
            Node<T> current = Head;
            while (true)
            {
                if (value.CompareTo(current.Value) == 0)
                {
                    return current;
                }
                else if (value.CompareTo(current.Value) < 0)
                {
                    current = current.Left;
                }
                else
                {
                    current = current.Right;
                }
            }
        }

        public Node<T> max(Node<T> initalNode)
        {
            Node<T> current = initalNode;
            while (current.Right != null)
            {
                current = current.Right;
            }
            return current;
        }

        public void Remove(T value)
        {
            if (Head == null)
            {
                return;
            }
            Node<T> removalNode = Find(value);

            if (removalNode.ChildCount() == 0)
            {
                if (removalNode.IsRightChild() == Node<T>.ChildType.Right)
                {
                    removalNode.Parent.Right = null;
                    removalNode = null;
                }
                else if (removalNode.IsRightChild() == Node<T>.ChildType.Left)
                {
                    removalNode.Parent.Left = null;
                    removalNode = null;
                }
                else
                {
                    removalNode = null;
                    return;
                }
                Count--;
                return;
            }
            else if (removalNode.ChildCount() == 1)
            {
                if (removalNode.IsRightChild() == Node<T>.ChildType.Right)
                {
                    removalNode.Child().Parent = removalNode.Parent;
                    removalNode.Parent.Right = removalNode.Child();
                }
                else if (removalNode.IsRightChild() == Node<T>.ChildType.Left)
                {
                    removalNode.Child().Parent = removalNode.Parent;
                    removalNode.Parent.Left = removalNode.Child();
                }
            }
            else if (removalNode.ChildCount() == 2)
            {
                Node<T> temp = removalNode.Left;
                temp = max(temp);
                T val = temp.Value;
                Remove(val);
                removalNode.Value = val;
            }
        }

        public IEnumerable<T> PreOrder()
        {
            List<T> nodes = new List<T>();
            Stack<Node<T>> stuff = new Stack<Node<T>>();
            stuff.Push(Head);
            while (stuff.Count > 0)
            {
                Node<T> current = stuff.Pop();
                nodes.Add(current.Value);

                if (current.Right != null)
                {
                    stuff.Push(current.Right);
                }
                if (current.Left != null)
                {
                    stuff.Push(current.Left);
                }
            }
            return nodes;
        }

        public IEnumerable<T> InOrder()
        {
            List<T> nodes = new List<T>();
            Stack<Node<T>> stuff = new Stack<Node<T>>();
            Node<T> current = Head;

            while (current != null || stuff.Count != 0)
            {
                if (current != null)
                {
                    stuff.Push(current);
                    current = current.Left;
                }
                else
                {
                    current = stuff.Pop();
                    nodes.Add(current.Value);
                    current = current.Right;
                }
            }
            return nodes;
        }

        public IEnumerable<T> PostOrder()
        {
            List<T> nodes = new List<T>();
            Stack<Node<T>> stuff = new Stack<Node<T>>();

            stuff.Push(Head);
            while (stuff.Count > 0)
            {
                Node<T> current = Head;
                nodes.Add(current.Value);

                if (current.Left != null)
                {
                    stuff.Push(current.Left);
                }

                if (current.Right != null)
                {
                    stuff.Push(current.Right);
                }
            }
            return nodes;
        }

        public IEnumerable<T> BreadthFirst()
        {
            List<T> nodes = new List<T>();
            Queue<Node<T>> stuff = new Queue<Node<T>>();
            stuff.Enqueue(Head);
            while (stuff.Count != 0)
            {
                Node<T> current = stuff.Dequeue();
                nodes.Add(current.Value);
                if (current.Left != null)
                {
                    stuff.Enqueue(current.Left);
                }
                if (current.Right != null)
                {
                    stuff.Enqueue(current.Right);
                }
            }
            return nodes;
        }
    }
}
