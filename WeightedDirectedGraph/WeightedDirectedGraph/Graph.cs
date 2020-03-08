using System;
using System.Collections.Generic;
using System.Text;

namespace WeightedDirectedGraph
{
    class Graph<T>
    {
        List<Vertex<T>> vertices;
        List<Edge<T>> edges;

        public void AddVertex(Vertex<T> vertex)
        {
            vertices.Add(vertex);
        }

        public void AddEdge(Vertex<T> start, Vertex<T> end, float distance)
        {
            edges.Add(new Edge<T>(start, end, distance));
            start.Neighbors.Add(end);
        }

        public void RemoveVertex(Vertex<T> vertex)
        {
            for (int i = 0; i < vertex.Neighbors.Count; i++)
            {
                vertex.Neighbors[i].Neighbors.Remove(vertex);
                vertex.Neighbors.Remove(vertex.Neighbors[i]);
            }
            foreach (Edge<T> edge in edges)
            {
                if (edge.Start == vertex || edge.End == vertex)
                {
                    edges.Remove(edge);
                }
            }
        }

        public void RemoveEdge(Vertex<T> start, Vertex<T> end)
        {
            foreach (Edge<T> edge in edges)
            {
                if (edge.Start == start && edge.End == end)
                {
                    bool removeNeighbors = true;
                    for (int i = 0; i < edges.Count; i++)
                    {
                        if (edges[i].Start == end && edges[i].End == start)
                        {
                            removeNeighbors = false;
                        }
                    }
                    if (removeNeighbors)
                    {
                        edge.Start.Neighbors.Remove(edge.End);
                        edge.End.Neighbors.Remove(edge.Start);
                    }
                    edges.Remove(edge);
                }
            }
        }
    }
}
