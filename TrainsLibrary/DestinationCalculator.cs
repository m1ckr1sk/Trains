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
    }
}