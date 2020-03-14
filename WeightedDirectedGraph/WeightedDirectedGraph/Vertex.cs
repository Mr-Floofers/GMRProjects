using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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

        public int CompareTo([AllowNull] T other)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
