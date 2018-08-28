using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PureFreak.Collections.Tests
{
    [TestClass]
    public class BagTests
    {
        #region Test methods

        [TestMethod]
        public void AddTest()
        {
            var bag = new Bag<int>();

            for (int i = 1; i <= 5; i++)
                bag.Add(i);

            Assert.AreEqual(5, bag.Count);

            for (int i = 1; i <= 5; i++)
                Assert.AreEqual(i, bag.Get(i - 1));
        }

        [TestMethod]
        public void ToArrayTest()
        {
            var bag = new Bag<int>();
            bag.Add(1);
            bag.Add(2);
            bag.Add(3);
            bag.Set(10, 4);
            bag.Set(25, 5);

            var arr = bag.ToArray();

            Assert.AreEqual(5, arr.Length);
            Assert.AreEqual(1, arr[0]);
            Assert.AreEqual(2, arr[1]);
            Assert.AreEqual(3, arr[2]);
            Assert.AreEqual(4, arr[3]);
            Assert.AreEqual(5, arr[4]);
        }

        #endregion
    }
}