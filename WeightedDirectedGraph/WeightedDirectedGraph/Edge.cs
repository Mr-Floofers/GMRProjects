using System;
using System.Collections.Generic;
using System.Text;

namespace WeightedDirectedGraph
{
    class Edge<T>
    {
        public Vertex<T> Start;
        public Vertex<T> End;
        float Distance;

        public Edge(Vertex<T> start, Vertex<T> end, float distance)
        {
            Start = start;
            End = end;
            Distance = distance;
        }
        public override string ToString()
        {
            return Start.Value.ToString() + ", " + End.Value.ToString() + ", " + Distance;
        }
    }
}
