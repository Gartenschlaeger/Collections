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

        #endregion
    }
}