namespace DSA
{
    internal class Program
    {

        static void Main(string[] args)
        {
            linked_list<int> list = new linked_list<int>();
            list.push_back(5);
            list.push_back(1254);
            list.push_back(-345);
            list.push_back(89);

            list.remove(-345);

            list.pop_back();
            list.pop_front();

            list.print();


            Console.WriteLine("----------------");

            trie t = new trie();
            t.init();


            Console.WriteLine("----------------");

        }
    }
}