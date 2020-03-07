using System;
using System.Collections.Generic;
using System.Text;

namespace UnweightedUndirectedGraph
{
    class Graph<T>
    {
        public List<Vertex<T>> Vertices { get; private set; }
        public int Count
        {
            get
            {
                return Vertices.Count;
            }
        }

        public Graph()
        {
            Vertices = new List<Vertex<T>>();
        }

        public void AddVertex(Vertex<T> vertex)
        {
            if (vertex == null || Vertices.Contains(vertex))
            {
                return;
            }
            Vertices.Add(vertex);
        }

        public void RemoveVertex(Vertex<T> vertex)
        {
            if (vertex == null)
            {
                return;
            }

            while (vertex.Neighbors.Count != 0)
            {
                vertex.Neighbors[0].Neighbors.Remove(vertex);
                vertex.Neighbors.Remove(vertex.Neighbors[0]);
            }

            Vertices.Remove(vertex);
            vertex = null;
        }
        public void AddEdge(Vertex<T> a, Vertex<T> b)
        {
            a.Neighbors.Add(b);
            b.Neighbors.Add(a);
        }

        public void RemoveEdge(Vertex<T> a, Vertex<T> b)
        {
            a.Neighbors.Remove(b);
            b.Neighbors.Remove(a);
        }

        public bool IsConnectd(Vertex<T> start, Vertex<T> end)
        {

            //have a path stack
            //have a hashmap visited

            

            //List<Vertex<T>> visited = new List<Vertex<T>>();
            //Stack<Vertex<T>> stack = new Stack<Vertex<T>>();

            //stack.Push(a);

            //while (stack.Count != 0)
            //{
            //    Vertex<T> temp = stack.Pop();
            //    visited.Add(temp);

            //    if (temp == b)
            //    {
            //        for (int i = 0; i < visited.Count; i++)
            //        {
            //            Console.WriteLine(visited[i].Value);
            //        }
            //        return true;
            //    }

            //    for (int i = 0; i < temp.Neighbors.Count; i++)
            //    {
            //        if (!visited.Contains(temp.Neighbors[i]))
            //        {
            //            stack.Push(temp.Neighbors[i]);
            //        }
            //    }
            //}
            //return false;

            //while (stack.Count != 0)
            //{
            //    Vertex<T> temp = stack.Pop();

            //    visited.Add(temp);
            //    if (temp == b)
            //    {
            //        for (int i = 0; i < visited.Count; i++)
            //        {
            //            Console.WriteLine(visited[i].Value);
            //        }
            //        return true;
            //    }
            //    foreach (Vertex<T> vertex in temp.Neighbors)
            //    {
            //        if (!visited.Contains(vertex))
            //        {
            //            stack.Push(vertex);
            //        }
            //    }
            //}
            //return false;
        }

        public Stack<Vertex<T>> DepthFirstSearch(Vertex<T> start, Vertex<T> end)
        {
            Stack<Vertex<T>> path = new Stack<Vertex<T>>();
            HashSet<Vertex<T>> visited = new HashSet<Vertex<T>>();

            Vertex<T> current = start;
            path.Push(current);

            while (current != end)
            {
                for (int i = 0; i < current.Neighbors.Count; i++)
                {
                    if (!visited.Contains(current.Neighbors[i]))
                    {
                        current = current.Neighbors[i];
                        path.Push(current);
                        visited.Add(current);
                        if (current.Neighbors.Count == 0)
                        {
                            path.Pop();
                            current = path.Peek();
                        }
                    }
                    
                }
            }
        }
    }
}
