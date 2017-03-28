using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;

namespace TrainsLibrary
{
    public class Graph
    {
        List<Node> nodes;
        public Graph()
        {
             nodes = new List<Node>();
        }

        public void initialiseGraph(string graphString)
        {
            graphString = Regex.Replace(graphString, @"\s+", "");
            string[] edges = graphString.Split(',');
            foreach (string edgeString in edges)
            {
                Console.WriteLine(edgeString);
                Node startNode = getStartNode(edgeString);
                Node endNode = getEndNode(edgeString);
                int weight = Int32.Parse(edgeString.Substring(2, 1));
                Edge edge = new Edge(endNode, weight);
                startNode.addEdge(edge);
            }
        }

        private Node getStartNode(string edge)
        {
            string nodeName = edge.Substring(0, 1);
            return getNode(nodeName);
        }

        private Node getEndNode(string edge)
        {
            string nodeName = edge.Substring(1, 1);
            return getNode(nodeName);
        }

        private Node getNode(string nodeName)
        {
            Node startPoint = findNode(nodeName);
            if (startPoint == null)
            {
                nodes.Add(new Node(nodeName));
                startPoint = findNode(nodeName);
            }
            return startPoint;
        }

        private Node findNode(string nodeName)
        {
            return this.nodes.Find(n => n.Name == nodeName);
        }

        public int getTotalWeight(List<string> destinationNodes)
        {
            List<Edge> path = new List<Edge>();
            int destinationIndex = 0;
            while(destinationIndex < destinationNodes.Count - 1)
            {
                Node routeNode = findNode(destinationNodes[destinationIndex]);
                Edge edge = routeNode.findEdge(destinationNodes[destinationIndex + 1]);
                if(edge != null)
                {
                    path.Add(edge);
                }
                else
                {
                    throw new NoRouteException("No route for destination");
                }
                destinationIndex++;
            }

            int weight = 0;
            foreach(Edge edge in path)
            {
                weight += edge.Weight;
            }

            return weight;
        }

        public List<List<Node>> DepthFirstSearch(string start, string end, int maxDepth)
        {
            Node startNode = findNode(start);
            Node endNode = findNode(end);

            // add the start node to the visited list
            Stack<Node> routeStack = new Stack<Node>();
            List<List<Node>> paths = new List<List<Node>>();

            routeStack.Push(startNode);
            Debug.WriteLine("Level:" + 0 + " Pushed " + startNode.Name + " ");

            // Recur for all the vertices adjacent to this vertex
            List<Node> list = startNode.getNeightbours();

            foreach (var val in list)
            {
                DFSUtil(val, endNode, routeStack, paths, maxDepth + 1, 1);
            }

            return paths;
        }

        private void DFSUtil(Node currentNode, Node end, Stack<Node> routeStack, List<List<Node>> paths, int maxDepth, int currentDepth)
        {
            if (currentDepth < maxDepth)
            {
                // Mark the current node as visited and print it
                routeStack.Push(currentNode);
                Debug.WriteLine("Level:" + currentDepth + " Pushed " + currentNode.Name + " ");

                if (currentNode.Name != end.Name)
                {
                    // Recur for all the vertices adjacent to this vertex
                    List<Node> list = currentNode.getNeightbours();

                    foreach (var val in list)
                    {
                        DFSUtil(val, end, routeStack, paths, maxDepth, currentDepth + 1);
                    }
                }
                else
                {
                    Debug.WriteLine("Reached destination so exporting route");
                    List<Node> pathCreated = routeStack.ToList<Node>();
                    pathCreated.Reverse();
                    paths.Add(pathCreated);
                }
            }
            else
            {
                Debug.WriteLine("Reached max depth so exporting route");
                List<Node> pathCreated = routeStack.ToList<Node>();
                pathCreated.Reverse();
                paths.Add(pathCreated);
                
            } 
            
            if (routeStack.Count > 1)
            {
                Node popped = routeStack.Pop();
                Debug.WriteLine("Level: " + currentDepth + " POPPED:" + popped.Name);
            }
        }
    }
}