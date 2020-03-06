using System;
using System.Collections.Generic;
using System.Text;

namespace AVLT
{
    public class Tree<T> where T : IComparable<T>
    {
        public Node<T> Root;

        #region Balance And Rotate
        #region Left And Right Rotate
        Node<T> RightRotate(Node<T> node)
        {
            Node<T> temp = node.LeftNode;
            node.LeftNode = temp.RightNode;
            temp.RightNode = node;
            return temp;
        }

        Node<T> LeftRotate(Node<T> node)
        {
            Node<T> temp = node.RightNode;
            node.RightNode = temp.LeftNode;
            temp.LeftNode = node;
            return temp;
        }
        #endregion

        Node<T> Balance(Node<T> node)
        {
            if (node.BalanceVal() > 1)
            {
                if (node.RightNode.BalanceVal() < -1)
                {
                    node.RightNode = RightRotate(node.RightNode);
                }
                node = LeftRotate(node);
            }
            if (node.BalanceVal() < -1)
            {
                if (node.LeftNode.BalanceVal() > 1)
                {
                    node.LeftNode = LeftRotate(node.LeftNode);
                }
                node = RightRotate(node);
            }
            return node;
        }
        #endregion

        #region Adding Functions
        public void Add(T value)
        {
            if (Root == null)
            {
                Root = new Node<T>(value);
                return;
            }

            Root = add(Root, value);
        }
        Node<T> add(Node<T> current, T value)
        {
            if (current == null)
            {
                return current = new Node<T>(value);
            }

            if (current.Value.CompareTo(value) < 0)
            {
                current.RightNode = add(current.RightNode, value);
            }
            else if (current.Value.CompareTo(value) > 0)
            {
                current.LeftNode = add(current.LeftNode, value);
            }
            return Balance(current);
        }
        #endregion

        Node<T> min(Node<T> node)
        {
            if (node.LeftNode == null)
            {
                return node;
            }
            return min(node.LeftNode);
        }

        #region Removing Functions
        public void Remove(T value)
        {
            if (Root == null)
            {
                return;
            }
            Root = remove(Root, value);
        }

        Node<T> remove(Node<T> node, T value)
        {
            if (node == null)
            {
                return null;
            }
            if (node.Value.CompareTo(value) < 0)
            {
                node.RightNode = remove(node.RightNode, value);
            }
            else if (node.Value.CompareTo(value) > 0)
            {
                node.LeftNode = remove(node.LeftNode, value);
            }
            else
            {
                if (node.ChildCount() == 2)
                {
                    Node<T> tempNode = min(node.RightNode);
                    node.Value = tempNode.Value;
                    node.RightNode = remove(node.RightNode, tempNode.Value);
                }
                else
                {
                    return node.Child();
                }
            }
            return Balance(node);
        }
        #endregion


        public void Draw(Node<T> node, int x = 60, int y = 0, int mid = 30, int linediff = 1)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(node.Value);
            mid /= 2;

            if(node.LeftNode != null)
            {
                Draw(node.LeftNode, x - mid, y + linediff, mid, linediff);
            }
            if(node.RightNode != null)
            {
                Draw(node.RightNode, x+mid, y+linediff, mid, linediff);
            }
        }

    }
}