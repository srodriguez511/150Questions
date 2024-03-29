﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinkList
{
    public sealed class MyLinkedList<T> where T : IComparable
    {
        /// <summary>
        /// Head reference, start of the list
        /// </summary>
        private Node head;

        /// <summary>
        /// Number of elements in the list
        /// </summary>
        public int Count { get; private set; }

        public MyLinkedList()
        {
            head = null;
        }


        public void DeleteMiddle(Node middle)
        {
            if (middle == null || middle.Next == null)
                return;

            middle.Data = middle.Next.Data;
            middle.Next = middle.Next.Next;
            Count--;
        }

        /// <summary>
        /// Remove duplicate entries
        /// </summary>
        public void RemoveDuplicates()
        {
            if (head == null)
                return;

            Node temp = head;
            Node prev = head;
            while (temp != null)
            {
                Node current = temp;
                Node adv = head;
                while (adv != current)
                {
                    //We already have one of thesebefore current
                    if (adv.Data.Equals(current.Data))
                        break;
                    adv = adv.Next;
                }

                //We didn't make it to the end b/c we dfound a duplicate
                if (adv != current)
                {
                    Count--;
                    prev.Next = current.Next;
                }
                else
                {
                    prev = temp;
                }
                temp = temp.Next;
            }
        }

        /// <summary>
        /// Sort the linked list in increasing order
        /// </summary>
        public void Sort()
        {
            head = MergeSort(head);
        }

        private Node MergeSort(Node localHead)
        {
            if (localHead == null || localHead.Next == null)
            {
                return localHead;
            }

            var middle = FindMiddleNode(localHead);
            var right = middle.Next;
            middle.Next = null;
            return Merge(MergeSort(localHead), MergeSort(right));
        }

        /// <summary>
        /// merge sort routine
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private Node Merge(Node left, Node right)
        {
            Node newHead = new Node(default(T), null); //Dummy head 
            Node curr = newHead;

            while (left != null && right != null)
            {
                //Left is smaller
                if (((IComparable)left.Data).CompareTo((IComparable)right.Data) <= 0)
                {
                    curr.Next = left;
                    left = left.Next;
                }
                //Right is smaller
                else
                {
                    curr.Next = right;
                    right = right.Next;
                }
                curr = curr.Next;
            }

            curr.Next = (left == null) ? right : left;
            return newHead.Next;
        }

        public Node FindMiddleNode()
        {
            return FindMiddleNode(head);
        }

        /// <summary>
        /// Find the middle node from the starting node
        /// </summary>
        /// <returns></returns>
        public Node FindMiddleNode(Node start)
        {
            if (start == null)
            {
                return null;
            }

            if (start.Next == null)
            {
                return start;
            }

            var delayed = start; //trailing ptr
            var curr = start.Next;

            while (curr != null && curr.Next != null)
            {
                delayed = delayed.Next;
                curr = curr.Next.Next;
            }

            return delayed;
        }

        /// <summary>
        /// Returns the middle element value
        /// </summary>
        /// <returns></returns>
        public T FindMiddle()
        {
            return FindMiddleNode(head).Data;
        }

        /// <summary>
        /// Finds the element N positions from the last
        /// </summary>
        /// <param name="N"></param>
        public T FindNthFromLast(int N)
        {
            if (head == null || Count < N)
            {
                return default(T);
            }

            //Assume we don't know the size of the list
            var curr = head;
            Node trailingPtr = head;

            int count = 0;
            while (count != N)
            {
                curr = curr.Next;
                count++;
            }

            while (curr != null)
            {
                curr = curr.Next;
                trailingPtr = trailingPtr.Next;
            }

            return trailingPtr.Data;
        }

        /// <summary>
        /// Reverse a linked list
        /// </summary>
        public void ReverseList()
        {
            var curr = head;
            Node prev = null;
            Node next = null;

            while (curr != null)
            {
                next = curr.Next;
                curr.Next = prev;
                prev = curr;
                curr = next;
            }
            head = prev;
        }

        /// <summary>
        /// Reverse linked list using recursion
        /// </summary>
        public void ReverseListRecursion()
        {
            head = ReverseListRecurse(head, null);
        }

        /// <summary>
        /// Use recursion to reverse the list
        /// </summary>
        /// <param name="curr"></param>
        /// <param name="prev"></param>
        private Node ReverseListRecurse(Node headRef, Node prevRef)
        {
            if (headRef == null)
            {
                return null;
            }

            if (headRef.Next == null)
            {
                headRef.Next = prevRef;
                return headRef;
            }

            var reverse = ReverseListRecurse(headRef.Next, headRef);
            headRef.Next = prevRef;
            return reverse;
        }

        /// <summary>
        /// Add item to the end of the list
        /// </summary>
        /// <param name="data"></param>
        public void Add(T data)
        {
            var newNode = new Node(data, null);

            if (head == null)
            {
                head = newNode;
            }
            else
            {
                var last = Traverse(null);
                last.Next = newNode;
            }
            Count++;
        }

        /// <summary>
        /// Remove the first item in the list with the data 
        /// </summary>
        /// <param name="data"></param>
        public void RemoveFirst(T data)
        {
            Traverse((prev, curr) =>
            {
                return Remove(prev, curr, data, true);
            });
        }

        /// <summary>
        /// Removes all the items from the list
        /// </summary>
        /// <param name="data"></param>
        public void RemoveAll(T data)
        {
            Traverse((prev, curr) =>
            {
                return Remove(prev, curr, data, false);
            });
        }

        /// <summary>
        /// Remove the last item in the list containing the data
        /// </summary>
        /// <param name="data"></param>
        public void RemoveLast(T data)
        {
            Node nodeBeforeNodeToRemove = null;
            Node nodeToRemove = null;

            Traverse((prev, curr) =>
            {
                if (curr.Data.Equals(data))
                {
                    nodeBeforeNodeToRemove = prev;
                    nodeToRemove = curr;
                }
                return false;
            });

            DoRemoval(nodeBeforeNodeToRemove, nodeToRemove);
        }

        /// <summary>
        /// Helper to perform the reference re-ordering for removal
        /// </summary>
        private void DoRemoval(Node prev, Node curr)
        {
            if (curr.Equals(head))
            {
                head = curr.Next;
            }
            else
            {
                prev.Next = curr.Next;
            }
            Count--;
        }

        /// <summary>
        /// Removes an item from the list. Stop or continue deleting.
        /// </summary>
        /// <param name="prev"></param>
        /// <param name="curr"></param>
        /// <param name="data"></param>
        /// <param name="stop"></param>
        /// <returns></returns>
        private bool Remove(Node prev, Node curr, T data, bool stop)
        {
            if (curr.Data.Equals(data))
            {
                DoRemoval(prev, curr);
                return stop;
            }
            return false;
        }

        /// <summary>
        /// Prints the contents of the list
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            Traverse((prev, curr) =>
            {
                sb.Append(curr.Data);
                sb.Append("\n");
                return false;
            });
            return sb.ToString();
        }

        /// <summary>
        /// Common function to traverse the list start to head
        /// Return true from process to end traversal
        /// </summary>
        /// <param name="Process"></param>
        /// <returns>Last item on the list</returns>
        private Node Traverse(Func<Node, Node, bool> Process)
        {
            var curr = head;
            Node prev = null; //keep track so we can return the last one at the end

            while (curr != null)
            {
                if (Process != null && Process(prev, curr) == true)
                {
                    break;
                }

                prev = curr;
                curr = curr.Next;
            }

            return prev;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (!(obj is MyLinkedList<T>))
                return false;

            var tmp = (MyLinkedList<T>)obj;

            if (tmp.Count != this.Count)
                return false;

            Node tmpHead = tmp.head;

            while (head != null)
            {
                if (!tmpHead.Data.Equals(this.head.Data))
                    return false;

                head = head.Next;
                tmpHead = tmpHead.Next;
            }
            return true;
        }

        /// <summary>
        /// Node entry
        /// </summary>
        public class Node
        {
            internal Node Next { get; set; }
            internal T Data { get; set; }

            internal Node(T data, Node next)
            {
                Data = data;
                Next = next;
            }
        }
    }


}
