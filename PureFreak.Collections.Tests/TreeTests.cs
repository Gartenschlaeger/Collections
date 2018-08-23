using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PureFreak.Collections.Tests
{
    [TestClass]
    public class TreeTests
    {
        [TestMethod]
        public void NodesCount()
        {
            var tree = new Tree<int, string>();

            var users = tree.Create(1, "Users");

            users.Create(1, "Max Mustermann");
            users.Create(2, "Susi Strolch");

            Assert.AreEqual(1, tree.Count);
            Assert.AreEqual(2, users.Count);
        }

        [TestMethod]
        public void Name()
        {
            var tree = new Tree<string, int>();

            var windows = tree.Create("Windows", 1);
            var system = windows.Create("System", 2);
            var temp = windows.Create("Temp", 3);

            Assert.AreEqual("Windows", windows.Name);
            Assert.AreEqual("System", system.Name);
            Assert.AreEqual("Temp", temp.Name);
        }

        [TestMethod]
        public void FullName()
        {
            var tree = new Tree<string, int>();
            tree.Separator = '\\';

            var windows = tree.Create("Windows", 1);
            var system = windows.Create("System", 2);
            var temp = windows.Create("Temp", 3);

            Assert.AreEqual("Windows", windows.FullName);
            Assert.AreEqual("Windows\\System", system.FullName);
            Assert.AreEqual("Windows\\Temp", temp.FullName);
        }
    }
}