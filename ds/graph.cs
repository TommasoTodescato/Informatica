namespace ds
{
    internal class graph
    {
        int N;
        List<List<int>> adj;
        bool[] visited;
        public graph(int n)
        {
            N = n;
            adj = new List<List<int>>(N);
            for (int i = 0; i < N; i++)
            {
                adj.Add(new List<int>());
            }
        }

        public void addEdge(int v, int w)
        {
            adj[v].Add(w);
            adj[w].Add(v);
        }

        public List<List<int>> trova_amici(int start)
        {
            List<List<int>> amici = new List<List<int>>(N);
            for (int i = 0; i < N; i++)
            {
                amici.Add(new List<int>());
            }

            foreach (int v in adj[start])
            {
                foreach(int w in adj[v])
                {
                    if (w == start) continue;
                    amici[v].Add(w);
                }
            }
            return amici;
        }
    };
}