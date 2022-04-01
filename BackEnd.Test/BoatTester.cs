using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BackEnd.Test
{
    [TestClass]
    public class BoatTester
    {
        Boat b = new Boat(0, new Tile(1,1));
        Map blankMap = new Map(0);
        Map okMap = new Map(8);
        int okLength = 2;
        int failLength = -1;
        Tile okTile = new Tile(1, 1);
        Tile failTile = new Tile(-5, 0);

        #region IsOnMap
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
        #endregion IsOnMap

        #region GenerateTilesUsed
        [TestMethod]
        public void Boat_GenerateTilesUsed_WithNegativeOrZeroLength_ThenNull()
        {
            Assert.IsNull(b.GenerateTilesUsed(okTile, -1, Enum.Alignement.HORIZONTAL));
        }

        [TestMethod]
        public void Boat_GenerateTilesUsed_WithNOKTopLeft_ThenNull()
        {
            Assert.IsNull(b.GenerateTilesUsed(failTile, 2, Enum.Alignement.HORIZONTAL));
        }

        [TestMethod]
        public void Boat_GenerateTilesUsed_WithOKTopLeft3Length_ThenListCount3()
        {
            Assert.AreEqual(3, b.GenerateTilesUsed(okTile, 3, Enum.Alignement.HORIZONTAL).Count);
        }

        [TestMethod]
        public void Boat_GenerateTilesUsed_Horizontal_CheckResult()
        {
            Assert.AreEqual(3, b.GenerateTilesUsed(new Tile(3, 4), 3, Enum.Alignement.HORIZONTAL)[0].X);
            Assert.AreEqual(4, b.GenerateTilesUsed(new Tile(3, 4), 3, Enum.Alignement.HORIZONTAL)[0].Y);

            Assert.AreEqual(4, b.GenerateTilesUsed(new Tile(3, 4), 3, Enum.Alignement.HORIZONTAL)[1].X);
            Assert.AreEqual(4, b.GenerateTilesUsed(new Tile(3, 4), 3, Enum.Alignement.HORIZONTAL)[1].Y);

            Assert.AreEqual(5, b.GenerateTilesUsed(new Tile(3, 4), 3, Enum.Alignement.HORIZONTAL)[2].X);
            Assert.AreEqual(4, b.GenerateTilesUsed(new Tile(3, 4), 3, Enum.Alignement.HORIZONTAL)[2].Y);
        }

        [TestMethod]
        public void Boat_GenerateTilesUsed_Vertical_CheckResult()
        {
            Assert.AreEqual(3, b.GenerateTilesUsed(new Tile(3, 4), 3, Enum.Alignement.VERTICAL)[0].X);
            Assert.AreEqual(4, b.GenerateTilesUsed(new Tile(3, 4), 3, Enum.Alignement.VERTICAL)[0].Y);

            Assert.AreEqual(3, b.GenerateTilesUsed(new Tile(3, 4), 3, Enum.Alignement.VERTICAL)[1].X);
            Assert.AreEqual(5, b.GenerateTilesUsed(new Tile(3, 4), 3, Enum.Alignement.VERTICAL)[1].Y);

            Assert.AreEqual(3, b.GenerateTilesUsed(new Tile(3, 4), 3, Enum.Alignement.VERTICAL)[2].X);
            Assert.AreEqual(6, b.GenerateTilesUsed(new Tile(3, 4), 3, Enum.Alignement.VERTICAL)[2].Y);
        }
        #endregion GenerateTilesUsed

        #region AffectName
        [TestMethod]
        public void Boat_AffectName_CheckResult()
        {
            b.Length = 2;
            Assert.AreEqual("long2", b.AffectName());
        }
        #endregion AffectName
    }
}
