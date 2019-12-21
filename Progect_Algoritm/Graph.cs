using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progect_Algoritm
{
    class Graph
    {
        private List<Vertex> Vertexes = new List<Vertex>();
        private List<Edge> Edges = new List<Edge>();
        public int[] All_Range;

        public int Vertex_Count => Vertexes.Count;
        public int Edge_Count => Edges.Count;

        public void Add_Vertex(Vertex vertex)
        {
            Vertexes.Add(vertex);
        }

        public void Add_Edge(Vertex From, Vertex To, double Weight, int[] Range)
        {
            Edges.Add(new Edge(From, To, Weight, Range));
        }

        public void Add_OutEdge()
        {
            foreach (var edge in Edges)
            {
                edge.From.OutEdge.Add(edge);
            }
        }

        public double[,] Get_Graph_Matrix()
        {
            var matrix = new double[Vertexes.Count, Vertexes.Count];

            foreach (var edge in Edges)
            {
                matrix[edge.From.Number - 1, edge.To.Number - 1] = edge.Weight;
            }

            return matrix;
        }

        public List<Edge> Reverse_List(List<Edge> list)
        {
            list.Reverse();
            return list;
        }

        public void Reset()
        {
            foreach (var vertex in Vertexes)
            {
                vertex.Label = new List<Label>();
            }
        }

        public int[] Cross(int[] mas1, int[] mas2)
        {
            List<int> result = new List<int>();
            int count = 0;
            foreach (var item1 in mas1)
            {
                foreach (var item2 in mas2)
                {
                    if (item1 == item2)
                    {
                        result.Add(item1);
                        count++;
                    }
                }
            }
            var h = new int[result.Count];
            int i = 0;
            foreach(var res in result)
            {
                h[i] = res;
                i++;
            }
            return h;
        }

        public double Sum(List<Edge> list)
        {
            double sum = 0;
            foreach (var edge in list)
            {
                sum += edge.Weight;
            }
            return sum;
        }

        public int[] Max_Diaposon(int[] mas)
        {
            if (mas.Length == 1 || mas.Length == 0)
            {
                return mas;
            }
            var list = new List<int[]>();
            int k = 0;
            for(int i = 0; i < mas.Length - 1; i++)
            {
                if(mas[i] + 1 == mas[i + 1])
                {
                    if(i == mas.Length - 2)
                    {
                        int[] arr = new int[mas.Length - k];
                        for (int j = k, m = 0; j < mas.Length; j++, m++)
                        {
                            arr[m] = mas[j];
                        }
                        list.Add(arr);
                        break;
                    }
                    continue;
                }
                int[] arr1 = new int[i + 1 - k];
                for (int j = k, m = 0; j < i + 1; j++, m++)
                {
                    arr1[m] = mas[j];
                }
                list.Add(arr1);
            }

            var max = list.First();
            foreach(var item in list)
            {
                if(max.Length < item.Length)
                {
                    max = item;
                }
            }

            return max;
        }

        public int[] Delete(int[] mas, int item)
        {
            int[] arr = new int[mas.Length - 1];
            int j = 0;
            for (int i = 0; i < mas.Length; i++)
            {
                if(mas[i] != item)
                {
                    arr[j] = mas[i];
                    j++;
                }
            }
            mas = arr;
            return mas;
        }

        public int[] Min_Diaposon(int[] mas, int n)
        {
            if(mas.Length == 1 || mas.Length == 0)
            {
                return mas;
            }
            var list = new List<int[]>();
            int k = 0;
            for (int i = 0; i < mas.Length - 1; i++)
            {
                if (mas.Length == 1)
                {
                    return mas;
                }
                if (mas[i] + 1 == mas[i + 1])
                {
                    if (i == mas.Length - 2)
                    {
                        int[] arr = new int[mas.Length - k];
                        for (int j = k, m = 0; j < mas.Length; j++, m++)
                        {
                            arr[m] = mas[j];
                        }
                        list.Add(arr);
                        break;
                    }
                    continue;
                }
                int[] arr1 = new int[i + 1 - k];
                for (int j = k, m = 0; j < i + 1; j++, m++)
                {
                    arr1[m] = mas[j];
                }
                list.Add(arr1);
            }
            int[] min = list.First();
            foreach(var item in list)
            {
                if(item.Length >= n)
                {
                    min = item;
                    break;
                }
            }

            foreach(var item in list)
            {
                if(min.Length < item.Length && item.Length >= n)
                {
                    min = item;
                }
            }

            return min;
        }

        public bool Comparison_Mas(int[] mas1, int[] mas2)
        {
            if(mas1.Length != mas2.Length)
            {
                return false;
            }
            for (int i = 0; i < mas1.Length; i++)
            {
                if(mas1[i] != mas2[i])
                {
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// The Main Algoritm
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="max_distance"></param>
        /// <param name="min_diaposon"></param>
        public void Algo(Vertex start, Vertex end, double max_distance, int min_diaposon)
        {
            Reset();
            bool check;

            var Heap_Priority = new BinaryHeap();
            var pointer_vertex = new Vertex();
            var edge_start = new Edge(start, start, 0, All_Range);
            start.Label.Add(new Label(0, edge_start, All_Range));
            var pointer_heap = new Edge_Distance(edge_start, 0);
            Heap_Priority.Add_Heap(pointer_heap);
            var SSSC = new List<int[]>();

            while(Heap_Priority.Edges_Sort.Count != 0)
            {
                pointer_heap = Heap_Priority.Get_Min();
                pointer_vertex = pointer_heap.Edge.To;

                //if (pointer_vertex == end)
                //{
                //    break;
                //}

                SSSC = new List<int[]>();
                foreach(var label in pointer_vertex.Label)
                {
                    if(label.Distance == pointer_heap.Distance && label.Previous.From == pointer_heap.Edge.From && label.Previous.To == pointer_heap.Edge.To)
                    {
                        SSSC.Add(label.Range);
                    }
                }

                foreach(var range in SSSC)
                {
                    foreach(var outedge in pointer_vertex.OutEdge)
                    {
                        if(outedge.Range.Length == 0)
                        {
                            continue;
                        }
                        var S = Cross(range, outedge.Range);
                        var distance = pointer_heap.Distance + outedge.Weight;
                        if(distance < max_distance && Max_Diaposon(S).Length >= min_diaposon)
                        {
                            var vertex = outedge.To;
                            var label = new Label(distance, outedge, S);

                            check = true;
                            foreach(var label_vertex in vertex.Label)
                            {
                                if(label.Distance >= label_vertex.Distance && Comparison_Mas(label.Range, Cross(label_vertex.Range, label.Range)))
                                {
                                    check = false;
                                }
                            }

                            if (check)
                            {
                                vertex.Label.Add(label);
                                Heap_Priority.Add_Heap(new Edge_Distance(outedge, distance));
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Search way after Main Algoritm
        /// </summary>
        /// <param name="diaposon"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public Tuple<List<Edge>, int[]> Trace(int diaposon, Vertex start, Vertex end)
        {
            if(end.Label.Count == 0)
            {
                return null;
            }
            var pointer = end.Label.First();
            var result_way = new List<Edge>();
            var result_diaposon = new int[diaposon];
            var min_diaposon = Min_Diaposon(pointer.Range, diaposon);

            result_way.Add(pointer.Previous);
            for (int i = 0; i < diaposon; i++)
            {
                result_diaposon[i] = min_diaposon[i];
            }

            while (true)
            {
                if(pointer.Previous.From == start)
                {
                    break;
                }
                foreach(var label in pointer.Previous.From.Label)
                {
                    if(label.Distance + pointer.Previous.Weight == pointer.Distance && Comparison_Mas(result_diaposon, Cross(result_diaposon, pointer.Range)))
                    {
                        pointer = label;
                    }
                }
                result_way.Add(pointer.Previous);
            }
            foreach(var item in result_diaposon)
            {
                foreach(var edge in result_way)
                {
                    edge.Range = Delete(edge.Range, item);
                }
            }
            return Tuple.Create(Reverse_List(result_way), result_diaposon);
        }
    }
}
