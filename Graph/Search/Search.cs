using System;
using System.Collections.Generic;

namespace Graphs.Search
{
    /// <summary>
    /// Abstract class for a search algorithm
    /// </summary>
    abstract class Search
    {
        #region Attributes
        /// <summary>
        /// Set of nodes recognized as goals
        /// </summary>
        public Node[] goals { get; set; }

        /// <summary>
        /// Path leading from the start to a goal
        /// </summary>
        public Path result
        {
            get
            {
                if (this._result == null) throw new InvalidOperationException("Search should be started and completed before having a result");
                return this._result;
            }
        }

        /// <summary>
        /// Private member for result
        /// </summary>
        protected Path _result;

        /// <summary>
        /// List of visited nodes to avoid falling into loops
        /// </summary>
        protected LinkedList<Node> visitedNodes { get; set; } = new LinkedList<Node>();

        /// <summary>
        /// List of active paths in the frontier
        /// </summary>
        protected IEnumerable<Path> activePaths { get; set; }

        /// <summary>
        /// Node from which the search starts
        /// </summary>
        protected Node start { get; set; }
        #endregion

        /// <summary>
        /// Creates a Search class
        /// </summary>
        /// <param name="goals">Goals for the search</param>
        public Search(Node start, Node[] goals)
        {
            if (start == null) throw new ArgumentNullException("Starting node can't be null");
            if (goals == null) throw new ArgumentNullException("Goal nodes can't be null");
            if (this.start.connectionsNumber == 0) throw new ArgumentException("Start node must have at least one neighbour");

            this.goals = goals;
            this.start = start;
        }

        /// <summary>
        /// Start point for a graph search
        /// </summary>
        /// <returns>A path from the start to the goal</returns>
        public abstract Path Start();
    }
}
