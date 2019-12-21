using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progect_Algoritm
{
    class Label
    {
        public double Distance { get; set; }

        public Edge Previous { get; set; }

        public int[] Range { get; set; }

        public Label(double Distance, Edge Previous, int[] Range)
        {
            this.Distance = Distance;
            this.Previous = Previous;
            this.Range = Range;
        }

        public string Range_ToString(int[] range)
        {
            string str = null;
            foreach(var item in range)
            {
                str += item + " ";
            }
            return str;
        }

        public override string ToString()
        {
            return $"({Distance}, {Previous.ToString()}, {Range_ToString(Range)})";
        }
    }
}
