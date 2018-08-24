using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PureFreak.Collections.Tests
{
    [TestClass]
    public class BitSetTests
    {
        [TestMethod]
        public void Capacity()
        {
            var bs = new BitSet(10);

            Assert.AreEqual(10, bs.Capacity);
        }

        [TestMethod]
        public void AutoIncrementCapacity()
        {
            var bs = new BitSet(8);
            bs.Set(10, true);

            Assert.AreEqual(16, bs.Capacity);
            Assert.AreEqual(true, bs.IsSet(10));
        }

        [TestMethod]
        public void Set()
        {
            var bs = new BitSet();
            bs.Set(5, true);
            bs.Set(9, true);

            Assert.AreEqual(false, bs.IsSet(0));
            Assert.AreEqual(true, bs.IsSet(5));
            Assert.AreEqual(true, bs.IsSet(9));
        }

        [TestMethod]
        public void SetAll()
        {
            var bs = new BitSet();
            bs.SetAll(true);

            for (int i = 0; i < bs.Capacity; i++)
            {
                Assert.AreEqual(true, bs.IsSet(i));
            }
        }

        [TestMethod]
        public void Invert()
        {
            var bs = new BitSet(5);
            bs.Set(1, true);
            bs.Set(2, true);

            bs.Invert();

            Assert.AreEqual(true, bs.IsSet(0));
            Assert.AreEqual(false, bs.IsSet(1));
            Assert.AreEqual(false, bs.IsSet(2));
            Assert.AreEqual(true, bs.IsSet(3));
            Assert.AreEqual(true, bs.IsSet(4));
        }

        [TestMethod]
        public void ToStringResult()
        {
            var bs = new BitSet(16);
            bs.Set(2, true);
            bs.Set(5, true);
            bs.Set(12, true);

            Assert.AreEqual("00100100 00001000", bs.ToString());
        }

        [TestMethod]
        public void ToArrayTest()
        {
            var bs = new BitSet(10);
            bs.Set(2, true);
            bs.Set(5, true);
            bs.Set(7, true);

            var arr = bs.ToArray();

            for (int i = 0; i < bs.Capacity; i++)
            {
                Assert.AreEqual(bs.IsSet(i), arr[i]);
            }
        }
    }
}