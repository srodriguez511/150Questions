using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _150Questions
{
    [TestClass]
    public class Q5Test
    {
        [TestMethod]
        public void C1Q5()
        {
            var result = ReplaceSpace("HEY HOW ARE YOU".ToCharArray());
            var test = "HEY%20HOW%20ARE%20YOU".ToCharArray();
            CollectionAssert.AreEqual(result,test);
        }

        public char[] ReplaceSpace(char[] str)
        {
            int count = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == ' ')
                    count++;
            }

            int newLength = str.Length + (count * 2);
            char[] newStr = new char[newLength];
            int newStrPos = 0;

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == ' ')
                {
                    newStr[newStrPos] = '%';
                    newStr[++newStrPos] = '2';
                    newStr[++newStrPos] = '0';
                    newStrPos++;
                }
                else
                {
                    newStr[newStrPos] = str[i];
                    newStrPos++;
                }
            }
            return newStr;
        }
    }
}
