namespace DSA
{
    public class Node
    {
        public Dictionary<char, Node> children = new Dictionary<char, Node>();
        public bool word;
    }

    public class Trie
    {
        Node root;

        public void CreateRoot()
        {
            root = new Node();
        }

        public void Add(char[] chars)
        {
            Node tempRoot = root;
            int total = chars.Count() - 1;
            for (int i = 0; i < chars.Count(); i++)
            {
                Node newTrie;
                if (tempRoot.children.Keys.Contains(chars[i]))
                    tempRoot = tempRoot.children[chars[i]];
                else
                {
                    newTrie = new Node();

                    if (total == i)
                        newTrie.word = true;

                    tempRoot.children.Add(chars[i], newTrie);
                    tempRoot = newTrie;
                }
            }
        }

        public bool FindPrefix(char[] chars)
        {
            Node tempRoot = root;
            for (int i = 0; i < chars.Count(); i++)
            {
                if (tempRoot.children.Keys.Contains(chars[i]))
                    tempRoot = tempRoot.children[chars[i]];
                else
                    return false;
            }
            return true;
        }

        public bool FindWord(char[] chars)
        {
            Node tempRoot = root;
            int total = chars.Count() - 1;
            for (int i = 0; i < chars.Count(); i++)
            {
                if (tempRoot.children.Keys.Contains(chars[i]))
                {
                    tempRoot = tempRoot.children[chars[i]];

                    if (total == i)
                    {
                        if (tempRoot.word == true) return true;
                    }
                }
                else return false;
            }
            return false;
        }
    }
}

/*
Calling Code:
    Tries t = new Tries();
    t.CreateRoot();
    t.Add("abc".ToCharArray());
    t.Add("abgl".ToCharArray());
    t.Add("cdf".ToCharArray());
    t.Add("abcd".ToCharArray());
    t.Add("lmn".ToCharArray());

    bool findPrefix1 = t.FindPrefix("ab".ToCharArray());
    bool findPrefix2 = t.FindPrefix("lo".ToCharArray());

    bool findWord1 = t.FindWord("lmn".ToCharArray());
    bool findWord2 = t.FindWord("ab".ToCharArray());
    bool findWord3 = t.FindWord("cdf".ToCharArray());
    bool findWord4 = t.FindWord("ghi".ToCharArray());
*/