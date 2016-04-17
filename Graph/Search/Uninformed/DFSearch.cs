using System.Collections.Generic;
using System.Linq;

namespace Graphs.Search.Uninformed
{
    /// <summary>
    /// Depth-First uninformed search
    /// </summary>
    class DFSearch : Search
    {     
        public DFSearch(Node start, Node[] goal) : base(start, goal)
        {
            this.activePaths = new Stack<Path>();
            foreach(var conn in start.connections)
            {
                (this.activePaths as Stack<Path>).Push(new Path(conn));
            }
        }

        public override Path Start()
        {
            while ((this.activePaths as Stack<Path>).Count > 0)
            {
                Path head = (this.activePaths as Stack<Path>).Pop();
                if (this.goals.Contains(head.last))
                {
                    this._result = head;
                    return head;
                }
                this.visitedNodes.AddLast(head.last);
                var connections = head.last.connections;
                if (connections != null)
                {
                    foreach (var conn in connections)
                    {
                        if (!visitedNodes.Contains(conn.to))
                        {
                            Path newPath = new Path(head, conn);
                            (this.activePaths as Stack<Path>).Push(newPath);
                        }
                    }
                }
            }
            return null;
        }
    }
}
