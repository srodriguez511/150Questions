using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _150Questions
{
    [TestClass]
    public class Q2Test
    {
        [TestMethod]
        public void C1Q2()
        {
            var result = ReverseString(new char[] { 'H', 'E', 'L', 'L', 'O', '\0' });
            var test = new char[] { 'O', 'L', 'L', 'E', 'H', '\0' };
            CollectionAssert.AreEqual(result, test);
        }

        [TestMethod]
        public void C1Q2_2()
        {
            var result = ReverseInPlace(new char[] { 'H', 'E', 'L', 'L', 'O', '\0' });
            var test = new char[] { 'O', 'L', 'L', 'E', 'H', '\0' };
            CollectionAssert.AreEqual(result, test);
        }

        public char[] ReverseString(char[] str)
        {
            char[] reversed = new char[str.Length];
            for (int i = 0; i < str.Length - 1; i++)
            {       
                reversed[i] = str[str.Length - 2 - i];
            }
            reversed[str.Length - 1] = '\0';
            return reversed;
        }

        public char[] ReverseInPlace(char[] str)
        {
            int mid = (str.Length - 1) / 2;
            for (int i = 0; i < mid; i++)
            {
                char tmp = str[i];
                str[i] = str[str.Length - i - 2];
                str[str.Length - i - 2] = tmp;
            }
            str[str.Length - 1] = '\0';

            return str;
        }
    }
}
