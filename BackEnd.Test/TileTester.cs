using Microsoft.VisualStudio.TestTools.UnitTesting;

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
    }
}
