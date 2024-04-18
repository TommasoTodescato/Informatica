namespace DSA
{
    internal class node
    {
        public int data;
        public node? left, right;

        public node(int data)
        {
            this.data = data;
            this.left = this.right = null;
        }
    }
    internal class bst
    {
        public node? root;

        public bst(int root_data)
        {
            root = new node(root_data);
        }

        public bool add(int data)
        {
            node? tmp = root;
            if (tmp is null)
            {
                root = new node(data);
                return true;
            }

            if (tmp.data == data) return false;

            while (tmp.left != null || tmp.right != null)
            {
                if (data > tmp.data)
                    tmp = tmp.right;
                else
                    tmp = tmp.left;
            }

            if (tmp.data > data)
                tmp.right = new node(data);
            else
                tmp.left = new node(data);

            return true;
        }
    }

}
