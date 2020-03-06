using System;
using System.IO;
using System.Collections.Generic;

namespace UnionFind
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] filecontents = File.ReadAllLines("uf.txt");
            UnionFind unionFind = new UnionFind(filecontents);

            //Chandler,Joey
            //Joey, Phoebe
            //Monica,Rachael
            //Chandler, Ross
            //Jim,Pam
            //Pam, Dwight
            //Michael,Ryan
            //Ryan, Kelly
            //Dwight,Creed
            //Joey, Creed

            unionFind.Union("Chandler", "Joey");
            unionFind.Union("Joey", "Phoebe");
            unionFind.Union("Monica", "Rachael");
            unionFind.Union("Chandler", "Ross");
            unionFind.Union("Jim", "Pam");
            unionFind.Union("Pam", "Dwight");
            unionFind.Union("Michael", "Ryan");
            unionFind.Union("Ryan", "Kelly");
            unionFind.Union("Dwight", "Creed");
            unionFind.Union("Joey", "Creed");

            return;
        }
    }
}
