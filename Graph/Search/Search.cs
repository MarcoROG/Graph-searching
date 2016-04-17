using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph.Search
{
    abstract class Search
    {
        public Node[] goals { get; set; }
        public Path result
        {
            get
            {
                if (this._result == null) throw new InvalidOperationException("Search should be started and completed before having a result");
                return this._result;
            }
        }
        protected Path _result;
        protected LinkedList<Node> visitedNodes { get; set; } = new LinkedList<Node>();
        protected IEnumerable<Path> activePaths { get; set; }
        protected Node start { get; set; }

        public abstract Path Start();
    }
}
