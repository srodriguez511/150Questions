using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Chapter2
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void C2Q2()
        {
            var ll = new LinkList.MyLinkedList<int>();
            ll.Add(8); ll.Add(10); ll.Add(5); ll.Add(7); ll.Add(2);
            ll.Add(1); ll.Add(5); ll.Add(4); ll.Add(10); ll.Add(1);
            var result = ll.FindNthFromLast(7);
            var test = 7;
            Assert.AreEqual(result, test);
        }
    }
}
