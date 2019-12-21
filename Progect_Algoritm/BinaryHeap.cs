using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progect_Algoritm
{
    class BinaryHeap
    {
        public List<Edge_Distance> Edges_Sort = new List<Edge_Distance>();

        public Edge_Distance Get_Min()
        {
            var edge = Edges_Sort.First();
            Edges_Sort.Remove(Edges_Sort.First());
            return edge;
        }

        public void Add_Heap(Edge_Distance edge_add)
        {
            foreach(var edge in Edges_Sort)
            {
                if(edge.Edge.From == edge_add.Edge.From && edge.Edge.To == edge_add.Edge.To && edge.Distance == edge_add.Distance)
                {
                    return;
                } 
            }
            int index_prev;
            int index_pointer;
            if (Edges_Sort.Count == 0)
            {
                Edges_Sort.Add(edge_add);
                return;
            }

            Edges_Sort.Add(edge_add);

            var pointer = edge_add;

            while (true)
            {
                index_prev = (Edges_Sort.IndexOf(pointer) - 1) / 2;
                index_pointer = Edges_Sort.IndexOf(pointer);
                if (pointer.Distance < Edges_Sort[index_prev].Distance)
                {
                    Edges_Sort[index_pointer] = Edges_Sort[index_prev];
                    Edges_Sort[index_prev] = pointer;
                }
                else
                {
                    break;
                }
            }
        }

        public void Delete_Min()
        {
            int index_pointer;
            int index_Pos_Left;
            int index_Pos_Right;
            int index_minimum;
            if (Edges_Sort.Count == 1 || Edges_Sort.Count == 2)
            {
                Edges_Sort.Remove(Edges_Sort.First());
                return;
            }
            Edges_Sort[0] = Edges_Sort.Last();
            Edges_Sort.Remove(Edges_Sort.Last());

            var pointer = Edges_Sort[0];
            var minimum = pointer;
            while (true)
            {
                index_pointer = Edges_Sort.IndexOf(pointer);
                index_Pos_Left = (index_pointer + 1) * 2 - 1;
                index_Pos_Right = (index_pointer + 1) * 2;

                if (index_Pos_Left > Edges_Sort.Count - 1)
                {
                    break;
                }
                if (index_Pos_Right > Edges_Sort.Count - 1)
                {
                    if (pointer != Min_Of_Two(pointer, Edges_Sort[index_Pos_Left]))
                    {
                        Edges_Sort[index_pointer] = Edges_Sort[index_Pos_Left];
                        Edges_Sort[index_Pos_Left] = pointer;
                    }
                    break;
                }

                minimum = Min_Of_Three(pointer, Edges_Sort[index_Pos_Left], Edges_Sort[index_Pos_Right]);
                index_minimum = Edges_Sort.IndexOf(minimum);
                if (pointer != minimum)
                {
                    Edges_Sort[index_pointer] = Edges_Sort[index_minimum];
                    Edges_Sort[index_minimum] = pointer;
                }
                else
                {
                    break;
                }
            }
        }

        public Edge_Distance Min_Of_Three(Edge_Distance v1, Edge_Distance v2, Edge_Distance v3)
        {
            return v1.Distance < v2.Distance ? (v1.Distance < v3.Distance ? v1 : v3) : (v2.Distance < v3.Distance ? v2 : v3);
        }

        public Edge_Distance Min_Of_Two(Edge_Distance v1, Edge_Distance v2)
        {
            return v1.Distance < v2.Distance ? v1 : v2;
        }
    }
}
