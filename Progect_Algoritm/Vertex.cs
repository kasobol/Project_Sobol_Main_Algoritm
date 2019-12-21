using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progect_Algoritm
{
    class Vertex
    {
        public string Name { get; set; }

        public int Number { get; set; }

        public List<Edge> OutEdge = new List<Edge>();

        public List<Label> Label = new List<Label>();

        public Vertex(string Name, int Number)
        {
            this.Name = Name;
            this.Number = Number;
            Label = new List<Label>();
        }
        public Vertex()
        {

        }

        public override string ToString()
        {
            return Name;
        }
    }
}
