using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _150Questions
{
    [TestClass]
    public class Q8Test
    {
        [TestMethod]
        public void C1Q8()
        {
            string s1 = "erbottlewat";
            string s2 = "waterbottle";
            Assert.AreEqual(isRotation(s1, s2), true);
        }

        public bool isRotation(string s1, string s2)
        {
            if (s1.Length != s2.Length)
                return false;

            s2 += s2;
            return s2.Contains(s1);
        }
    }
}
