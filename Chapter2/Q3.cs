using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LinkList;

namespace Chapter2
{
    [TestClass]
    public class Q3
    {
        [TestMethod]
        public void C2Q3()
        {
            var ll = new MyLinkedList<int>();
            ll.Add(1); ll.Add(2); ll.Add(3); ll.Add(4); ll.Add(5);
            ll.DeleteMiddle(ll.FindMiddleNode());
            var test = new MyLinkedList<int>();
            test.Add(1); test.Add(2); test.Add(4); test.Add(5);
            Assert.AreEqual(ll, test);            
        }
    }
}
