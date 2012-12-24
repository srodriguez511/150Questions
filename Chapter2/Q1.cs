using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LinkList;

namespace Chapter2
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void C2Q1()
        {
            var result = new MyLinkedList<int>();
            result.Add(1); result.Add(2); result.Add(1); result.Add(3); result.Add(1); result.Add(4); result.Add(1);
            result.RemoveDuplicates();
            var test = new MyLinkedList<int>();
            test.Add(1); test.Add(2); test.Add(3); test.Add(4);
            Assert.AreEqual(result, test);
        }
    }
}
