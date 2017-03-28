using System;
using System.Collections.Generic;

namespace TrainsLibrary
{
    public class DestinationCalculator
    {
        private Graph testGraph;

        public DestinationCalculator(Graph testGraph)
        {
            this.testGraph = testGraph;
        }

        public int getDistance(List<string> destinations)
        {
            return this.testGraph.getTotalWeight(destinations);
        }

        public List<List<String>> getAllPaths(string start, string finish, int maxDepth)
        {
            List<List<String>> paths = new List<List<String>>();
            List<List<Node>> pathsDetected  = this.testGraph.DepthFirstSearch(start, finish, maxDepth);
            foreach(List<Node> path in pathsDetected)
            {
                if (path[path.Count - 1].Name == finish)
                {
                    List<String> stringPath = new List<String>();
                    foreach (Node pathNode in path)
                    {
                        stringPath.Add(pathNode.Name);
                    }
                    paths.Add(stringPath);
                }
            }

            return paths;
        }
    }
}