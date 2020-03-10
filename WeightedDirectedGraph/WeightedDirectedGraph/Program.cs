using System;
using System.Collections.Generic;

namespace WeightedDirectedGraph
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph<int> graph = new Graph<int>();
            Vertex<int> thing0 = new Vertex<int>(0);
            Vertex<int> thing5 = new Vertex<int>(5);
            Vertex<int> thing7 = new Vertex<int>(7);
            Vertex<int> thing8 = new Vertex<int>(8);
            Vertex<int> thing9 = new Vertex<int>(9);

            graph.AddVertex(thing0);
            graph.AddVertex(thing5);
            graph.AddVertex(thing7);
            graph.AddVertex(thing8);
            graph.AddVertex(thing9);

            graph.AddEdge(thing0, thing8, 10);
            graph.AddEdge(thing0, thing5, 5);
            graph.AddEdge(thing5, thing8, 3);
            graph.AddEdge(thing8, thing5, 2);
            graph.AddEdge(thing7, thing0, 7);
            graph.AddEdge(thing5, thing7, 2);
            graph.AddEdge(thing8, thing9, 1);
            graph.AddEdge(thing9, thing7, 4);
            graph.AddEdge(thing7, thing9, 6);

            Queue<Vertex<int>> path = graph.BreadthFirstSearch(thing0, thing7);

            return;
        }
    }
}
