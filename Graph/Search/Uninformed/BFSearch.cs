using System.Collections.Generic;
using System.Linq;

namespace Graphs.Search.Uninformed
{
    /// <summary>
    /// Beadth-First uninformed search
    /// </summary>
    class BFSearch : Search
    {
        public BFSearch(Node start, Node[] goals) : base(start, goals)
        {
            this.activePaths = new Queue<Path>();
            foreach (var conn in start.connections)
            {
                (this.activePaths as Queue<Path>).Enqueue(new Path(conn));
            }
        }

        public override Path Start()
        {
            while ((this.activePaths as Queue<Path>).Count > 0)
            {
                Path head = (this.activePaths as Queue<Path>).Dequeue();
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
                            (this.activePaths as Queue<Path>).Enqueue(newPath);
                        }
                    }
                }
            }
            return null;
        }
    }
}
