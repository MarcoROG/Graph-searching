using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    /// <summary>
    /// Represents a graph as a set of nodes connected by weighted edges
    /// </summary>
    class Graph
    {
        #region Attributes
        /// <summary>
        /// List of all the nodes in the graph
        /// </summary>
        public List<Node> nodes { get; set; } = new List<Node>();

        //TODO FIX
        public List<Node> startNodes
        {
            get
            {
                if (this.nodes == null) return null;
                return this.nodes.Where(n => n.connectionsNumber == 0).ToList();
            }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor for empty graph
        /// </summary>
        public Graph()
        {
        }

        /// <summary>
        /// Initialized graph
        /// </summary>
        /// <param name="nodes">Pre-existing nodes</param>
        public Graph(List<Node> nodes)
        {
            this.nodes = nodes;
        }

        /// <summary>
        /// Creates a graph from an adjacency matrix
        /// </summary>
        /// <param name="adjacency">Adjacency matrix: null for no connection, any float for the cost</param>
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
        #endregion

        /// <summary>
        /// Adds a new node to the graph
        /// </summary>
        /// <param name="value">Value of the node</param>
        /// <returns>Created node</returns>
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
