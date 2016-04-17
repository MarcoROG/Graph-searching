using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    /// <summary>
    /// Represents a node inside a graph
    /// </summary>
    class Node
    {
        #region Attributes
        /// <summary>
        /// All the outgoing connections from this node
        /// </summary>
        public List<Connection> connections { get; set; } = new List<Connection>();

        /// <summary>
        /// The value associated with the node, useful for debugging or pathfinding
        /// </summary>
        public object value { get; set; }

        /// <summary>
        /// The number of outgoing connections
        /// </summary>
        /// <see cref="Node.connections"/>
        public int connectionsNumber {
            get
            {
                return this.connections.Count;
            }
        }

        /// <summary>
        /// All the nodes reached directly from the outgoing connections
        /// </summary>
        public List<Node> neighbours { get
            {
                return (from conn in this.connections select conn.to).ToList<Node>();
            }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor
        /// </summary>
        public Node()
        {
        }

        /// <summary>
        /// Creates a node with a value
        /// </summary>
        /// <param name="val">Value of the node</param>
        public Node(object val)
        {
            this.value = val;
        }
        #endregion

        #region Connection Methods
        /// <summary>
        /// Connects this node with a directed edge towards the specified node
        /// </summary>
        /// <param name="n">Target node</param>
        public void connectTo(Node n)
        {
            var conn = new Connection(this, n);
            this.connections.Add(conn);
        }

        /// <summary>
        /// Connects this node with a directed weighted edge towards the specified node
        /// </summary>
        /// <param name="n">Target node</param>
        /// <param name="cost">Cost of traveling the edge</param>
        public void connectTo(Node n, float cost)
        {
            var conn = new Connection(this, n, cost);
            this.connections.Add(conn);
        }
        //TODO add helper for undirected edges

        /// <summary>
        /// Returns the connection between this node and the specified one
        /// </summary>
        /// <param name="n">Specified node</param>
        /// <returns>Connection info</returns>
        public Connection towards(Node n)
        {
            return this.connections.Where(c => c.to == n).Single();
        }
        #endregion

        /*public override string ToString()
        {
            return this.value == null ? "unknown" : this.value.ToString();
        }
        public string ToString(bool complete)
        {
            if (!complete) return this.ToString();
            string ret = this.ToString() + " Neighbours : ";
            foreach (var node in this.neighbours)
            {
                ret += node.ToString() + " ";
            }
            return ret;
        }*/
    }
}
