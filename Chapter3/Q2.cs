using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Chapter3
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void C3Q2()
        {
            var stack = new Stack();
            stack.push(1);
            stack.push(2);
            stack.push(3);
            stack.push(4);
            var result = stack.min().data;
            Assert.AreEqual(result, 1);
        }
    }
}
