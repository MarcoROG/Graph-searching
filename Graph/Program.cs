
using System;
using System.Diagnostics;
using Graphs.Search.Uninformed;

namespace Graphs
{
    class Program
    {
        static void Main(string[] args)
        {
            //Test case, should improve data entry and create unit testing
            float?[,] adj = new float?[15,15];
            adj[0, 2] = 1;
            adj[1, 0] = 1;
            adj[2, 1] = 1;
            adj[2, 4] = 1;
            adj[3, 1] = 1;
            adj[3, 11] = 1;
            adj[3, 12] = 1;
            adj[4, 5] = 5;//
            adj[4, 7] = 1;//
            adj[5, 6] = 1;
            adj[5, 7] = 1;
            adj[5, 9] = 4;//
            adj[6, 9] = 1;
            adj[7, 8] = 1;
            adj[7, 9] = 10;//
            adj[8, 10] = 1;
            adj[9, 8] = 1;
            adj[9, 10] = 1;
            adj[9, 13] = 1;
            adj[10, 11] = 1;
            adj[10, 13] = 1;
            adj[11, 12] = 1;
            adj[12, 10] = 1;
            adj[13, 12] = 1;
            adj[14, 13] = 1;

            Graph gr = new Graph(adj);

            Search.Search search = new LCFSearch(gr.nodes[1], new Node[] { gr.nodes[13] });
            var sw = Stopwatch.StartNew();
            var best = search.Start();
            sw.Stop();
            Console.WriteLine(sw.Elapsed.TotalMilliseconds);
            Console.Read();
        }
    }
}
