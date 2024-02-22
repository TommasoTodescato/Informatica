namespace DSA
{
    internal class Tree
    {
        public int?[] t;
        public int size;

        public Tree(int n)
        {
            t = new int?[n];
        }

        public int get_parent(int index)
        {
            return (index - 1) / 2;
        }

        public int get_left_child(int index)
        {
            return (2 * index) + 1;
        }

        public int get_right_child(int index)
        {
            return 2 * (index + 1);
        }

        public void DFS(int n)
        {
            Console.WriteLine(t[n]);

            if (t[(2 * n) + 1] != null && ((2 * n) + 1) < size)
                DFS((2 * n) + 1);
            if (t[2 * (n + 1)] != null && (2 * (n + 1)) < size)
                DFS(2 * (n + 1));
        }

        public void BFS(int n)
        {
            Queue<int> q = new Queue<int>();
            q.Enqueue(n);
            while (q.Count > 0) 
            {
                int? v = t[q.Dequeue()];
                Console.WriteLine(v);

                if (t[(2 * n) + 1] != null && ((2 * n) + 1) < size)
                    q.Enqueue((2 * n) + 1);

                if (t[2 * (n + 1)] != null && (2 * (n + 1)) < size)
                    q.Enqueue(2 * (n + 1));
            }
        }

        public void add(int n)
        {

        }

    }
}
