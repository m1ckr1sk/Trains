using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace TrainsUnitTest
{
    [TestClass]
    public class GraphUnitTest
    {
        private TrainsLibrary.DestinationCalculator destinationCalculator;
        [TestInitialize]
        public void Init()
        {
            TrainsLibrary.Graph testGraph = new TrainsLibrary.Graph();
            testGraph.initialiseGraph("AB5, BC4, CD8, DC8, DE6, AD5, CE2, EB3, AE7");
            destinationCalculator = new TrainsLibrary.DestinationCalculator(testGraph);
        }

        [TestMethod]
        public void DistanceOfABC()
        {
            List<string> destinations = new List<string>();
            destinations.Add("A");
            destinations.Add("B");
            destinations.Add("C");
            int distance = destinationCalculator.getDistance(destinations);
            Assert.AreEqual(9, distance);
        }
    }
}
