using System;
using System.Collections.Generic;
using System.Text;

namespace AVLT
{
    public class Node<T> //where T : IComparable<T>
    {
        public T Value;
        public Node<T> RightNode;
        public Node<T> LeftNode;

        public Node(T value)
        {
            Value = value;
        }

        public int Height()
        {
            int RightHeight = 0;
            int LeftHeight = 0;

            if (RightNode != null)
            {
                RightHeight = RightNode.Height();
            }
            if (LeftNode != null)
            {
                LeftHeight = LeftNode.Height();
            }


            if (LeftHeight > RightHeight)
            {
                return LeftHeight + 1;
            }
            return RightHeight + 1;
        }

        public int BalanceVal()
        {
            int RightHeight = 0;
            int LeftHeight = 0;
            if (RightNode != null)
            {
                RightHeight = RightNode.Height();
            }
            if (LeftNode != null)
            {
                LeftHeight = LeftNode.Height();
            }
            return RightHeight - LeftHeight;
        }

        public int ChildCount()
        {
            int childCount = 0;
            if (RightNode != null)
            {
                childCount++;
            }
            if (LeftNode != null)
            {
                childCount++;
            }
            return childCount;
        }

        public Node<T> Child()
        {
            if (LeftNode != null)
            {
                return LeftNode;
            }
            else if (RightNode != null)
            {
                return RightNode;
            }
            return null;
        }
    }
}
