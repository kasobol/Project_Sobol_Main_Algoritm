using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progect_Algoritm
{
    class Program
    {
        static void Main()
        {
            //Create graph

            Graph graph = new Graph();

            Vertex v1 = new Vertex("v1", 1);
            Vertex v2 = new Vertex("v2", 2);
            Vertex v3 = new Vertex("v3", 3);
            Vertex v4 = new Vertex("v4", 4);
            Vertex v5 = new Vertex("v5", 5);
            Vertex v6 = new Vertex("v6", 6);
            Vertex v7 = new Vertex("v7", 7);

            graph.Add_Vertex(v1);
            graph.Add_Vertex(v2);
            graph.Add_Vertex(v3);
            graph.Add_Vertex(v4);
            graph.Add_Vertex(v5);
            graph.Add_Vertex(v6);
            graph.Add_Vertex(v7);

            int[] Range = { 1, 2, 3, 4, 5, 6 };
            graph.All_Range = Range;

            graph.Add_Edge(v1, v5, 12, new int[] { 1, 2, 3, 4 });
            graph.Add_Edge(v1, v4, 7, new int[] { 1, 2, 3, 4, 5 });
            graph.Add_Edge(v1, v3, 9, new int[] { 1, 3, 4 });
            graph.Add_Edge(v1, v2, 1, new int[] { 5, 6 });
            graph.Add_Edge(v2, v6, 3, new int[] { 2, 3, 4, 5 });
            graph.Add_Edge(v2, v4, 2, new int[] { 3, 4, 5, 6 });
            graph.Add_Edge(v2, v3, 4, new int[] { 4, 5 });
            graph.Add_Edge(v3, v4, 4, new int[] { 1, 2, 3 });
            graph.Add_Edge(v4, v7, 2, new int[] { 3, 4, 5 });
            graph.Add_Edge(v4, v6, 6, new int[] { 1, 2, 3, 4, 5, 6 });
            graph.Add_Edge(v4, v5, 7, new int[] { });
            graph.Add_Edge(v4, v1, 7, new int[] { 1, 2, 3, 4, 5 });
            graph.Add_Edge(v5, v7, 3, new int[] { 2, 4, 5, 6 });
            graph.Add_Edge(v6, v2, 3, new int[] { 2, 3, 4, 5 });
            graph.Add_Edge(v7, v4, 2, new int[] { 3, 4, 5 });

            graph.Add_OutEdge();

            var all_vertexes = new Vertex[] { v1, v2, v3, v4, v5, v6, v7 };

            //Start Algoritm
            int diapason = 2;
            graph.Algo(v5, v3, 100, diapason);
            //Search way
            var res1 = graph.Trace(diapason, v5, v3);
            Show(res1.Item1);
            Console.WriteLine("Range: " + Mas_in_String(res1.Item2) + "\n");

        }
        
        static void Display(Graph graph)
        {
            double[,] mas = graph.Get_Graph_Matrix();
            Console.WriteLine();
            Console.Write("\t");

            for (int i = 0; i < graph.Vertex_Count; i++)
            {
                Console.Write($"\t{i + 1}");
            }
            Console.WriteLine();
            Console.Write("\t");
            for (int i = 0; i < graph.Vertex_Count; i++)
            {
                Console.Write($"\t#");
            }
            Console.WriteLine();
            for (int i = 0; i < graph.Vertex_Count; i++)
            {
                Console.Write($"{i + 1}\t#\t");
                for (int j = 0; j < graph.Vertex_Count; j++)
                {
                    Console.Write($"{mas[i, j]}\t");
                }
                Console.WriteLine();
            }
        }

        static void Show(List<Edge> list)
        {
            if(list.Count == 0)
            {
                return;
            }
            foreach (var item in list)
            {
                Console.WriteLine($"{item.ToString()}: {Mas_in_String(item.Range)}");
            }
        }

        static string Mas_in_String(int[] mas)
        {
            string str = null;
            foreach(var item in mas)
            {
                str += item + " ";
            }
            return $"( {str})";
        }

        static void Show_Vertex(Vertex[] vertexes)
        {
            foreach(var vertex in vertexes)
            {
                Console.WriteLine(vertex.ToString());
                foreach(var label in vertex.Label)
                {
                    Console.WriteLine(label.ToString());
                }
            }
        }
    }
}
