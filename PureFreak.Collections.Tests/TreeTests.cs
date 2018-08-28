using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace PureFreak.Collections.Tests
{
    [TestClass]
    public class TreeTests
    {
        #region Test methods

        [TestMethod]
        public void AddNodes()
        {
            var tree = new Tree<int>();
            tree.Nodes.Create("LICENSE.txt");
            tree.Nodes.Create("README.txt");

            Assert.AreEqual(2, tree.Nodes.Count);
        }

        [TestMethod]
        public void FullName()
        {
            var tree = new Tree<int>();
            var textFiles = tree.Nodes.Create("Texts");
            var license = textFiles.Nodes.Create("LICENSE.txt");
            var readme = textFiles.Nodes.Create("README.txt");
            var tutorials = textFiles.Nodes.Create("Tutorials");
            var general = tutorials.Nodes.Create("General.txt");

            Assert.AreEqual("/Texts/LICENSE.txt", license.FullName);
            Assert.AreEqual("/Texts/README.txt", readme.FullName);
            Assert.AreEqual("/Texts/Tutorials/General.txt", general.FullName);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddUniqueName()
        {
            var tree = new Tree<int>();
            tree.Nodes.Create("test.txt");
            tree.Nodes.Create("test.txt");
        }

        #endregion
    }
}