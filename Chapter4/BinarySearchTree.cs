using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter4
{
    public class BinarySearchTree
    {
        private Node Root;

        public BinarySearchTree()
        {
        }

        public bool IsBalanced()
        {
            return (Depth(Root, Math.Max) - Depth(Root, Math.Min) <= 1);
        }

        public static int Depth(Node node, Func<int, int, int> func)
        {
            if (node == null)
            {
                return 0;
            }
            return 1 + func(Depth(node.left, func), Depth(node.right, func));
        }

        public void DFS()
        {
            // depth-first using a stack
            Stack<Node> s = new Stack<Node>();
            s.Push(Root);

            while (s.Count > 0)
            {
                Node n = s.Pop();
                Console.WriteLine(n.data);
                if (n.right != null)
                    s.Push(n.right);
                if (n.left != null)
                    s.Push(n.left);
            }
        }

        public void BFS()
        {
            // depth-first using a stack
            Queue<Node> s = new Queue<Node>();
            s.Enqueue(Root);

            while (s.Count > 0)
            {
                Node n = s.Dequeue();
                Console.WriteLine(n.data);
                if (n.left != null)
                    s.Enqueue(n.left);
                if (n.right != null)
                    s.Enqueue(n.right);
            }
        }

        public List<LinkedList<Node>> Traverse()
        {
            List<LinkedList<Node>> result = new List<LinkedList<Node>>();

            // depth-first using a stack
            Queue<Node> s = new Queue<Node>();
            s.Enqueue(Root);
            Node marker = null;
            s.Enqueue(marker);
            LinkedList<Node> next = new LinkedList<Node>();
            while (s.Count > 0)
            {

                Node n = s.Dequeue();
                if (n == null)
                {
                    result.Add(next);
                    next = new LinkedList<Node>();
                    if(s.Count > 0)
                        s.Enqueue(marker);
                }
                else
                {
                    Console.WriteLine(n.data);
                    next.AddLast(n);
                    if (n.left != null)
                        s.Enqueue(n.left);
                    if (n.right != null)
                        s.Enqueue(n.right);
                }
            }
            return result;
        }

        public void Insert(int value)
        {
            if (Root == null)
            {
                Root = new Node() { data = value };
            }
            else
            {
                Insert(Root, value);
            }
        }

        public void PrintInOrder()
        {
            InOrder(Root);
        }

        private void InOrder(Node node)
        {
            if (node.left != null)
                InOrder(node.left);
            Console.WriteLine(node.data);
            if (node.right != null)
                InOrder(node.right);
        }

        public void PrintPreOrder()
        {
            PreOrder(Root);
        }

        private void PreOrder(Node node)
        {
            Console.WriteLine(node.data);
            if (node.left != null)
                PreOrder(node.left);
            if (node.right != null)
                PreOrder(node.right);
        }

        public void PrintPostOrder()
        {
            PostOrder(Root);
        }

        private void PostOrder(Node node)
        {
            if (node.left != null)
                PostOrder(node.left);
            if (node.right != null)
                PostOrder(node.right);
            Console.WriteLine(node.data);
        }

        private void Insert(Node node, int value)
        {
            if (node == null)
            {
                node = new Node() { data = value };
            }
            else if (value < node.data)
            {
                if (node.left == null)
                {
                    var nnode = new Node() { data = value };
                    node.left = nnode;
                }
                else
                {
                    Insert(node.left, value);
                }
            }
            else
            {
                if (node.right == null)
                {
                    var nnode = new Node() { data = value };
                    node.right = nnode;
                }
                else
                {
                    Insert(node.right, value);
                }
            }
        }

        public class Node
        {
            public int data;
            public Node left;
            public Node right;
        }
    }
}
