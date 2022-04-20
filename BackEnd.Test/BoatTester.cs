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
        BoatFactory factory = new BoatFactory();
        Map blankMap = new Map(0);
        Map okMap = new Map(8);
        int okLength = 2;
        int failLength = -1;
        Tile okTile = new Tile(1, 1);
        Tile failTile = new Tile(-5, 0);

        //----------------------------------------------------------------------------------//

        #region AffectName
        [TestMethod]
        public void Boat_AffectName_CheckResult()
        {
            Boat b = factory.Test();
            b.Length = 2;
            Assert.AreEqual("long2", b.AffectName());
        }
        #endregion AffectName

        #region IsOnMap
        [TestMethod]
        public void Boat_IsOnMap_WithBlankGrid_ThenFalse()
        {
            Boat b = factory.Test();
            Assert.IsFalse(b.IsOnMap(blankMap, okTile, okLength, Alignement.HORIZONTAL));
        }

        [TestMethod]
        public void Boat_IsOnMap_WithNOKTopLeft_ThenFalse()
        {
            Boat b = factory.Test();
            Assert.IsFalse(b.IsOnMap(okMap, failTile, okLength, Alignement.HORIZONTAL));
        }

        [TestMethod]
        public void Boat_IsOnMap_WithNegativeLength_ThenFalse()
        {
            Boat b = factory.Test();
            Assert.IsFalse(b.IsOnMap(okMap, okTile, failLength, Alignement.HORIZONTAL));
        }

        [TestMethod]
        public void Boat_IsOnMap_WithPositiveLengthAndOKTopLeft_ThenTrue()
        {
            Boat b = factory.Test();
            Assert.IsTrue(b.IsOnMap(okMap, okTile, okLength, Alignement.HORIZONTAL));
        }
        #endregion IsOnMap

        #region GenerateTilesUsed
        [TestMethod]
        public void Boat_GenerateTilesUsed_WithNegativeOrZeroLength_ThenNull()
        {
            Boat b = factory.Test();
            Assert.IsNull(b.GenerateTilesUsed(okTile, -1, Alignement.HORIZONTAL));
        }

        [TestMethod]
        public void Boat_GenerateTilesUsed_WithNOKTopLeft_ThenNull()
        {
            Boat b = factory.Test();
            Assert.IsNull(b.GenerateTilesUsed(failTile, 2, Alignement.HORIZONTAL));
        }

        [TestMethod]
        public void Boat_GenerateTilesUsed_WithOKTopLeft3Length_ThenListCount3()
        {
            Boat b = factory.Test();
            Assert.AreEqual(3, b.GenerateTilesUsed(okTile, 3, Alignement.HORIZONTAL).Count);
        }

        [TestMethod]
        public void Boat_GenerateTilesUsed_Horizontal_CheckResult()
        {
            Boat b = factory.Test();
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
            Boat b = factory.Test();
            Assert.AreEqual(3, b.GenerateTilesUsed(new Tile(3, 4), 3, Alignement.VERTICAL)[0].X);
            Assert.AreEqual(4, b.GenerateTilesUsed(new Tile(3, 4), 3, Alignement.VERTICAL)[0].Y);

            Assert.AreEqual(3, b.GenerateTilesUsed(new Tile(3, 4), 3, Alignement.VERTICAL)[1].X);
            Assert.AreEqual(5, b.GenerateTilesUsed(new Tile(3, 4), 3, Alignement.VERTICAL)[1].Y);

            Assert.AreEqual(3, b.GenerateTilesUsed(new Tile(3, 4), 3, Alignement.VERTICAL)[2].X);
            Assert.AreEqual(6, b.GenerateTilesUsed(new Tile(3, 4), 3, Alignement.VERTICAL)[2].Y);
        }
        #endregion GenerateTilesUsed
        
        #region GenerateNearBoatTiles
        [TestMethod]
        public void GenerateNearBoatTiles_IfTilesUsedNull_ThenEmptyList()
        {
            Boat b = factory.Test();
            b.TilesUsed = null;
            Assert.AreEqual(0, b.GenerateNearBoatTiles().Count);
        }

        [TestMethod]
        public void GenerateNearBoatTiles_IfTilesUsedEmpty_ThenEmptyList()
        {
            Boat b = factory.Test();
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

        #region ApplyLastChange()
        [TestMethod]
        public void ApplyLastChange_ThenTrue()
        {
            Boat boat = factory.Test();
            int originLength = boat.Length;
            boat.UpdateBoatProp(boat.Length + 1);
            Assert.AreEqual(boat.ApplyLastState(), true);
            Assert.AreEqual(originLength, boat.Length);
        }
        #endregion ApplyLastChange()

        //----------------------------------------------------------------------------------//

        #region Private Methods

        #region Clone
        [TestMethod]
        public void Clone_DifferentBoat_CheckResult()
        {
            Boat b = factory.Test();
            MethodInfo methodInfo = typeof(Boat).GetMethod("Clone", BindingFlags.NonPublic | BindingFlags.Instance);
            Boat cloned = new Boat(2, new Tile(2,6));
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
            Boat b = factory.Test();
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

        #region UpdateBoatProp()

        [TestMethod]
        public void UpdateBoatProp_IncreaseLength_ThenTrue()
        {
            Boat boat = factory.Test();
            Assert.IsTrue(boat.UpdateBoatProp(boat.Length++));
        }
        [TestMethod]
        public void UpdateBoatProp_DecreaseLength_ThenTrue()
        {
            Boat boat = factory.Test();
            Assert.IsTrue(boat.UpdateBoatProp(boat.Length--));
        }
        [TestMethod]
        public void UpdateBoatProp_SameLength_ThenTrue()
        {
            Boat boat = factory.Test();
            Assert.IsTrue(boat.UpdateBoatProp(boat.Length));
        }

        [TestMethod]
        public void UpdateBoatProp_NewLength_ThenTrueAndLengthModified()
        {
            Boat boat = factory.Test();
            int originLength = boat.Length;
            boat.Show();
            boat.UpdateBoatProp(originLength + 1);
            Assert.IsTrue(boat.UpdateBoatProp(originLength+1));
            Assert.AreNotEqual(originLength, boat.Length);
        }

        [TestMethod]
        public void UpdateBoatProp_IncorrectLength_ThenTrueAndLengthUnmodify()
        {
            Boat boat = factory.Test();
            int originLength = boat.Length;
            Assert.IsTrue(boat.UpdateBoatProp(-1));
            Assert.AreEqual(originLength, boat.Length);
        }

        [TestMethod]
        public void UpdateBoatProp_NewTopLeft_ThenTrueAndTopLeftModified()
        {
            Boat boat = factory.Test();
            Tile originTopLeft = boat.topLeft;
            boat.Show();
            Assert.IsTrue(boat.UpdateBoatProp(new Tile(originTopLeft.X, originTopLeft.Y + 1)));
            Assert.AreNotEqual(originTopLeft.Y, boat.topLeft.Y);
        }

        [TestMethod]
        public void UpdateBoatProp_IncorrectTopLeft_ThenTrueAndTopLeftUnmodified()
        {
            Boat boat = factory.Test();
            Tile originTopLeft = boat.topLeft;
            Assert.IsTrue(boat.UpdateBoatProp(new Tile(originTopLeft.X,-1)));
            Assert.AreEqual(originTopLeft.Y,boat.topLeft.Y);
        }

        [TestMethod]
        public void UpdateBoatProp_NewAlignement_ThenTrueAndAlignementModified()
        {
            Boat boat = factory.Test();
            boat.Alignement = Alignement.VERTICAL;
            Alignement originAli = boat.Alignement;
            Assert.IsTrue(boat.UpdateBoatProp(Alignement.HORIZONTAL));
            Assert.AreNotEqual(Alignement.HORIZONTAL, originAli);
        }

        [TestMethod]
        public void UpdateBoatProp_IncorrectAlignement_ThenTrueAndAlignementUnmodified()
        {
            Boat boat = factory.Test();
            boat.Alignement = Alignement.VERTICAL;
            Alignement originAli = boat.Alignement;
            Assert.IsTrue(boat.UpdateBoatProp(Alignement.NONE));
            Assert.AreEqual(originAli, Alignement.VERTICAL);
        }

        [TestMethod]
        public void UpdateBoatProp_OnChange_UpdateTilesList()
        {
            Boat boat = factory.Test();
            var originTilesUsed = boat.TilesUsed;
            var originNearTile = boat.NearBoatTiles;
            boat.UpdateBoatProp(boat.Length + 1);
            Assert.AreNotEqual(boat.TilesUsed.Count, originTilesUsed.Count);
            Assert.AreNotEqual(boat.NearBoatTiles.Count, originNearTile.Count);
        }
        #endregion UpdateBoatProp()

        #endregion Private Methods
    }
}
