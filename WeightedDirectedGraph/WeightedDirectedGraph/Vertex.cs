using System;
using System.Collections.Generic;
using System.Text;

namespace WeightedDirectedGraph
{
    class Vertex<T>
    {
        T Value;
        public List<Vertex<T>> Neighbors;
        public Vertex(T value)
        {
            Value = value;
        }
    }
}
