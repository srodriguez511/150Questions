using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Chapter3
{
    [TestClass]
    public class UnitTest3
    {
        [TestMethod]
        public void C3Q4()
        {
            List<Tower> towers = new List<Tower>();
            var T1 = new Tower(0);
            T1.add(3);
            T1.add(2);
            T1.add(1);
            var T2 = new Tower(1);
            var T3 = new Tower(2);
            towers.Add(T1);
            towers.Add(T2);
            towers.Add(T3);
            towers[0].moveDisks(3, towers[2], towers[1]);

        }

        public class Tower
        {
            private Stack<int> disks;
            public int Index { get; private set; }
            public Tower(int i)
            {
                disks = new Stack<int>();
                Index = i;
            }

            public void add(int d)
            {
                if (disks.Count != 0 && disks.Peek() <= d)
                {
                    //Error
                }
                else
                {
                    disks.Push(d);
                }
            }

            public void moveTopTo(Tower t)
            {
                int top = disks.Pop();
                t.add(top);
            }

            public void moveDisks(int n, Tower destination, Tower buffer)
            {
                if (n > 0)
                {
                    moveDisks(n - 1, buffer, destination);
                    moveTopTo(destination);
                    buffer.moveDisks(n - 1, destination, this);
                }
            }
        }
    }
}
