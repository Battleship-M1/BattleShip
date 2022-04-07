using BackEnd.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using BackEnd.Enums;
using System.Reflection;

namespace BackEnd.Test
{
    [TestClass]
    public class BoatTester
    {
        Boat b = new Boat(0, new Tile(1,1));
        Boat boat = new Boat(1, new Tile(2,2));
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
            Assert.IsFalse(b.IsOnMap(blankMap, okTile, okLength, Alignement.HORIZONTAL));
        }

        [TestMethod]
        public void Boat_IsOnMap_WithNOKTopLeft_ThenFalse()
        {
            Assert.IsFalse(b.IsOnMap(okMap, failTile, okLength, Alignement.HORIZONTAL));
        }

        [TestMethod]
        public void Boat_IsOnMap_WithNegativeLength_ThenFalse()
        {
            Assert.IsFalse(b.IsOnMap(okMap, okTile, failLength, Alignement.HORIZONTAL));
        }

        [TestMethod]
        public void Boat_IsOnMap_WithPositiveLengthAndOKTopLeft_ThenTrue()
        {
            Assert.IsTrue(b.IsOnMap(okMap, okTile, okLength, Alignement.HORIZONTAL));
        }
        #endregion IsOnMap

        #region GenerateTilesUsed
        [TestMethod]
        public void Boat_GenerateTilesUsed_WithNegativeOrZeroLength_ThenNull()
        {
            Assert.IsNull(b.GenerateTilesUsed(okTile, -1, Alignement.HORIZONTAL));
        }

        [TestMethod]
        public void Boat_GenerateTilesUsed_WithNOKTopLeft_ThenNull()
        {
            Assert.IsNull(b.GenerateTilesUsed(failTile, 2, Alignement.HORIZONTAL));
        }

        [TestMethod]
        public void Boat_GenerateTilesUsed_WithOKTopLeft3Length_ThenListCount3()
        {
            Assert.AreEqual(3, b.GenerateTilesUsed(okTile, 3, Alignement.HORIZONTAL).Count);
        }

        [TestMethod]
        public void Boat_GenerateTilesUsed_Horizontal_CheckResult()
        {
            Assert.AreEqual(3, b.GenerateTilesUsed(new Tile(3, 4), 3, Alignement.HORIZONTAL)[0].X);
            Assert.AreEqual(4, b.GenerateTilesUsed(new Tile(3, 4), 3, Alignement.HORIZONTAL)[0].Y);

            Assert.AreEqual(4, b.GenerateTilesUsed(new Tile(3, 4), 3, Alignement.HORIZONTAL)[1].X);
            Assert.AreEqual(4, b.GenerateTilesUsed(new Tile(3, 4), 3, Alignement.HORIZONTAL)[1].Y);

            Assert.AreEqual(5, b.GenerateTilesUsed(new Tile(3, 4), 3, Alignement.HORIZONTAL)[2].X);
            Assert.AreEqual(4, b.GenerateTilesUsed(new Tile(3, 4), 3, Alignement.HORIZONTAL)[2].Y);
        }

        [TestMethod]
        public void Boat_GenerateTilesUsed_Vertical_CheckResult()
        {
            Assert.AreEqual(3, b.GenerateTilesUsed(new Tile(3, 4), 3, Alignement.VERTICAL)[0].X);
            Assert.AreEqual(4, b.GenerateTilesUsed(new Tile(3, 4), 3, Alignement.VERTICAL)[0].Y);

            Assert.AreEqual(3, b.GenerateTilesUsed(new Tile(3, 4), 3, Alignement.VERTICAL)[1].X);
            Assert.AreEqual(5, b.GenerateTilesUsed(new Tile(3, 4), 3, Alignement.VERTICAL)[1].Y);

            Assert.AreEqual(3, b.GenerateTilesUsed(new Tile(3, 4), 3, Alignement.VERTICAL)[2].X);
            Assert.AreEqual(6, b.GenerateTilesUsed(new Tile(3, 4), 3, Alignement.VERTICAL)[2].Y);
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

        #region GenerateNearBoatTiles
        [TestMethod]
        public void GenerateNearBoatTiles_IfTilesUsedNull_ThenEmptyList()
        {
            b.TilesUsed = null;
            Assert.AreEqual(0, b.GenerateNearBoatTiles().Count);
        }

        [TestMethod]
        public void GenerateNearBoatTiles_IfTilesUsedEmpty_ThenEmptyList()
        {
            b.TilesUsed = new List<Tile>();
            Assert.AreEqual(0, b.GenerateNearBoatTiles().Count);
        }

        [TestMethod]
        public void GenerateNearBoatTiles_InMapCornerAndLength1_ThenListCount3()
        {
            Boat bo = new Boat(1, new Tile(0, 0));
            Assert.AreEqual(3, bo.GenerateNearBoatTiles().Count);
        }

        [TestMethod]
        public void GenerateNearBoatTiles_MiddleOfTheMapAndLength1_ThenListCount8()
        {
            Boat bo = new Boat(1, new Tile(3, 3));
            Assert.AreEqual(8, bo.GenerateNearBoatTiles().Count);
        }

        [TestMethod]
        public void GenerateNearBoatTiles_MiddleOfTheMapAndLength2_ThenListCount10()
        {
            Boat bo = new Boat(2, new Tile(3, 3));
            Assert.AreEqual(10, bo.GenerateNearBoatTiles().Count);
        }
        #endregion GenerateNearBoatTiles

        #region ChangeAlignement
        [TestMethod]
        public void ChangeAlignement_WithVertical_ThenHorizontal()
        {
            Assert.AreEqual(Alignement.HORIZONTAL, boat.ChangeAlignement(Alignement.HORIZONTAL, ref okMap).Alignement);
        }

        [TestMethod]
        public void ChangeAlignement_WithHorizontal_ThenVertical()
        {
            Assert.AreEqual(Alignement.VERTICAL, boat.ChangeAlignement(Alignement.VERTICAL, ref okMap).Alignement);
        }
        #endregion ChangeAlignement

        #region Private Methods

        #region Clone
        [TestMethod]
        public void Clone_DifferentBoat_CheckResult()
        {
            MethodInfo methodInfo = typeof(Boat).GetMethod("Clone", BindingFlags.NonPublic | BindingFlags.Instance);
            Boat cloned = null;
            object[] parameters = {b, cloned};
            cloned = (Boat)methodInfo.Invoke(b, parameters);
            foreach(var prop in b.GetType().GetProperties())
            {
                Assert.AreEqual(prop.GetValue(b), prop.GetValue(cloned));
            }
        }

        [TestMethod]
        public void Clone_SameBoat_CheckResult()
        {
            MethodInfo methodInfo = typeof(Boat).GetMethod("Clone", BindingFlags.NonPublic | BindingFlags.Instance);
            Boat cloned = null;
            object[] parameters = { b, b };
            cloned = (Boat)methodInfo.Invoke(b, parameters);
            foreach (var prop in b.GetType().GetProperties())
            {
                Assert.AreEqual(prop.GetValue(b), prop.GetValue(cloned));
            }
        }
        #endregion Clone

        // UpdateBoatProp(int)
        // UpdateBoatProp(Alignement)

        #endregion Private Methods
    }
}
