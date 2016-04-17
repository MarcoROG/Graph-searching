using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    class Connection 
    {
        public Node from { get; set; }
        public Node to { get; set; }
        public float cost { get; set; }

        public Connection(Node f, Node t, float c)
        {
            this.from = f;
            this.to = t;
            this.cost = c;
        }

        public Connection(Node f, Node t)
        {
            this.from = f;
            this.to = t;
            this.cost = 0;
        }


    }
}
