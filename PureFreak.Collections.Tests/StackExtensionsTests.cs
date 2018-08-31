using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace PureFreak.Collections.Tests
{
    [TestClass]
    public class StackExtensionsTests
    {
        #region Test methods

        [TestMethod]
        public void PushRangeTest()
        {
            var stack = new Stack<int>();
            stack.PushRange(new[] { 1, 2, 3, 4, 5 });

            Assert.AreEqual(5, stack.Count);
            Assert.AreEqual(5, stack.Pop());
            Assert.AreEqual(4, stack.Pop());
            Assert.AreEqual(3, stack.Pop());
            Assert.AreEqual(2, stack.Pop());
            Assert.AreEqual(1, stack.Pop());
        }

        #endregion
    }
}
