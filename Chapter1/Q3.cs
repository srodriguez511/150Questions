using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _150Questions
{
    [TestClass]
    public class Q3Test
    {
        [TestMethod]
        public void C1Q3()
        {
            var result = removeDuplicates("HELLO".ToCharArray());
            var test = "HELO\0".ToCharArray();
            CollectionAssert.AreEqual(result, test);
        }


        public static char [] removeDuplicates(char[] str)
        {
            if (str == null)
            {
                return str;
            }
            int len = str.Length;
            if (len < 2)
            {
                return str;
            }

            int tail = 1;

            for (int i = 1; i < len; ++i)
            {
                int j;
                for (j = 0; j < tail; ++j)
                {
                    if (str[i] == str[j])
                    {
                        break;
                    }
                }

                if (j == tail)
                {
                    str[tail] = str[i];
                    ++tail;
                }

            }
            for (; tail < len; tail++)
            {
                str[tail] = '\0';
            }
            return str;
        }
    }
}
