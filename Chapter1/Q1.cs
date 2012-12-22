using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace _150Questions
{
    [TestClass]
    public class Q1Test
    {
        [TestMethod]
        public void C1Q1()
        {
            Assert.AreEqual(IsUnique("YES".ToCharArray()), true);
            Assert.AreEqual(IsUnique("TEST".ToCharArray()), false);
            Assert.AreEqual(IsUnique("INFO".ToCharArray()), true);
            Assert.AreEqual(IsUnique("TOMORROW".ToCharArray()), false);
        }

        [TestMethod]
        public void C1Q1_2()
        {
            Assert.AreEqual(IsUnique2("YES".ToCharArray()), true);
            Assert.AreEqual(IsUnique2("TEST".ToCharArray()), false);
            Assert.AreEqual(IsUnique2("INFO".ToCharArray()), true);
            Assert.AreEqual(IsUnique2("TOMORROW".ToCharArray()), false);
        }

        public bool IsUnique(char[] str)
        {
            //Just assume all uppercase
            List<char> chars = new List<char>();
            for (int i = 0; i < str.Length; i++)
            {
                if (chars.Contains(str[i]))
                    return false;
                chars.Add(str[i]);
            }
            return true;
        }

        public bool IsUnique2(char[] str)
        {
            Array.Sort(str);
            for (int i = 0; i < str.Length - 1; i++)
            {
                if (str[i] == str[i + 1])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
