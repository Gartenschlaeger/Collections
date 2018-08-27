using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PureFreak.Collections.Tests
{
    [TestClass]
    public class CirularBufferTests
    {
        #region Test methods

        [TestMethod]
        public void EnqueueDequeueTest()
        {
            const int valuesCount = 8;

            var buffer = new CircularBuffer<int>(10);
            for (int iteration = 0; iteration < 10; iteration++)
            {
                for (int i = 1; i <= valuesCount; i++)
                {
                    buffer.Enqueue(i);
                }

                Assert.AreEqual(valuesCount, buffer.Count);

                for (int i = 1; i <= valuesCount; i++)
                {
                    Assert.AreEqual(i, buffer.Dequeue());
                }

                Assert.AreEqual(0, buffer.Count);
            }
        }

        [TestMethod]
        public void CapacityTest()
        {
            var buffer = new CircularBuffer<int>(25);

            Assert.AreEqual(25, buffer.Capacity);
        }

        [TestMethod]
        public void ClearTest()
        {
            var buffer = new CircularBuffer<int>();
            buffer.Enqueue(1);
            buffer.Enqueue(2);
            buffer.Enqueue(3);

            buffer.Clear();

            Assert.AreEqual(0, buffer.Count);
        }

        [TestMethod]
        public void CountTest()
        {
            var buffer = new CircularBuffer<int>();
            buffer.Enqueue(1);
            buffer.Dequeue();
            buffer.Enqueue(2);
            buffer.Enqueue(3);

            Assert.AreEqual(2, buffer.Count);
        }

        [TestMethod]
        public void ToArrayTest()
        {
            var values = new int[] { 10, 12, 15, 22, 23, 28, 30, 32 };

            var buffer = new CircularBuffer<int>(10);

            for (int i = 0; i < 5; i++)
            {
                buffer.Enqueue(i);
                buffer.Dequeue();
            }

            for (int i = 0; i < values.Length; i++)
            {
                buffer.Enqueue(values[i]);
            }

            var arr = buffer.ToArray();

            Assert.AreEqual(values.Length, arr.Length);
            CollectionAssert.AreEqual(values, arr);
        }

        #endregion
    }
}