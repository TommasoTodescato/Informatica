namespace DSA
{
    internal class node<T>
    {
        public T data;
        public node<T>? next;

        public node(T data)
        {
            this.data = data;
            next = null;
        }
    }

    internal class linked_list<T> 
    {
        private node<T>? head;

        public node<T>? back()
        {
            node<T>? tmp = head;
            if (tmp is null) return tmp;

            while (tmp.next is not null)
                tmp = tmp.next;
            
            return tmp;
        }

        public node<T>? front()
        {
            return head;
        }

        public void pop_front()
        {
            head = head.next;
        }

        public void pop_back()
        {
            node<T> prev = head;
            node<T> tmp = head;
            while (tmp.next is not null)
            {
                tmp = tmp.next;
                if (tmp.next is null)
                    prev.next = null;
                prev = tmp;
            }
        }

        // ritorna l'elemento all'indice index, null se index è troppo grande
        public T? get(int index)
        {
            node<T> tmp = head;
            int i = 0;
            while (tmp is not null)
            {
                if (i == index)
                    return tmp.data;
                i++;
                tmp = tmp.next;
            }
            return default;
        }

        public void push_back(T data)
        {
            node<T> tmp = new node<T>(data);
            node<T>? back = this.back();
            if (back is null)
            {
                head = tmp;
                return;
            }
            back.next = tmp;
        }

        public void push_front(T data)
        {
            node<T> tmp = new node<T>(data);
            tmp.next = head;
            head = tmp;
        }

        public void print()
        {
            node<T>? tmp = head;
            while (tmp is not null)
            {
                Console.WriteLine(tmp.data.ToString());
                tmp = tmp.next;
            }
        }

        // rimuove la prima occorrenza di data
        // ritorna true se è stata rimossa, false se non c'era
        public bool remove(T data)
        {
            if (head is null) return false;
            if (EqualityComparer<T>.Default.Equals(head.data, data))
            {
                head = head.next;
                return true;
            }

            node<T>? prev = head;
            node<T>? tmp = head;
            while (tmp.next is not null)
            {
                if (EqualityComparer<T>.Default.Equals(tmp.data, data))
                {
                    prev.next = tmp.next;
                    return true;
                }

                prev = tmp;
                tmp = tmp.next;
            }
            return false;
        }
    }
}
