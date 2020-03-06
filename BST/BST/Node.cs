using System;
using System.Collections.Generic;
using System.Text;

namespace BST
{
    public class Node<T>
    {
        public Node<T> Left;
        public Node<T> Right;
        public Node<T> Parent;
        public T Value;

        public int ChildCount()
        {
            int count = 2;
            if(Left == null)
            {
                count--;
            }
            if(Right == null)
            {
                count--;
            }
            return count;
        }

        public enum ChildType
        {
            Right,
            Left,
            Null
        }

        public ChildType IsRightChild()
        {
            if(Parent.Right == this && this != null)
            {
                return ChildType.Right;
            }
            else if(Parent.Left == this && this != null)
            {
                return ChildType.Left;
            }
            else
            {
                return ChildType.Null;
            }
        }        

        public Node<T> Child()
        {
            if (Right != null)
            {
                return Right;
            }
            else if (Left != null)
            {
                return Left;
            }
            return null;
        }

        public Node(T value)
        {
            this.Value = value;
        }
    }
}
