using System;
using System.Collections.Generic;
using System.Text;
using Priority_Queue;
using System.Linq;

namespace WeightedDirectedGraph
{

    class Graph<T> where T : IComparable<T>
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

        public Vertex<T> Search(T val)
        {
            for (int i = 0; i < vertices.Count; i++)
            {
                if (vertices[i].Value.Equals(val))
                {
                    return vertices[i];
                }
            }
            return null;
        }

        public Edge<T> GetEdge(Vertex<T> start, Vertex<T> end)
        {
            foreach (Edge<T> edge in edges)
            {
                if (edge.Start == start && edge.End == end)
                {
                    return edge;
                }
            }
            return null;
        }

        public IEnumerable<T> DFS(Vertex<T> start, Vertex<T> end)
        {
            // recursive

            List<T> path = new List<T>();
            var visited = new Dictionary<Vertex<T>, bool>();
            vertices.ForEach(x => visited.Add(x, false));

            DFS(path, visited, start, end);


            return path;
        }

        private void DFS(List<T> path, Dictionary<Vertex<T>, bool> visited, Vertex<T> node, Vertex<T> end)
        {
            if (node == null)
            {
                return;
            }

            visited[node] = true;
            path.Add(node.Value);

            if (node == end)
            {
                return;
            }


            foreach (var neighbor in node.Neighbors)
            {
                if (!visited[neighbor] && edges.Contains(GetEdge(node, neighbor)))//the second part is for checking direction, only important in directed graphs
                {
                    DFS(path, visited, neighbor, end);
                    //stack.Push(neighbor);
                }
            }

        }

        public IEnumerable<T> DeapthFirstSearch(Vertex<T> start, Vertex<T> end)
        {
            var stack = new Stack<Vertex<T>>();
            var path = new List<T>();   // add nodes here when i "visit" them

            var visited = new Dictionary<Vertex<T>, bool>();

            vertices.ForEach(x => visited.Add(x, false));

            stack.Push(start);

            while (stack.Count > 0)
            {
                var temp = stack.Pop();

                // visit the node

                visited[temp] = true;
                path.Add(temp.Value);

                if (temp == end)
                {
                    break;
                }

                foreach (var neighbor in temp.Neighbors)
                {
                    if (!visited[neighbor] && edges.Contains(GetEdge(temp, neighbor)))//the second part is for checking direction, only important in directed graphs
                    {
                        stack.Push(neighbor);
                    }
                }
            }

            return path;

            //Stack<Vertex<T>> path = new Stack<Vertex<T>>();
            //HashSet<Vertex<T>> visited = new HashSet<Vertex<T>>();

            //Vertex<T> current = start;

            //while (current != end)
            //{
            //    bool nonVistied = false;
            //    foreach (Vertex<T> vertex in current.Neighbors)
            //    {
            //        if (!current.Neighbors.Contains(vertex))
            //        {
            //            path.Push(current);
            //            visited.Add(vertex);
            //            current = vertex;
            //            nonVistied = true;
            //            break;
            //        }
            //    }

            //    if (nonVistied)
            //    {
            //        if(path.Count == 0)
            //        {
            //            return path;
            //        }
            //        current = path.Pop();
            //    }
            //}
            //path.Push(end);
            //return path;

        }


        public IEnumerable<T> BreathFirstSearch(Vertex<T> start, Vertex<T> end)
        {
            var stack = new Queue<Vertex<T>>();
            var path = new List<T>();   // add nodes here when i "visit" them

            var visited = new Dictionary<Vertex<T>, bool>();

            vertices.ForEach(x => visited.Add(x, false));

            stack.Enqueue(start);

            while (stack.Count > 0)
            {
                var temp = stack.Dequeue();

                // visit the node

                visited[temp] = true;
                path.Add(temp.Value);

                if (temp == end)
                {
                    break;
                }

                foreach (var neighbor in temp.Neighbors)
                {
                    if (!visited[neighbor] && edges.Contains(GetEdge(temp, neighbor)))//the second part is for checking direction, only important in directed graphs
                    {
                        stack.Enqueue(neighbor);
                    }
                }
            }

            return path;
        }

        //pathfinding

        public void Dijkstras(Vertex<T> start, Vertex<T> end)
        {
            //things that ust be known to each vertex
            //  distance from start
            //  parent of vertex
            //  if the vertex has been visited

            var distance = new Dictionary<Vertex<T>, float>();
            vertices.ForEach(x => distance.Add(x, float.MaxValue));

            var parent = new Dictionary<Vertex<T>, Vertex<T>>();//first one is the child, second is parent
            vertices.ForEach(x => parent.Add(x, null));

            var visited = new Dictionary<Vertex<T>, bool>();
            vertices.ForEach(x => visited.Add(x, false));
            SimplePriorityQueue<Vertex<T>> queue = new SimplePriorityQueue<Vertex<T>>();


            distance[start] = 0;
            queue.Enqueue(start, distance[start]);
            

            Vertex<T> current = queue.First;
            while (current != end)
            {
                current = queue.Dequeue();

                foreach (var vertex in vertices.Where(x => edges.Contains(GetEdge(current, x))))
                {
                    if (distance[vertex] > distance[current] + GetEdge(current, vertex).Distance)
                    {
                        parent[vertex] = current;
                        distance[vertex] = distance[current] + GetEdge(current, vertex).Distance;
                        queue.Enqueue(vertex);
                    }
                    else
                    {

                    }
                    
                }
            }

            /* Steps:
             * Initialize all the vertices by marking them un-visited, setting their known distance to ∞, and setting their founder to null.
             * 
             * Assign the start vertex's known distance to 0 (since it is a distance of 0 from the start vertex!) and add it to a PriorityQueue. 
             * The priority of the vertices is their cumulative distance.
             * 
             * Pop from the priority queue to obtain the current vertex which has the smallest cumulative distance.
             * 
             * For the current vertex, consider all of its neighbors and calculate their tentative distances. That is, the current 
             * vertex's cumulative distance plus the weight to travel to that neighbor.
             * Compare the newly calculated tentative distance to the neighbors current cumulative distance.
             * If the tentative distance is smaller, set the neighbors cumulative distance as the tentative distance and update 
             * the founder of the neighbor to be the current vertex. 
             * (also setting it to be un-visited will help if we revisit a vertex with a better path).
             * 
             * Add all un-visited & un-queued neighbors to the priority queue.
             * 
             * When we are done considering all the neighbors of the current vertex, mark the current vertex as visited. 
             * A visited vertex will never be checked again. If the end vertex has been marked visited, stop searching. 
             * The algorithm has finished. Otherwise, repeat from step 3 as long as vertices exist within the priority queue.
             */
        }
    }
}
