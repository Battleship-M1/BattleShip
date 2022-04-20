using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;

namespace Battleship.Test
{
    [TestClass]
    public class TileTester
    {
        #region Verify
        [TestMethod]
        public void Verify_XWrong_YGood_ThenFalse()
        {
            Tile tile = new Tile() { X = -10,Y = 3};
            Assert.IsFalse(tile.Verify());
        }

        [TestMethod]
        public void Verify_XGood_YWrong_ThenFalse()
        {
            Tile tile = new Tile() { X = 0, Y = -10};
            Assert.IsFalse(tile.Verify());
        }

        [TestMethod]
        public void Verify_XWrong_YWrong_ThenFalse()
        {
            Tile tile = new Tile() { X = -9, Y = -45};
            Assert.IsFalse(tile.Verify());
        }

        [TestMethod]
        public void Verify_XGood_YGood_ThenTrue()
        {
            Tile tile = new Tile() { X = 5, Y = 17};
            Assert.IsTrue(tile.Verify());
        }
        #endregion Verify

        #region verifyX
        [TestMethod]
        public void verifyX_XNegative_ThenFalse()
        {
            Tile tile = new Tile() { X = -10};

            MethodInfo methodInfo = typeof(Tile).GetMethod("verifyX", BindingFlags.NonPublic | BindingFlags.Instance);
            object[] parameters = {};
            Assert.IsFalse((Boolean)methodInfo.Invoke(tile, parameters));
        }

        [TestMethod]
        public void verifyX_XZero_ThenTrue()
        {
            Tile tile = new Tile() { X = 0 };

            MethodInfo methodInfo = typeof(Tile).GetMethod("verifyX", BindingFlags.NonPublic | BindingFlags.Instance);
            object[] parameters = { };
            Assert.IsFalse((Boolean)methodInfo.Invoke(tile, parameters));
        }

        [TestMethod]
        public void verifyX_XPositive_ThenTrue()
        {
            Tile tile = new Tile() { X = 10 };

            MethodInfo methodInfo = typeof(Tile).GetMethod("verifyX", BindingFlags.NonPublic | BindingFlags.Instance);
            object[] parameters = { };
            Assert.IsFalse((Boolean)methodInfo.Invoke(tile, parameters));
        }
        #endregion verifyX

        #region verifyX
        [TestMethod]
        public void verifyY_YNegative_ThenFalse()
        {
            Tile tile = new Tile() { Y = -10 };

            MethodInfo methodInfo = typeof(Tile).GetMethod("verifyY", BindingFlags.NonPublic | BindingFlags.Instance);
            object[] parameters = { };
            Assert.IsFalse((Boolean)methodInfo.Invoke(tile, parameters));
        }

        [TestMethod]
        public void verifyY_YZero_ThenTrue()
        {
            Tile tile = new Tile() { Y = 0 };

            MethodInfo methodInfo = typeof(Tile).GetMethod("verifyY", BindingFlags.NonPublic | BindingFlags.Instance);
            object[] parameters = { };
            Assert.IsFalse((Boolean)methodInfo.Invoke(tile, parameters));
        }

        [TestMethod]
        public void verifyY_YPositive_ThenTrue()
        {
            Tile tile = new Tile() { Y = 10 };

            MethodInfo methodInfo = typeof(Tile).GetMethod("verifyY", BindingFlags.NonPublic | BindingFlags.Instance);
            object[] parameters = { };
            Assert.IsFalse((Boolean)methodInfo.Invoke(tile, parameters));
        }
        #endregion verifyY
    }
}
