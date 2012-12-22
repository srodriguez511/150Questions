using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace _150Questions
{
    [TestClass]
    public class Q6Test
    {
        [TestMethod]
        public void C1Q6()
        {
            int[,] array = new int[3, 3] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            var result = Rotate90(array, 3);
            int[,] test = new int[3, 3] { { 7, 4, 1 }, { 8, 5, 2 }, { 9, 6, 3 } };
            CollectionAssert.AreEqual(result, test);
        }

        [TestMethod]
        public void C1Q6_2()
        {
            int[,] array = new int[3, 3] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            var result = Rotate90CC(array, 3);
            int[,] test = new int[3, 3] { { 3, 6, 9 }, { 2, 5, 8 }, { 1, 4, 7 } };
            CollectionAssert.AreEqual(result, test);
        }

        public int[,] Rotate90(int[,] image, int size)
        {
            for (int i = 0; i < size / 2; i++)
            {
                int beg = i;
                int ending = size - i - 1;

                for (int j = beg; j < ending; j++)
                {
                    int offset = j - beg;
                    int top = image[beg, j];
                    image[beg, j] = image[ending - offset, beg];
                    image[ending - offset, beg] = image[ending, ending - offset];
                    image[ending, ending - offset] = image[j, ending];
                    image[j, ending] = top; // right <- saved top
                }
            }
            return image;
        }

        public int[,] Rotate90CC(int[,] image, int size)
        {
            for (int i = 0; i < size / 2; i++)
            {
                int beg = i;
                int ending = size - i - 1;

                for (int j = beg; j < ending; j++)
                {
                    int offset = j - beg;
                    int top = image[beg, j];
                    image[beg, j] = image[j, ending];
                    image[j, ending] = image[ending, ending - offset];
                    image[ending, ending - offset] = image[ending - offset, beg];
                    image[ending - offset, beg] = top;
                }
            }
            return image;
        }
    }
}
