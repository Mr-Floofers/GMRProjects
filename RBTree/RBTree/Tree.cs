using System;
using System.Collections.Generic;
using System.Text;

namespace RBTree
{
    public class Tree<T> where T : IComparable<T>
    {
        public Node<T> Root;

        public Tree()
        {

        }

        void flipColor(Node<T> current)
        {
            current.Red = !current.Red;
            if (current.Left != null)
            {
                current.Left.Red = !current.Left.Red;
            }
            if (current.Right != null)
            {
                current.Right.Red = !current.Right.Red;
            }
        }

        public Node<T> rotateLeft(Node<T> current)
        {
            Node<T> node = current.Right;
            current.Right = node.Left;
            node.Left = current;

            node.Red = current.Red;
            current.Red = true;
            return node;
        }

        public Node<T> rotateRight(Node<T> current)
        {
            Node<T> node = current.Left;
            current.Left = node.Right;
            node.Right = current;

            node.Red = current.Red;
            current.Red = true;
            return node;
        }

        public bool IsRed(Node<T> current)
        {
            return current == null ? false : current.Red;
        }

        public void Add(T value)
        {
            Root = Add(Root, value);
            Root.Red = false;
        }

        private Node<T> Add(Node<T> current, T value)
        {
            if (current == null)
            {
                return new Node<T>(value);
            }

            if (IsRed(current.Left) && IsRed(current.Right))
            {
                flipColor(current);
            }

            if (value.CompareTo(current.Value) < 0)
            {
                current.Left = Add(current.Left, value);
            }
            else if (value.CompareTo(current.Value) > 0)
            {
                current.Right = Add(current.Right, value);
            }
            else
            {
                throw new ArgumentException("ur bad, you already have that value");
            }
            if (IsRed(current.Right))
            {
                current = rotateLeft(current);
            }

            if (IsRed(current.Left) && IsRed(current.Left.Left))
            {
                current = rotateRight(current);
            }

            return current;
        }

        Node<T> rightMove(Node<T> node)
        {
            flipColor(node);
            if (IsRed(node.Right.Left))
            {
                node.Right = rotateRight(node.Right);
                node = rotateRight(node);
                flipColor(node);
                if (IsRed(node.Right.Right))
                {
                    node.Right = rotateLeft(node.Right);
                }
            }
            return node;
        }

        Node<T> leftMove(Node<T> node)
        {
            flipColor(node);
            if (IsRed(node.Left.Left))
            {
                node = rotateRight(node);
                flipColor(node);
            }
            return node;
        }

        public void Remove(T value)
        {
            Root = Remove(Root, value);
            if (Root != null)
            {
                Root = Remove(Root, value);
                if (Root != null)
                {
                    Root.Red = false;
                }
            }
        }

        private Node<T> Remove(Node<T> current, T value)
        {
            if (value.CompareTo(current.Value) < 0)
            {
                if (current.Left != null)
                {
                    if (!IsRed(current.Left) && !IsRed(current.Left.Left))
                    {
                        current = leftMove(current);
                    }
                    current.Left = Remove(current.Left, value);
                }
            }
            else
            {
                if (IsRed(current.Left))
                {
                    current = rotateRight(current);
                }
                if (current.Right == null && value.CompareTo(current.Value) == 0)
                {
                    return null;
                }
                if (current.Right != null)
                {
                    if (!IsRed(current.Right) && !IsRed(current.Right.Left))
                    {
                        current = rightMove(current);
                    }
                    if (value.CompareTo(current.Value) == 0)
                    {
                        Node<T> small = min(current.Right);
                        current.Value = small.Value;
                        current.Right = Remove(current.Right, small.Value);
                    }
                    else
                    {
                        current.Right = Remove(current.Right, value);
                    }
                }
            }
            return fix(current);
        }

        public Node<T> fix(Node<T> current)
        {
            if (IsRed(current.Right))
            {
                current = rotateLeft(current);
            }
            if (IsRed(current.Left) && IsRed(current.Left.Left))
            {
                current = rotateRight(current);
            }
            if (IsRed(current.Left) && IsRed(current.Right))
            {
                flipColor(current);
            }
            if (current.Left != null && IsRed(current.Left.Right) && !IsRed(current.Left.Left))
            {
                current.Left = rotateLeft(current.Left);
                if (IsRed(current.Left))
                {
                    current = rotateRight(current);
                }
            }
            return current;
        }

        Node<T> min(Node<T> node)
        {
            if (node.Left != null)
            {
                min(node.Left);
            }
            return node;
        }

        public void Draw(Node<T> current, int x = 60, int y = 0, int rowoffset = 30, int lineoffset = 1)
        {
            Console.SetCursorPosition(x, y);
            if(current.Red)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.Write(current.Value);
            rowoffset /= 2;

            if (current.Left != null)
            {
                Draw(current.Left, x - rowoffset, y + lineoffset, rowoffset, lineoffset);
            }
            if (current.Right != null)
            {
                Draw(current.Right, x + rowoffset, y + lineoffset, rowoffset, lineoffset);
            }
        }

    }
}
