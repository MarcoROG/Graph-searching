using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    class Graph
    {
        public List<Node> nodes { get; set; } = new List<Node>();
        public List<Node> startNodes
        {
            get
            {
                if (this.nodes == null) return null;
                return this.nodes.Where(n => n.connectionsNumber == 0).ToList();
            }
        }
        public Graph()
        {
        }
        public Graph(List<Node> nodes)
        {
            this.nodes = nodes;
        }
        public Graph(float?[,] adjacency)
        {
            if (adjacency.GetLength(0) != adjacency.GetLength(1)) throw new ArgumentException("Provided matrix should be square");
            for (int i = 0; i < adjacency.GetLength(0); i++)
            {
                this.createNode((i+1).ToString());
            }
            for (int i = 0; i < adjacency.GetLength(0); i++)
            {
                for (int j = 0; j < adjacency.GetLength(1); j++)
                {
                    if (adjacency[i,j] != null)
                    {
                        this.nodes[i].connectTo(this.nodes[j], adjacency[i, j] ?? default(float));
                    }
                }
            }
        }
        public Node createNode(object value = null)
        {
            Node n;
            if (value == null)
            {
                n = new Node();
            }
            else
            {
                n = new Node(value);
            }
            this.nodes.Add(n);
            return this.nodes.Last();
        }
    }
}
