using System;
using System.Collections.Generic;


namespace SwashSim_RouteAssign
{
    class FloydGraph
    {
        static float INF = float.MaxValue;
        float[,] dist;
        int[,] path;
        List<UInt16> result = new List<UInt16>();

        public float[,] Dist
        {
            get { return dist; }
            set { dist = value; }
        }

        public int[,] Path
        {
            get { return path; }
            set { path = value; }
        }

        public List<UInt16> Result
        {
            get { return result; }
            set { result = value; }
        }

        public FloydGraph(UInt16 size, float[,] matrix)
        {
            path = new int[size, size];
            dist = new float[size, size];
            Floyd(matrix);
        }

        public void FindShortestPath(UInt16 begin, UInt16 end)
        {
            result.Add(begin);
            FindPath(begin, end);
            result.Add(end);
        }

        public void FindPath(UInt16 i, UInt16 j)
        {
            int k = path[i, j];
            if (k == -1)
                return;
            FindPath(i, (ushort)k);
            result.Add((ushort)k);
            FindPath((ushort)k, j);           
        }



        public void Floyd(float[,] matrix)
        {
            int size = (int)Math.Sqrt(matrix.Length);
            for (UInt16 i = 0; i < size; i++)
                for (UInt16 j = 0; j < size; j++)
                {
                    path[i, j] = -1;
                    dist[i, j] = matrix[i, j];
                }
            for (UInt16 k = 0; k < size; k++)
                for (UInt16 i = 0; i < size; i++)
                    for (UInt16 j = 0; j < size; j++)
                        if (dist[i, k] != INF && dist[k, j] != INF && dist[i, k] + dist[k, j] < dist[i, j])
                        {
                            dist[i, j] = dist[i, k] + dist[k, j];
                            path[i, j] = k;
                        }
        }
    }

}
