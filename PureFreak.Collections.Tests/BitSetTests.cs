using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PureFreak.Collections.Tests
{
    [TestClass]
    public class BitSetTests
    {
        [TestMethod]
        public void Capacity()
        {
            var array = new BitSet(10);

            Assert.AreEqual(10, array.Capacity);
        }

        [TestMethod]
        public void AutoIncrementCapacity()
        {
            var array = new BitSet(8);

            array.Set(10, true);

            Assert.AreEqual(16, array.Capacity);
            Assert.AreEqual(true, array.IsSet(10));
        }

        [TestMethod]
        public void Set()
        {
            var array = new BitSet();
            array.Set(5, true);
            array.Set(9, true);

            Assert.AreEqual(false, array.IsSet(0));
            Assert.AreEqual(true, array.IsSet(5));
            Assert.AreEqual(true, array.IsSet(9));
        }

        [TestMethod]
        public void SetAll()
        {
            var array = new BitSet();
            array.SetAll(true);

            for (int i = 0; i < array.Capacity; i++)
            {
                Assert.AreEqual(true, array.IsSet(i));
            }
        }

        [TestMethod]
        public void Invert()
        {
            var array = new BitSet(5);
            array.Set(1, true);
            array.Set(2, true);

            array.Invert();

            Assert.AreEqual(true, array.IsSet(0));
            Assert.AreEqual(false, array.IsSet(1));
            Assert.AreEqual(false, array.IsSet(2));
            Assert.AreEqual(true, array.IsSet(3));
            Assert.AreEqual(true, array.IsSet(4));
        }

        [TestMethod]
        public void ToStringResult()
        {
            var array = new BitSet(16);
            array.Set(2, true);
            array.Set(5, true);
            array.Set(12, true);

            Assert.AreEqual("00100100 00001000", array.ToString());
        }
    }
}