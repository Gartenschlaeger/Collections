using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace PureFreak.Collections.Tests
{
    [TestClass]
    public class ListExtensionTests
    {
        [TestMethod]
        public void SwitchTest()
        {
            var list = new List<int>();
            list.Add(10);
            list.Add(20);

            list.Switch(0, 1);

            Assert.AreEqual(20, list[0]);
            Assert.AreEqual(10, list[1]);
        }

        [TestMethod]
        public void InteractTest()
        {
            var list = new List<int>();
            for (int i = 1; i <= 3; i++)
                list.Add(i);

            var callbackCallCounter = 0;
            list.Interact((f, s) =>
            {
                callbackCallCounter++;
                switch (callbackCallCounter)
                {
                    case 1:
                        Assert.AreEqual(f, 1);
                        Assert.AreEqual(s, 2);
                        break;
                    case 2:
                        Assert.AreEqual(f, 1);
                        Assert.AreEqual(s, 3);
                        break;

                    case 3:
                        Assert.AreEqual(f, 2);
                        Assert.AreEqual(s, 1);
                        break;
                    case 4:
                        Assert.AreEqual(f, 2);
                        Assert.AreEqual(s, 3);
                        break;

                    case 5:
                        Assert.AreEqual(f, 3);
                        Assert.AreEqual(s, 1);
                        break;
                    case 6:
                        Assert.AreEqual(f, 3);
                        Assert.AreEqual(s, 2);
                        break;
                }
            });

            Assert.AreEqual(6, callbackCallCounter);
        }

        [TestMethod]
        public void ShuffleTest()
        {
            var list = new List<int>();
            for (int i = 1; i <= 10; i++)
                list.Add(i);

            var listClone = new List<int>(list);
            listClone.Shuffle(new Random());

            CollectionAssert.AreNotEqual(listClone, list);
        }
    }
}