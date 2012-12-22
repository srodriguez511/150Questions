using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _150Questions
{
    [TestClass]
    public class Q4Test
    {
        [TestMethod]
        public void C1Q4()
        {
            Assert.AreEqual(IsAnagram("HEYO", "HEYO"), true);
        }

        public bool IsAnagram(string str1, string str2)
        {
            if (str1.Length != str2.Length)
                return false;

            Array.Sort(str1.ToCharArray());
            Array.Sort(str2.ToCharArray());

            return str1.Equals(str2);
        }
    }
}
