using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    /// <summary>
    /// Class representing a path through a graph
    /// </summary>
    class Path
    {
        #region Attributes
        /// <summary>
        /// Ordered list of the necessary steps
        /// </summary>
        public List<Connection> steps { get; set; }

        /// <summary>
        /// Total cost of moving through the graph
        /// </summary>
        public float cost {
            get{
                return this.steps.Sum(s => s.cost);
            }
        }

        /// <summary>
        /// Starting point of the path
        /// </summary>
        public Node first
        {
            get
            {
                return this.steps.First().from;
            }
        }

        /// <summary>
        /// Ending point of the path
        /// </summary>
        public Node last
        {
            get
            {
                return this.steps.Last().to;
            }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor
        /// </summary>
        public Path()
        {
            this.steps = new List<Connection>();
        }

        /// <summary>
        /// Constructor with a beginning
        /// </summary>
        /// <param name="first">Starting point for the path</param>
        public Path(Connection first)
        {
            this.steps = new List<Connection>();
            this.steps.Add(first);
        }

        /// <summary>
        /// Constructor for already-started paths
        /// </summary>
        /// <param name="steps">List of taken steps</param>
        public Path(List<Connection> steps)
        {
            this.steps = steps;
        }

        /// <summary>
        /// Builds a new path starting off from an old one and adding a new step
        /// </summary>
        /// <param name="steps">Old path</param>
        /// <param name="newStep">New move</param>
        public Path(Path path, Connection newStep)
        {
            this.steps = path.steps.ToArray().ToList(); //Should fix implementing DeepClone
            this.steps.Add(newStep);
        }
        #endregion

        /// <summary>
        /// Returns the list of neighbouring nodes
        /// </summary>
        /// <returns>Neighbouring nodes</returns>
        public Node[] Heads()
        {
            return this.last.neighbours.ToArray();
        }

        public override string ToString()
        {
            string s = this.steps.First().from.value.ToString() + "-" ;
            foreach(Connection c in this.steps)
            {
                s += c.to.value.ToString() + "-";
            }
            return s;
        }
    }
}
