using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BackEnd.Test
{
    [TestClass]
    public class BoatTester
    {
        Boat b = new Boat(0);
        Map blankMap = new Map(0);
        Map okMap = new Map(8);
        int okLength = 2;
        int failLength = -1;
        Tile okTile = new Tile(1, 1);
        Tile failTile = new Tile(-5, 0);

        [TestMethod]
        public void Boat_IsOnMap_WithBlankGrid_ThenFalse()
        {
            Assert.IsFalse(b.IsOnMap(blankMap, okTile, okLength, Enum.Alignement.HORIZONTAL));
        }

        [TestMethod]
        public void Boat_IsOnMap_WithNOKTopLeft_ThenFalse()
        {
            Assert.IsFalse(b.IsOnMap(okMap, failTile, okLength, Enum.Alignement.HORIZONTAL));
        }

        [TestMethod]
        public void Boat_IsOnMap_WithNegativeLength_ThenFalse()
        {
            Assert.IsFalse(b.IsOnMap(okMap, okTile, failLength, Enum.Alignement.HORIZONTAL));
        }

        [TestMethod]
        public void Boat_IsOnMap_WithPositiveLengthAndOKTopLeft_ThenTrue()
        {
            Assert.IsTrue(b.IsOnMap(okMap, okTile, okLength, Enum.Alignement.HORIZONTAL));
        }

        [TestMethod]
        public void Boat_GenerateTilesUsed_WithNegativeOrZeroLength_ThenNull()
        {
            Assert.IsNull(b.GenerateTilesUsed(okTile, -1, Enum.Alignement.HORIZONTAL, okMap));
        }

        [TestMethod]
        public void Boat_GenerateTilesUsed_WithNOKTopLeft_ThenNull()
        {
            Assert.IsNull(b.GenerateTilesUsed(failTile, 2, Enum.Alignement.HORIZONTAL, okMap));
        }

        [TestMethod]
        public void Boat_GenerateTilesUsed_WithOKTopLeft3Length_ThenListCount3()
        {
            Assert.AreEqual(3, b.GenerateTilesUsed(okTile, 3, Enum.Alignement.HORIZONTAL, okMap).Count);
        }

        [TestMethod]
        public void Boat_GenerateTilesUsed_CheckResult()
        {
            Assert.AreEqual(new Tile(3, 4).X, b.GenerateTilesUsed(new Tile(3, 4), 3, Enum.Alignement.HORIZONTAL, okMap)[0].X);
            Assert.AreEqual(new Tile(3, 4).Y, b.GenerateTilesUsed(new Tile(3, 4), 3, Enum.Alignement.HORIZONTAL, okMap)[0].Y);

            Assert.AreEqual(new Tile(4, 4).X, b.GenerateTilesUsed(new Tile(3, 4), 3, Enum.Alignement.HORIZONTAL, okMap)[0].X);
            Assert.AreEqual(new Tile(4, 4).Y, b.GenerateTilesUsed(new Tile(3, 4), 3, Enum.Alignement.HORIZONTAL, okMap)[0].Y);

            Assert.AreEqual(new Tile(5, 4).X, b.GenerateTilesUsed(new Tile(3, 4), 3, Enum.Alignement.HORIZONTAL, okMap)[0].X);
            Assert.AreEqual(new Tile(5, 4).Y, b.GenerateTilesUsed(new Tile(3, 4), 3, Enum.Alignement.HORIZONTAL, okMap)[0].Y);
        }

        [TestMethod]
        public void Boat_AffectName_CheckResult()
        {
            b.Length = 2;
            Assert.AreEqual("long2", b.AffectName());
        }
    }
}
