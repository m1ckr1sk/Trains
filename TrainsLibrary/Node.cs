using System;
using System.Collections.Generic;

namespace TrainsLibrary
{
    public class Node
    {
        private string name;
        private List<Edge> edges;

        public Node(string name)
        {
            this.name = name;
            this.edges = new List<Edge>();
        }

        public string Name
        {
            get
            {
                return name;
            }
        }

        public void addEdge(Edge edge)
        {
            this.edges.Add(edge);
        }

        public List<Node> getNeightbours()
        {
            List<Node> neighbours = new List<Node>();
            foreach(Edge edge in this.edges)
            {
                neighbours.Add(edge.EndNode);
            }
            return neighbours;
        }

        public Edge findEdge(string destinationName)
        {
            return this.edges.Find(e => e.EndNode.Name == destinationName);
        }
    }
}