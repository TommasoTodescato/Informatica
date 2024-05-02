namespace ds
{
    internal class graph
    {
        int N;
        List<List<int>> adj;
        bool[] visited;
        graph(int n)
        {
            N = n;
            adj = new List<List<int>>();
        }

        void addEdge(int v, int w)
        {
            adj[v].Add(w);
            adj[w].Add(v);
        }

        int[] BFS(int start)
        {
            bool[] visited = new bool[N];
            int[] distance = new int[N];
            Queue<int> q = new Queue<int>();
            visited[start] = true;
            distance[start] = 0;
            q.Enqueue(start);
            while (q.Count != 0)
            {
                int s = q.Dequeue();

                foreach (int v in adj[s])
                {
                    if (visited[v]) continue;

                    Console.WriteLine(v);

                    visited[v] = true;
                    distance[v] = distance[s] + 1;
                    q.Enqueue(v);
                }
            }

            return distance;
        }
        void DFS(int start)
        {
            
        }


    };
}
