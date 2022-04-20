using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;

namespace Battleship.Test
{
    [TestClass]
    public class BoatTester
    {
        #region verifyId
        [TestMethod]
        public void verifyId_IdNegative_ThenFalse()
        {
            Boat b = new Boat() { Id = -10};

            MethodInfo methodInfo = typeof(Tile).GetMethod("verifyId", BindingFlags.NonPublic | BindingFlags.Instance);
            object[] parameters = { };
            Assert.IsFalse((Boolean)methodInfo.Invoke(b, parameters));
        }

        [TestMethod]
        public void verifyId_IdZero_ThenFalse()
        {
            Boat b = new Boat() { Id = 0};

            MethodInfo methodInfo = typeof(Tile).GetMethod("verifyId", BindingFlags.NonPublic | BindingFlags.Instance);
            object[] parameters = { };
            Assert.IsFalse((Boolean)methodInfo.Invoke(b, parameters));
        }

        [TestMethod]
        public void verifyId_IdPositive_ThenFalse()
        {
            Boat b = new Boat() { Id = 4};

            MethodInfo methodInfo = typeof(Tile).GetMethod("verifyId", BindingFlags.NonPublic | BindingFlags.Instance);
            object[] parameters = { };
            Assert.IsTrue((Boolean)methodInfo.Invoke(b, parameters));
        }
        #endregion verifyId
    }
}
