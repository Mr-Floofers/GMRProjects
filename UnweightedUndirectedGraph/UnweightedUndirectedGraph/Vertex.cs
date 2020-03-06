using System;
using System.Collections.Generic;
using System.Text;

namespace UnweightedUndirectedGraph
{
    class Vertex<T>
    {
        public T Value;
        public int Count;
        public List<Vertex<T>> Neighbors;

        public Vertex(T val = default)
        {
            Value = val;
            Neighbors = new List<Vertex<T>>();
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
