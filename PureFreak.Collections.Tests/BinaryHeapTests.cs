using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PureFreak.Collections.Tests
{
    [TestClass]
    public class BinaryHeapTests
    {
        #region Test methods

        [TestMethod]
        public void PushPopTest()
        {
            var heap = new BinaryHeap<int>();
            heap.Push(2);
            heap.Push(5);
            heap.Push(10);
            heap.Push(25);

            Assert.AreEqual(4, heap.Count);

            Assert.AreEqual(2, heap.Pop());
            Assert.AreEqual(5, heap.Pop());
            Assert.AreEqual(10, heap.Pop());
            Assert.AreEqual(25, heap.Pop());

            Assert.AreEqual(0, heap.Count);
        }

        [TestMethod]
        public void AscendingSortOrderTest()
        {
            var heap = new BinaryHeap<int>(10, SortOrder.Ascending);
            heap.Push(10);
            heap.Push(2);
            heap.Push(5);
            heap.Push(25);

            Assert.AreEqual(2, heap.Pop());
            Assert.AreEqual(5, heap.Pop());
            Assert.AreEqual(10, heap.Pop());
            Assert.AreEqual(25, heap.Pop());
        }

        [TestMethod]
        public void DescendingSortOrderTest()
        {
            var heap = new BinaryHeap<int>(10, SortOrder.Descending);
            heap.Push(10);
            heap.Push(2);
            heap.Push(5);
            heap.Push(25);

            Assert.AreEqual(25, heap.Pop());
            Assert.AreEqual(10, heap.Pop());
            Assert.AreEqual(5, heap.Pop());
            Assert.AreEqual(2, heap.Pop());
        }

        #endregion
    }
}