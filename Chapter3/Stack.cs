using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter3
{
    public class Stack
    {
        Node top;
        Node minimum = null;

        public int pop()
        {
            if (top != null)
            {
                int item = top.data;
                top = top.next;
                return item;
            }
            return -1;
        }

        public Node min()
        {
            return minimum;
        }

        public void push(int item)
        {
            Node t = new Node(item);
            t.next = top;
            top = t;
            if (minimum == null)
            {
                minimum = t;
            }
            else
            {
                if (t.data < minimum.data)
                    minimum = t;
            }
        }

        public class Node
        {
            public Node(int item)
            {
                data = item;
            }

            public Node next;
            public int data;
        }
    }
}
