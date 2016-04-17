using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    class Connection 
    {
        public Node from { get; set; }
        public Node to { get; set; }
        public float? cost { get; set; }

        public Connection(Node f, Node t, float c = 0)
        {
            if (f == null) throw new ArgumentNullException("The starting node shouldn't be null");
            if (t == null) throw new ArgumentNullException("The target node shouldn't be null");
            this.from = f;
            this.to = t;
            this.cost = c;
        }
    }
}
