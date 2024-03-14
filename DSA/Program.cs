namespace DSA
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            var list = new linked_list<int>();
            list.push_front(1);
            list.push_front(2);
            list.push_front(3);
            list.remove(2);
            list.print();

            Console.WriteLine("----------------");

            var t = new trie();
            t.init();

            t.add("ciao");
            t.add("ciarlatano");

            Console.WriteLine(t.find_word("ciao"));
            Console.WriteLine(t.find_word("ciaociao"));

            Console.WriteLine(t.find_prefix("ci"));
            Console.WriteLine(t.find_prefix("asd"));

            Console.WriteLine("----------------");
        }
    }
}