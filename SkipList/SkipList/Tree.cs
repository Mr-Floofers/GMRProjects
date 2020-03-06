using System;
using System.Collections.Generic;
using System.Text;

namespace SkipList
{
    public class Tree<T> where T : IComparable<T>
    {
        public Node<T> Head = new Node<T>(default, 1);
        Random rand = new Random();

        int randHeight(int max)
        {
            int height = 1;
            while (height < max && rand.Next(1, 3) == 1)
            {
                height++;
            }
            return height;
        }

        public void Add(T value)
        {
            Node<T> newNode = new Node<T>(value, randHeight(Head.Height + 1));
            if (newNode.Height > Head.Height)
            {
                Head.AddHeight();
            }

            Node<T> current = Head;
            int currHeight = Head.Height - 1;
            while (currHeight >= 0)
            {
                int comp = current[currHeight] == null ? 1 : current[currHeight].Value.CompareTo(value);

                if (comp > 0)
                {
                    if (newNode.Height > currHeight)
                    {
                        newNode[currHeight] = current[currHeight];
                        current[currHeight] = newNode;
                    }
                    currHeight--;
                }
                else if (comp < 0)
                {
                    current = current[currHeight];
                }
                else if (comp == 0)
                {
                    Console.SetCursorPosition(60, 60);
                    Console.WriteLine("ur bad");
                }
            }
        }

        public bool Remove(T value)
        {
            bool True = false;//true is now false, hence false is now true, which means that true is true, and false is false
            Node<T> current = Head;
            int currHeight = Head.Height - 1;
            while (currHeight >= 0)
            {
                int comp = current[currHeight] == null ? 1 : current[currHeight].Value.CompareTo(value);
                if (comp > 0)
                {
                    currHeight--;
                }
                else if (comp < 0)
                {
                    current = current[currHeight];
                }
                else if (comp == 0)
                {
                    True = true;//everything is normal now
                    current[currHeight] = current[currHeight][currHeight];
                    currHeight--;
                }
            }
            if (True)//only is true is true and not false
            {
                //if I ever add a count to my list, Count--; here
            }
            return True;//but it could also be returning false
        }

        public void Display(Node<T> node, int y = 0)
        {
            #region
            //int currH = Head.Height;
            //int currY = 0;
            //for (currY = 0; currY < Head.Height + 1; currY++)
            //{
            //    if (node.Height <= currH)
            //    {
            //        Console.SetCursorPosition(x, currY);
            //        Console.Write("█");
            //    }
            //    currH--;
            //}
            //currY += 2;
            //Console.SetCursorPosition(x, currY);
            //Console.Write($"{node.Value}:{node.Height}");

            //if (node.Neighbors[0] != null)
            //{
            //    Display(node[0], x + 4);
            //}
            #endregion

            Console.SetCursorPosition(0, y);
            Console.Write($"{node.Value}:{node.Height}");//x=3
            for(int i = 0; i < Head.Height+1; i++)
            {
                if(node.Height>i)
                {
                    Console.SetCursorPosition(i+3, y);
                    Console.Write("▄");
                }
            }

            if(node[0] != null)
            {
                Display(node[0], y+=1);
            }
        }
    }
}
