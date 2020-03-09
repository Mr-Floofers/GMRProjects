using System;
using System.Collections.Generic;
using System.Text;

namespace WeightedDirectedGraph
{
    class Vertex<T>
    {
        public T Value;
        public List<Vertex<T>> Neighbors;
        public Vertex(T value)
        {
            Value = value;
            Neighbors = new List<Vertex<T>>();
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
