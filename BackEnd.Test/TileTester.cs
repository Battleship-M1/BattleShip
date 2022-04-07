using Microsoft.VisualStudio.TestTools.UnitTesting;
using BackEnd.Enums;

namespace BackEnd.Test
{
    [TestClass]
    public class TileTester
    {
        Tile testTile = new Tile(4,5);
        Tile outsideTile = new Tile(40,50);
        Map blankMap = new Map(0);
        Map okMap = new Map(8);

        #region IsOnMap(Map m)
        #region Tile_IsOnMap_WithBlankMap_ThenFalse()
        [TestMethod]
        public void Tile_IsOnMap_WithBlankMap_ThenFalse()
        {
            testTile.X = 4;
            testTile.Y = 5;
            blankMap.GenerateMap();
            Assert.IsFalse(testTile.IsOnMap(blankMap));
        }
        #endregion Tile_IsOnMap_WithBlankMap_ThenFalse()

        #region Tile_IsOnMap_InsideMap_ThenTrue()
        [TestMethod]
        public void Tile_IsOnMap_InsideMap_ThenTrue()
        {
            testTile.X = 4;
            testTile.Y = 5;
            Assert.IsTrue(testTile.IsOnMap(okMap));
        }
        #endregion Tile_IsOnMap_With8SizeMap_ThenTrue()

        #region Tile_IsOnMap_OutsideMap_ThenFalse()
        [TestMethod]
        public void Tile_IsOnMap_OutsideMap_ThenFalse()
        {
            Assert.IsFalse(outsideTile.IsOnMap(okMap));
        }
        #endregion Tile_IsOnMap_OutsideMap_ThenFalse()
        #endregion IsOnMap(Map m)

        #region GetYWithDirection()
        [TestMethod]
        public void GetYWithDirection_TOP_thenYminOne()
        {
            Assert.AreEqual(testTile.GetYWithDirection(Direction.TOP), testTile.Y - 1);
        }
        [TestMethod]
        public void GetYWithDirection_TOPLEFT_thenYminOne()
        {
            Assert.AreEqual(testTile.GetYWithDirection(Direction.TOP_LEFT), testTile.Y - 1);
        }
        [TestMethod]
        public void GetYWithDirection_TOPRIGHT_thenYminOne()
        {
            Assert.AreEqual(testTile.GetYWithDirection(Direction.TOP_RIGHT), testTile.Y - 1);
        }
        [TestMethod]
        public void GetYWithDirection_RIGHT_thenYunchanged()
        {
            Assert.AreEqual(testTile.GetYWithDirection(Direction.RIGHT), testTile.Y);
        }
        [TestMethod]
        public void GetYWithDirection_LEFT_thenYunchanged()
        {
            Assert.AreEqual(testTile.GetYWithDirection(Direction.LEFT), testTile.Y);
        }
        [TestMethod]
        public void GetYWithDirection_BOTTOM_thenYplusOne()
        {
            Assert.AreEqual(testTile.GetYWithDirection(Direction.BOTTOM), testTile.Y + 1);
        }
        [TestMethod]
        public void GetYWithDirection_BOTTOMLEFT_thenYplusOne()
        {
            Assert.AreEqual(testTile.GetYWithDirection(Direction.BOTTOM_LEFT), testTile.Y + 1);
        }
        [TestMethod]
        public void GetYWithDirection_BOTTOMRIGHT_thenYplusOne()
        {
            Assert.AreEqual(testTile.GetYWithDirection(Direction.BOTTOM_RIGHT), testTile.Y + 1);
        }
        #endregion GetYWithDirection()
    }
}
