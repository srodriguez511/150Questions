using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Chapter3
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void C3Q3()
        {
            SetOfStacks<int> st = new SetOfStacks<int>();
            st.Push(5);
            st.Push(6);
            st.Push(7);
            st.Push(8);
            Assert.AreEqual(st.Pop(), 8);
            Assert.AreEqual(st.Pop(), 7);
            Assert.AreEqual(st.Pop(), 6);
            Assert.AreEqual(st.Pop(), 5);
        }

        [TestMethod]
        public void C3Q3_2()
        {
            SetOfStacks<int> st = new SetOfStacks<int>();
            st.Push(5);
            st.Push(6);
            st.Push(7);
            st.Push(8);            
            Assert.AreEqual(st.PopAt(0), 6);
            Assert.AreEqual(st.Pop(), 8);
            Assert.AreEqual(st.Pop(), 7);
            Assert.AreEqual(st.Pop(), 5);
        }


    }
}
