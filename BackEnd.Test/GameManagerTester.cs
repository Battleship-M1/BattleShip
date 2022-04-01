using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace BackEnd.Test
{
    [TestClass]
    public class GameManagerTester
    {
        GameManager gm = new GameManager();
        Map testMap8 = new Map(8);

        #region GenerateDefaultBoats
        [TestMethod]
        public void GenerateDefaultBoats_LengthIs6()
        {
            Assert.AreEqual(6, gm.GenerateDefaultBoats().Count);
        }

        [TestMethod]
        public void GenerateDefaultBoats_OneIsLength2()
        {
            int length2amount = 0;
            foreach(Boat b in gm.GenerateDefaultBoats())
            {
                if(b.Length == 2) { length2amount++; }
            }
            Assert.AreEqual(1, length2amount);
        }

        [TestMethod]
        public void GenerateDefaultBoats_TwoIsLength3()
        {
            int length3amount = 0;
            foreach (Boat b in gm.GenerateDefaultBoats())
            {
                if(b.Length == 3) { length3amount++; }
            }
            Assert.AreEqual(2, length3amount);
        }

        [TestMethod]
        public void GenerateDefaultBoats_TwoIsLength4()
        {
            int length4amount = 0;
            foreach (Boat b in gm.GenerateDefaultBoats())
            {
                if(b.Length == 4) { length4amount++; }
            }
            Assert.AreEqual(2, length4amount);
        }

        [TestMethod]
        public void GenerateDefaultBoats_OneIsLength5()
        {
            int length5amount = 0;
            foreach (Boat b in gm.GenerateDefaultBoats())
            {
                if(b.Length == 5){ length5amount++; }
            }
            Assert.AreEqual(1, length5amount);
        }
        #endregion GenerateDefaultBoats

        #region MoveBoat
        [TestMethod]
        public void MoveBoat_TopLeftOutsideMap_ThenFalse()
        {
            Boat b = new Boat(2, new Tile(1, 0));
            Assert.IsFalse(gm.MoveBoat(ref b, testMap8, Enum.Direction.TOP));
        }

        [TestMethod]
        public void MoveBoat_TopLeftInsideMap_ThenTrue()
        {
            Boat b = new Boat(2, new Tile(1, 1));
            Assert.IsTrue(gm.MoveBoat(ref b, testMap8, Enum.Direction.TOP));
        }

        [TestMethod]
        public void MoveBoat_DirectionTOP_Ydecrease_CheckResult()
        {
            Boat b = new Boat(2, new Tile(1, 1));
            gm.MoveBoat(ref b, testMap8, Enum.Direction.TOP);
            Assert.AreEqual(0, b.topLeft.Y);
            Assert.AreEqual(1, b.topLeft.X);
        }

        [TestMethod]
        public void MoveBoat_DirectionBOT_Yincrease_CheckResult()
        {
            Boat b = new Boat(2, new Tile(1, 1));
            gm.MoveBoat(ref b, testMap8, Enum.Direction.BOTTOM);
            Assert.AreEqual(2, b.topLeft.Y);
            Assert.AreEqual(1, b.topLeft.X);
        }

        [TestMethod]
        public void MoveBoat_DirectionLEFT_Xdecrease_CheckResult()
        {
            Boat b = new Boat(2, new Tile(1, 1));
            gm.MoveBoat(ref b, testMap8, Enum.Direction.LEFT);
            Assert.AreEqual(1, b.topLeft.Y);
            Assert.AreEqual(0, b.topLeft.X);
        }

        [TestMethod]
        public void MoveBoat_DirectionRIGHT_Xincrease_CheckResult()
        {
            Boat b = new Boat(2, new Tile(1, 1));
            gm.MoveBoat(ref b, testMap8, Enum.Direction.RIGHT);
            Assert.AreEqual(1, b.topLeft.Y);
            Assert.AreEqual(2, b.topLeft.X);
        }
        #endregion MoveBoat

        #region GetNewTileWithDirection
        [TestMethod]
        public void GetNewTileWithDirection_NullTile_ThenNull()
        {
            Tile t = null;
            Assert.IsNull(gm.GetNewTileWithDirection(t, Enum.Direction.TOP));
        }

        [TestMethod]
        public void GetNewTileWithDirection_DirTOP_ThenYDecrease()
        {
            Tile tileToSend = new Tile(3, 3);
            Assert.AreEqual(gm.GetNewTileWithDirection(tileToSend, Enum.Direction.TOP).Y, 2);
        }

        [TestMethod]
        public void GetNewTileWithDirection_DirBOT_ThenYIncrease()
        {
            Tile tileToSend = new Tile(3, 3);
            Assert.AreEqual(gm.GetNewTileWithDirection(tileToSend, Enum.Direction.BOTTOM).Y, 4);
        }
        [TestMethod]
        public void GetNewTileWithDirection_DirLEFT_ThenXDecrease()
        {
            Tile tileToSend = new Tile(3, 3);
            Assert.AreEqual(gm.GetNewTileWithDirection(tileToSend, Enum.Direction.LEFT).X, 2);
        }

        [TestMethod]
        public void GetNewTileWithDirection_DirRIGTH_ThenXIncrease()
        {
            Tile tileToSend = new Tile(3, 3);
            Assert.AreEqual(gm.GetNewTileWithDirection(tileToSend, Enum.Direction.RIGHT).X, 4);
        }
        #endregion GetNewTileWithDirection
    }
}
