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

        [TestMethod]
        public void DistanceOfAD()
        {
            List<string> destinations = new List<string>();
            destinations.Add("A");
            destinations.Add("D");
            int distance = destinationCalculator.getDistance(destinations);
            Assert.AreEqual(5, distance);
        }

        [TestMethod]
        public void DistanceOfADC()
        {
            List<string> destinations = new List<string>();
            destinations.Add("A");
            destinations.Add("D");
            destinations.Add("C");
            int distance = destinationCalculator.getDistance(destinations);
            Assert.AreEqual(13, distance);
        }

        [TestMethod]
        public void DistanceOfAEBCD()
        {
            List<string> destinations = new List<string>();
            destinations.Add("A");
            destinations.Add("E");
            destinations.Add("B");
            destinations.Add("C");
            destinations.Add("D");
            int distance = destinationCalculator.getDistance(destinations);
            Assert.AreEqual(22, distance);
        }

        [TestMethod]
        [ExpectedException(typeof(TrainsLibrary.NoRouteException))]
        public void DistanceOfAEDThrowsNoRouteException()
        {
            List<string> destinations = new List<string>();
            destinations.Add("A");
            destinations.Add("E");
            destinations.Add("D");
            int distance = destinationCalculator.getDistance(destinations);
        }

        [TestMethod]
        public void PathsFromCToC()
        {
            List<List<String>> routes = destinationCalculator.getAllPaths("C", "C", 3);
            Assert.AreEqual(2, routes.Count);
        }

        [TestMethod]
        public void PathsFromAToC()
        {
            List<List<String>> routes = destinationCalculator.getAllPaths("A", "C", 10);
            Assert.AreEqual(3, routes.Count);
        }
    }
}
