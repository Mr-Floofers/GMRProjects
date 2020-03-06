using System;
using System.Collections.Generic;

namespace UnweightedUndirectedGraph
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph<string> graph = new Graph<string>();

            Vertex<string> ORD = new Vertex<string>("ORD");
            Vertex<string> MCO = new Vertex<string>("MCO");
            Vertex<string> JFK = new Vertex<string>("JFK");
            Vertex<string> DEN = new Vertex<string>("DEN");
            Vertex<string> HOU = new Vertex<string>("HOU");
            Vertex<string> DFW = new Vertex<string>("DFW");
            Vertex<string> PHX = new Vertex<string>("PHX");
            Vertex<string> ATL = new Vertex<string>("ATL");
            Vertex<string> LAX = new Vertex<string>("LAX");
            Vertex<string> LAS = new Vertex<string>("LAS");
            Vertex<string> SFO = new Vertex<string>("SFO");
            Vertex<string> BUR = new Vertex<string>("BUR");

            graph.AddVertex(ORD);
            graph.AddVertex(MCO);
            graph.AddVertex(JFK);
            graph.AddVertex(DEN);
            graph.AddVertex(HOU);
            graph.AddVertex(DFW);
            graph.AddVertex(PHX);
            graph.AddVertex(ATL);
            graph.AddVertex(LAX);
            graph.AddVertex(LAS);
            graph.AddVertex(SFO);
            graph.AddVertex(BUR);

            graph.AddEdge(ORD, JFK);
            graph.AddEdge(ORD, DFW);
            graph.AddEdge(ORD, HOU);
            graph.AddEdge(ORD, ATL);
            graph.AddEdge(ORD, DEN);
            graph.AddEdge(ORD, PHX);
            graph.AddEdge(JFK, MCO);
            graph.AddEdge(JFK, ATL);
            graph.AddEdge(DEN, PHX);
            graph.AddEdge(DEN, LAS);
            graph.AddEdge(HOU, MCO);
            graph.AddEdge(HOU, DFW);
            graph.AddEdge(HOU, ATL);
            graph.AddEdge(PHX, LAX);
            graph.AddEdge(PHX, LAS);
            graph.AddEdge(LAX, SFO);
            graph.AddEdge(SFO, BUR);

            Vertex<string> tempa = new Vertex<string>();
            Vertex<string> tempb = new Vertex<string>();

            Console.WriteLine(graph.IsConnectd(JFK, LAX));


            Console.WriteLine("What is your starting airport?");
            tempa.Value = Console.ReadLine();
            for(int i = 0; i < graph.Vertices.Count; i++)
            {
                if(graph.Vertices[i].Value == tempa.Value)
                {
                    tempa = graph.Vertices[i];
                }
            }
            Console.WriteLine("What is your ending airport?");
            tempb.Value = Console.ReadLine();
            for (int i = 0; i < graph.Vertices.Count; i++)
            {
                if (graph.Vertices[i].Value == tempb.Value)
                {
                    tempb = graph.Vertices[i];
                }
            }

            var path = graph.DepthFirstSearch(tempa, tempb);

           while (path.Count != 0)
            {
                Console.WriteLine(path.Pop());
            }
            
            return;
        }
    }
}
