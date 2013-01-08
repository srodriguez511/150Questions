using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chapter3
{
    public class SetOfStacks<T>
    {
        private List<Stack<T>> stacks;
        private const int MAX = 2;

        public int Count { get; private set; }


        public SetOfStacks()
        {
            Clear();
        }

        public void Push(T item)
        {
            var stack = stacks.FirstOrDefault(st => st.Count < MAX);
            if (stack == null)
            {
                stack = new Stack<T>();
                stacks.Add(stack);
            }
            stack.Push(item);
        }

        public T Pop()
        {
            var stack = stacks.LastOrDefault(st => st.Count > 0);
            if (stack == null)
            {
                throw new ArgumentException("Stack is empty");
            }

            var item = stack.Pop();
            if (stack.Count == 0)
                stacks.Remove(stack);

            return item;
        }

        public T Peek()
        {
            var stack = stacks.LastOrDefault(st => st.Count > 0);
            if (stack == null)
            {
                throw new ArgumentException("Stack is empty");
            }
            return stack.Peek();
        }

        private T RemoveBottom(int index)
        {
            var stack = stacks[index];
            var tempStack = new Stack<T>();
            while (stack.Count > 1)
            {
                tempStack.Push(stack.Pop());
            }

            var result = stack.Pop();

            while (tempStack.Count > 0)
            {
                stack.Push(tempStack.Pop());
            }

            return result;
        }

        public T PopAt(int index)
        {
            if (index < 0 || index > stacks.Count - 1)
                throw new Exception("Improper index");

            var stack = stacks[index];
            var result = stack.Pop();

            //Now must shift
            if (index != stacks.Count - 1)
            {
                bool add = false;
                T itemToAdd = default(T);
                for (int i = stacks.Count - 1; i > index; i--)
                {
                    var tmp = stacks[i];
                    if (add)
                        tmp.Push(itemToAdd);

                    itemToAdd = RemoveBottom(i);
                    add = true;

                    if (tmp.Count == 0)
                        stacks.Remove(tmp);
                }
                stacks[index].Push(itemToAdd);
            }

            return result;
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < stacks.Count; i++)
            {
                if (stacks[i].Contains(item))
                    return true;
            }
            return false;
        }

        public void Clear()
        {
            stacks = new List<Stack<T>>();
        }

    }
}
