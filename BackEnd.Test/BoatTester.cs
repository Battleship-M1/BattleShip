using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BackEnd.Test
{
    [TestClass]
    public class BoatTester
    {
        Boat b = new Boat();
        Map blankMap = new Map(0);
        Map okMap = new Map(8);
        int okLength = 2;
        int failLength = -1;
        Tile okTile = new Tile()
        {
            X = 1,
            Y = 1
        };
        Tile failTile = new Tile()
        {
            Y = -5,
            X = 0,
        };

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
            Assert.AreEqual(3, b.GenerateTilesUsed(okTile, 3, Enum.Alignement.HORIZONTAL));
        }
    }
}
