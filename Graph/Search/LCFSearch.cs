using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.Search
{
    class LCFSearch : Search
    {
        public LCFSearch(Node start, Node[] goals) : base(start, goals)
        {
            this.activePaths = new PriorityQueue<Path>();
            foreach (var conn in start.connections)
            {
                (this.activePaths as PriorityQueue<Path>).Enqueue(new Path(conn));
            }
        }

        public override Path Start()
        {
            while ((this.activePaths as PriorityQueue<Path>).Count > 0)
            {
                Path head = (this.activePaths as PriorityQueue<Path>).DequeueLowest();
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
                            (this.activePaths as PriorityQueue<Path>).Enqueue(newPath);
                        }
                    }
                }
            }
            return null;
        }

    }
}
