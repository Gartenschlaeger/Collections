using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace PureFreak.Collections.Tests
{
    [TestClass]
    public class QueueExtensionsTests
    {
        #region Test methods

        [TestMethod]
        public void EnqueueTest()
        {
            var queue = new Queue<int>();
            queue.EnqueueRange(new[] { 1, 2, 3, 4, 5 });

            Assert.AreEqual(5, queue.Count);
            Assert.AreEqual(1, queue.Dequeue());
            Assert.AreEqual(2, queue.Dequeue());
            Assert.AreEqual(3, queue.Dequeue());
            Assert.AreEqual(4, queue.Dequeue());
            Assert.AreEqual(5, queue.Dequeue());
        }

        #endregion
    }
}