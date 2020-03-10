using System;
using System.Collections.Generic;
using System.Text;

namespace WeightedDirectedGraph
{
    class Graph<T>
    {
        List<Vertex<T>> vertices = new List<Vertex<T>>();
        List<Edge<T>> edges = new List<Edge<T>>();

        public void AddVertex(Vertex<T> vertex)
        {
            vertices.Add(vertex);
        }

        public void AddEdge(Vertex<T> start, Vertex<T> end, float distance)
        {
            edges.Add(new Edge<T>(start, end, distance));
            if (!start.Neighbors.Contains(end))
            {
                start.Neighbors.Add(end);
                end.Neighbors.Add(start);
            }
        }

        public void RemoveVertex(Vertex<T> vertex)
        {
            for (int i = 0; i < vertex.Neighbors.Count; i++)
            {
                vertex.Neighbors[i].Neighbors.Remove(vertex);
                vertex.Neighbors.Remove(vertex.Neighbors[i]);
                i--;
            }
            for (int i = 0; i < edges.Count; i++)
            {
                if (edges[i].Start == vertex || edges[i].End == vertex)
                {
                    edges.Remove(edges[i]);
                    i--;
                }
            }
            vertices.Remove(vertex);
        }

        public void RemoveEdge(Vertex<T> start, Vertex<T> end)
        {
            for (int k = 0; k < edges.Count; k++)
            {
                if (edges[k].Start == start && edges[k].End == end)
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
                        edges[k].Start.Neighbors.Remove(edges[k].End);
                        edges[k].End.Neighbors.Remove(edges[k].Start);
                    }
                    edges.Remove(edges[k]);
                }
            }
        }
    }
}
