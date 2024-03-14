namespace DSA
{       
    public class trie_node
    {
        public Dictionary<char, trie_node> children = new Dictionary<char, trie_node>();
        public bool word;
    }

    public class trie
    {
        trie_node root;

        public void init()
        {
            root = new trie_node();
        }

        public void add(char[] s)
        {
            trie_node tmp = root;
            for (int i = 0; i < s.Count(); i++)
            {
                if (tmp.children.Keys.Contains(s[i]))
                    tmp = tmp.children[s[i]];
                else
                {
                    trie_node new_node = new trie_node();
                    if ((s.Count()-1) == i) new_node.word = true;

                    tmp.children.Add(s[i], new_node);
                    tmp = new_node;
                }
            }
        }

        public bool find_prefix(char[] s)
        {
            trie_node tmp = root;
            for (int i = 0; i < s.Count(); i++)
            {
                if (tmp.children.Keys.Contains(s[i]))
                    tmp = tmp.children[s[i]];
                else
                    return false;
            }
            return true;
        }

        public bool find_word(char[] s)
        {
            trie_node tmp = root;
            for (int i = 0; i < s.Count(); i++)
            {
                if (tmp.children.Keys.Contains(s[i]))
                {
                    tmp = tmp.children[s[i]];
                    if ((s.Count() - 1) == i && tmp.word == true) return true;
                }
                else return false;
            }
            return false;
        }
    }
}