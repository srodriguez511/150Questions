using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _150Questions
{
    [TestClass]
    public class Q7Test
    {
        [TestMethod]
        public void C1Q7()
        {
            int[,] matrix = new int[3, 3] { { 1, 2, 3 }, { 4, 0, 6 }, { 7, 8, 9 } };
            var result = ZeroMatrix(matrix);
            var test = new int[3, 3] { { 1, 0, 3 }, { 0, 0, 0 }, { 7, 0, 9 } };
            CollectionAssert.AreEqual(result, test);
        }

        public int[,] ZeroMatrix(int[,] matrix)
        {
            int[] row = new int[matrix.GetLength(1)];
            int[] col = new int[matrix.GetLength(0)];

            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        row[i] = 1;
                        col[j] = 1;
                    }
                }
            }

            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    if (row[i] == 1 || col[j] == 1)
                    {
                        matrix[i, j] = 0;
                    }
                }
            }
            return matrix;
        }
    }
}
