using ds;

namespace DSA
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var g = new graph(9);

            g.addEdge(0, 1);
            g.addEdge(0, 2);
            g.addEdge(0, 3);
            g.addEdge(1, 4);
            g.addEdge(1, 5);
            g.addEdge(5, 6);
            g.addEdge(4, 7);
            g.addEdge(4, 8);

            var am = g.trova_amici(1);

            foreach(List<int> l in am)
            {
                foreach(int i in l)
                {
                    Console.Write(i);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }

        }
    }
}