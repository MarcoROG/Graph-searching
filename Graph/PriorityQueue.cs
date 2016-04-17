using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    class PriorityQueue <T> : IEnumerable<T> where T : IComparable
    {
        private List<T> elements { get; set; }
        public int Count
        {
            get
            {
                return this.elements.Count;
            }
        }
        public PriorityQueue()
        {
            this.elements = new List<T>();
        }
        public PriorityQueue(IEnumerable<T> elements)
        {
            this.elements = elements.ToList();
        }
        public void Enqueue(T element) 
        {
            if (this.elements.Count == 0)
            {
                this.elements.Add(element);
                return;
            }
            for( int i = this.elements.Count - 1; i >= 0; i--)
            {
                if(element.CompareTo(this.elements[i]) > 0)
                {
                    this.elements.Insert(i+1, element);
                    return;
                }
            }
            this.elements.Insert(0, element);
        }
        public T PeekLowest()
        {
            return this.elements[0];
        }
        public T DequeueLowest()
        {
            var result = this.elements[0];
            this.elements.RemoveAt(0);
            return result;
        }
        public T PeekHighest()
        {
            return this.elements.Last();
        }
        public T DequeueHighest()
        {
            var result = this.elements.Last();
            this.elements.Remove(result);
            return result;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.elements.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.elements.GetEnumerator();
        }
    }
}
