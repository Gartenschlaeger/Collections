using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace PureFreak.Collections.Tests
{
    [TestClass]
    public class TreeTests
    {
        #region Test methods

        [TestMethod]
        public void AddNodesTest()
        {
            var tree = new Tree<int>();
            tree.Nodes.Create("LICENSE.txt");
            tree.Nodes.Create("README.txt");

            Assert.AreEqual(2, tree.Nodes.Count);
        }

        [TestMethod]
        public void ClearNodesTest()
        {
            var tree = new Tree<int>();
            tree.Nodes.Create("Test1");
            tree.Nodes.Create("Test2");
            var test3 = tree.Nodes.Create("Test3");
            test3.Nodes.Create("Test4");
            test3.Nodes.Create("Test5");

            test3.Nodes.Clear();
            Assert.AreEqual(0, test3.Nodes.Count);

            tree.Nodes.Clear();
            Assert.AreEqual(0, tree.Nodes.Count);
        }

        [TestMethod]
        public void NameTest()
        {
            var tree = new Tree<int>();
            var textFiles = tree.Nodes.Create("Texts");
            var license = textFiles.Nodes.Create("LICENSE.txt");
            var readme = textFiles.Nodes.Create("README.txt");
            var tutorials = textFiles.Nodes.Create("Tutorials");
            var general = tutorials.Nodes.Create("General.txt");

            Assert.AreEqual("Texts", textFiles.FullName);
            Assert.AreEqual("Texts", textFiles.Name);

            Assert.AreEqual("Texts/LICENSE.txt", license.FullName);
            Assert.AreEqual("LICENSE.txt", license.Name);

            Assert.AreEqual("Texts/README.txt", readme.FullName);
            Assert.AreEqual("README.txt", readme.Name);

            Assert.AreEqual("Texts/Tutorials/General.txt", general.FullName);
            Assert.AreEqual("General.txt", general.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void UniqueNameTest()
        {
            var tree = new Tree<int>();
            tree.Nodes.Create("test.txt");
            tree.Nodes.Create("test.txt");
        }

        [TestMethod]
        public void LevelTest()
        {
            var tree = new Tree<string>();
            var node1 = tree.Create("Level1");
            var node2 = node1.Create("Level2");
            var node3 = node2.Create("Level3");

            Assert.AreEqual(1, node1.Level);
            Assert.AreEqual(2, node2.Level);
            Assert.AreEqual(3, node3.Level);
        }

        #endregion
    }
}