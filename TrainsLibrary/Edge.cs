namespace TrainsLibrary
{
    public class Edge
    {
        private Node endNode;
        private int weight;

        public Edge(Node endNode, int weight)
        {
            this.endNode = endNode;
            this.weight = weight;
        }

        public int Weight
        {
            get
            {
                return weight;
            }

            set
            {
                weight = value;
            }
        }

        internal Node EndNode
        {
            get
            {
                return endNode;
            }

            set
            {
                endNode = value;
            }
        }
    }
}