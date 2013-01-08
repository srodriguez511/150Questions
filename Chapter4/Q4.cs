using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Chapter4
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void C4Q4()
        {
            BinarySearchTree mine = new BinarySearchTree();
            mine.Insert(5);
            mine.Insert(4);
            mine.Insert(6);
            mine.Insert(7);
            mine.Insert(3);
            mine.Insert(8);
            mine.Traverse();

            updateBits(1024, 21, 2, 6);

        }

        public static int updateBits(int n, int m, int i, int j)
        {
            int max = ~0; /* All 1’s */

            // 1’s through position j, then 0’s
            int left = max - ((1 << j) - 1);

            // 1’s after position i
            int right = ((1 << i) - 1);

            // 1’s, with 0s between i and j
            int mask = left | right;

            // Clear i through j, then put m in there
            return (n & mask) | (m << i);
        }
    }
}
