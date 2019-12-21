using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progect_Algoritm
{
    class Edge
    {
        public Vertex From { get; set; }
        public Vertex To { get; set; }

        public double Weight { get; set; }

        public int[] Range { get; set; }

        public Edge(Vertex From, Vertex To, double Weight, int[] Range)
        {
            this.From = From;
            this.To = To;
            this.Weight = Weight;
            this.Range = new int[Range.Length];
            for (int i = 0; i < Range.Length; i++)
            {
                this.Range[i] = Range[i];
            }
        }

        public override string ToString()
        {
            return $"{From.Name} -> {To.Name} : {Weight}";
        }
    }
}
