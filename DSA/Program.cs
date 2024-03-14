namespace DSA
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("----------------");

            trie t = new trie();
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