using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;
using System.Collections.Generic;

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

        #region verifyName
        [TestMethod]
        public void verifyName_Null_ThenFalse()
        {
            Boat b = new Boat() { Name = null };

            MethodInfo methodInfo = typeof(Tile).GetMethod("verifyName", BindingFlags.NonPublic | BindingFlags.Instance);
            object[] parameters = { };
            Assert.IsTrue((Boolean)methodInfo.Invoke(b, parameters));
        }

        [TestMethod]
        public void verifyName_Empty_ThenFalse()
        {
            Boat b = new Boat() { Name = "" };

            MethodInfo methodInfo = typeof(Tile).GetMethod("verifyName", BindingFlags.NonPublic | BindingFlags.Instance);
            object[] parameters = { };
            Assert.IsTrue((Boolean)methodInfo.Invoke(b, parameters));
        }

        [TestMethod]
        public void verifyName_NotEmpty_ThenTrue()
        {
            Boat b = new Boat() { Name = "ee" };

            MethodInfo methodInfo = typeof(Tile).GetMethod("verifyName", BindingFlags.NonPublic | BindingFlags.Instance);
            object[] parameters = { };
            Assert.IsTrue((Boolean)methodInfo.Invoke(b, parameters));
        }
        #endregion verifyName

        #region verifyLength
        [TestMethod]
        public void verifyLength_LengthNegative_ThenFalse()
        {
            Boat b = new Boat() { Length = -10 };

            MethodInfo methodInfo = typeof(Tile).GetMethod("verifyLength", BindingFlags.NonPublic | BindingFlags.Instance);
            object[] parameters = { };
            Assert.IsFalse((Boolean)methodInfo.Invoke(b, parameters));
        }

        [TestMethod]
        public void verifyLength_LengthZero_ThenFalse()
        {
            Boat b = new Boat() { Length = 0 };

            MethodInfo methodInfo = typeof(Tile).GetMethod("verifyLength", BindingFlags.NonPublic | BindingFlags.Instance);
            object[] parameters = { };
            Assert.IsFalse((Boolean)methodInfo.Invoke(b, parameters));
        }

        [TestMethod]
        public void verifyLength_LengthPositive_ThenTrue()
        {
            Boat b = new Boat() { Length = 1 };

            MethodInfo methodInfo = typeof(Tile).GetMethod("verifyLength", BindingFlags.NonPublic | BindingFlags.Instance);
            object[] parameters = { };
            Assert.IsTrue((Boolean)methodInfo.Invoke(b, parameters));
        }

        [TestMethod]
        public void verifyLength_LengthMoreThan5_ThenFalse()
        {
            Boat b = new Boat() { Length = 6};

            MethodInfo methodInfo = typeof(Tile).GetMethod("verifyLength", BindingFlags.NonPublic | BindingFlags.Instance);
            object[] parameters = { };
            Assert.IsFalse((Boolean)methodInfo.Invoke(b, parameters));
        }
        #endregion verifyLength

        #region verifyTopLeft
        [TestMethod]
        public void verifyTopLeft_XWrong_YWrong_ThenFalse()
        {
            Boat b = new Boat() { TopLeft = new Tile() { X = -10, Y = -1}};

            MethodInfo methodInfo = typeof(Tile).GetMethod("verifyTopLeft", BindingFlags.NonPublic | BindingFlags.Instance);
            object[] parameters = { };
            Assert.IsFalse((Boolean)methodInfo.Invoke(b, parameters));
        }

        [TestMethod]
        public void verifyTopLeft_XWrong_YGood_ThenFalse()
        {
            Boat b = new Boat() { TopLeft = new Tile() { X = -2, Y = 4} };

            MethodInfo methodInfo = typeof(Tile).GetMethod("verifyTopLeft", BindingFlags.NonPublic | BindingFlags.Instance);
            object[] parameters = { };
            Assert.IsFalse((Boolean)methodInfo.Invoke(b, parameters));
        }

        [TestMethod]
        public void verifyTopLeft_XGood_YWrong_ThenFalse()
        {
            Boat b = new Boat() { TopLeft = new Tile() { X = 3, Y = -7} };

            MethodInfo methodInfo = typeof(Tile).GetMethod("verifyTopLeft", BindingFlags.NonPublic | BindingFlags.Instance);
            object[] parameters = { };
            Assert.IsFalse((Boolean)methodInfo.Invoke(b, parameters));
        }

        [TestMethod]
        public void verifyTopLeft_XGood_YGood_ThenTrue()
        {
            Boat b = new Boat() { TopLeft = new Tile() { X = 4, Y = 0} };

            MethodInfo methodInfo = typeof(Tile).GetMethod("verifyTopLeft", BindingFlags.NonPublic | BindingFlags.Instance);
            object[] parameters = { };
            Assert.IsTrue((Boolean)methodInfo.Invoke(b, parameters));
        }
        #endregion verifyTopLeft

        #region verifyBoatTiles
        [TestMethod]
        public void verifyBoatTiles_Null_ThenFalse()
        {
            Boat b = new Boat() { BoatTiles = null };

            MethodInfo methodInfo = typeof(Tile).GetMethod("verifyBoatTiles", BindingFlags.NonPublic | BindingFlags.Instance);
            object[] parameters = { };
            Assert.IsFalse((Boolean)methodInfo.Invoke(b, parameters));
        }

        [TestMethod]
        public void verifyBoatTiles_Empty_ThenFalse()
        {
            Boat b = new Boat() { BoatTiles = new List<Tile>() };

            MethodInfo methodInfo = typeof(Tile).GetMethod("verifyBoatTiles", BindingFlags.NonPublic | BindingFlags.Instance);
            object[] parameters = { };
            Assert.IsFalse((Boolean)methodInfo.Invoke(b, parameters));
        }

        [TestMethod]
        public void verifyBoatTiles_CountSameAsLengthCountSameAsLengthAndTilesNOTInAlignement_ThenFalse()
        {
            Boat b = new Boat() { BoatTiles = new List<Tile>() };
            b.BoatTiles.Add(new Tile() { X = 1, Y = 2 });
            b.BoatTiles.Add(new Tile() { X = 1, Y = 3 });
            b.Length = 2;

            MethodInfo methodInfo = typeof(Tile).GetMethod("verifyBoatTiles", BindingFlags.NonPublic | BindingFlags.Instance);
            object[] parameters = { };
            Assert.IsFalse((Boolean)methodInfo.Invoke(b, parameters));
        }


        [TestMethod]
        public void verifyBoatTiles_CountSameAsLengthAndTilesInAlignement_ThenTrue()
        {
            Boat b = new Boat() { BoatTiles = new List<Tile>() };
            b.BoatTiles.Add(new Tile() { X = 1, Y = 2 });
            b.BoatTiles.Add(new Tile() { X = 1, Y = 3 });
            b.Length = 2;

            MethodInfo methodInfo = typeof(Tile).GetMethod("verifyBoatTiles", BindingFlags.NonPublic | BindingFlags.Instance);
            object[] parameters = { };
            Assert.IsTrue((Boolean)methodInfo.Invoke(b, parameters));
        }
        #endregion verifyBoatTiles

        #region verifyPlayer
        [TestMethod]
        public void verifyPlayer_Null_ThenFalse()
        {
            Boat b = new Boat() { Owner = null };

            MethodInfo methodInfo = typeof(Tile).GetMethod("verifyPlayer", BindingFlags.NonPublic | BindingFlags.Instance);
            object[] parameters = { };
            Assert.IsFalse((Boolean)methodInfo.Invoke(b, parameters));
        }

        [TestMethod]
        public void verifyPlayer_IdNegative_ThenFalse()
        {
            Boat b = new Boat() { Owner = new Player() { Id = -2} };

            MethodInfo methodInfo = typeof(Tile).GetMethod("verifyPlayer", BindingFlags.NonPublic | BindingFlags.Instance);
            object[] parameters = { };
            Assert.IsFalse((Boolean)methodInfo.Invoke(b, parameters));
        }

        [TestMethod]
        public void verifyPlayer_IdZero_ThenFalse()
        {
            Boat b = new Boat() { Owner = new Player() { Id=0} };

            MethodInfo methodInfo = typeof(Tile).GetMethod("verifyPlayer", BindingFlags.NonPublic | BindingFlags.Instance);
            object[] parameters = { };
            Assert.IsFalse((Boolean)methodInfo.Invoke(b, parameters));
        }

        [TestMethod]
        public void verifyPlayer_NameNull_ThenFalse()
        {
            Boat b = new Boat() { Owner = new Player() { Name = null } };

            MethodInfo methodInfo = typeof(Tile).GetMethod("verifyPlayer", BindingFlags.NonPublic | BindingFlags.Instance);
            object[] parameters = { };
            Assert.IsFalse((Boolean)methodInfo.Invoke(b, parameters));
        }

        [TestMethod]
        public void verifyPlayer_NameEmpty_ThenFalse()
        {
            Boat b = new Boat() { Owner = new Player() { Name = "" } };

            MethodInfo methodInfo = typeof(Tile).GetMethod("verifyPlayer", BindingFlags.NonPublic | BindingFlags.Instance);
            object[] parameters = { };
            Assert.IsFalse((Boolean)methodInfo.Invoke(b, parameters));
        }

        [TestMethod]
        public void verifyPlayer_MapNull_ThenFalse()
        {
            Boat b = new Boat() { Owner = new Player() { Map = null } };

            MethodInfo methodInfo = typeof(Tile).GetMethod("verifyPlayer", BindingFlags.NonPublic | BindingFlags.Instance);
            object[] parameters = { };
            Assert.IsFalse((Boolean)methodInfo.Invoke(b, parameters));
        }

        [TestMethod]
        public void verifyPlayer_BoatsListNull_ThenFalse()
        {
            Boat b = new Boat() { Owner = new Player() { Boats = null } };

            MethodInfo methodInfo = typeof(Tile).GetMethod("verifyPlayer", BindingFlags.NonPublic | BindingFlags.Instance);
            object[] parameters = { };
            Assert.IsFalse((Boolean)methodInfo.Invoke(b, parameters));
        }
        #endregion verifyPlayer

        #region Verify
        [TestMethod]
        public void Verify_IdWrong_ThenFalse() {
            Boat b = new Boat() { Id = 0};
            Assert.IsFalse(b.Verify());
        }

        [TestMethod]
        public void Verify_NameWrong_ThenFalse()
        {
            Boat b = new Boat() { Name = "" };
            Assert.IsFalse(b.Verify());
        }

        [TestMethod]
        public void Verify_LengthWrong_ThenFalse()
        {
            Boat b = new Boat() { Length = 0 };
            Assert.IsFalse(b.Verify());
        }

        [TestMethod]
        public void Verify_TopLeftWrong_ThenFalse()
        {
            Boat b = new Boat() { TopLeft = new Tile() { X = 0, Y = -1 } };
            Assert.IsFalse(b.Verify());
        }

        [TestMethod]
        public void Verify_BoatTilesWrong_ThenFalse()
        {
            Boat b = new Boat() { BoatTiles = null };
            Assert.IsFalse(b.Verify());
        }

        [TestMethod]
        public void Verify_PlayerWrong_ThenFalse()
        {
            Boat b = new Boat() { Owner = new Player() { Id = 0 } };
            Assert.IsFalse(b.Verify());
        }

        [TestMethod]
        public void Verify_AllGood_ThenTrue()
        {
            Boat b = new Boat();
            b.Owner = new Player() { Id = 1,Name = "ee",Boats = new List<Boat>(), Map = new Map() { Boats = new List<Boat>(), Height = 8, Width = 8, Tiles = new List<Tile>() } };
            b.BoatTiles = new List<Tile>() { new Tile() { X = 1, Y = 2 }, new Tile() { X = 1, Y = 3 } };
            b.Map = new Map() { Tiles = new List<Tile>(), Width = 8, Height = 8, Boats = new List<Boat>() };
            b.Length = 2;
            b.Name = "ee";
            b.TopLeft = new Tile() { X = 1, Y = 2 };
            Assert.IsTrue(b.Verify());
        }
        #endregion Verify
    }
}
