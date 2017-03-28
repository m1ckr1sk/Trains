using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trains
{
    class Program
    {
        static void Main(string[] args)
        {
            TrainsLibrary.Graph testGraph = new TrainsLibrary.Graph();
            testGraph.initialiseGraph("AB5, BC4, CD8, DC8, DE6, AD5, CE2, EB3, AE7");
            TrainsLibrary.DestinationCalculator destinationCalculator = new TrainsLibrary.DestinationCalculator(testGraph);
            destinationCalculator.getAllPaths("C", "C", 3);
        }
    }
}
