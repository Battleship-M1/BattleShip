using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BackEnd.Test
{
    [TestClass]
    public class MapTester
    {
        Map map = new Map(8);
        Map emptyMap = new Map(0);
        Boat boat = new Boat(2, new Tile(3, 3));

        #region GenerateMap
        [TestMethod]
        public void Map_GenerateMap_WithSize8_ThenListCount64()
        {
            var listTile = map.GenerateMap();
            Assert.AreEqual(listTile.Count, 64);
        }

        [TestMethod]
        public void Map_GenerateMap_WithSize0_ThenListCount0()
        {
            map.Size = 0;
            var listTile = map.GenerateMap();
            Assert.AreEqual(listTile.Count, 0);
        }
        #endregion GenerateMap

        #region AreBoatTilesUsedAvailable
        [TestMethod]
        public void AreBoatTilesUsedAvailable_OnEmptyMap_ThenFalse()
        {
            Assert.IsFalse(emptyMap.AreBoatTilesUsedAvailable(boat));
        }

        [TestMethod]
        public void AreBoatTilesUsedAvailable_OnAvailableTiles_thenTrue()
        {
            Assert.IsTrue(map.AreBoatTilesUsedAvailable(boat));
        }

        [TestMethod]
        public void AreBoatTilesUsedAvailable_OnUsedTiles_thenFalse()
        {
            GameManager gm = new GameManager();
            Map fullBoatMap = gm.SetTileState(map, Enum.State.IsBoat, map.Tiles);
            Assert.IsFalse(fullBoatMap.AreBoatTilesUsedAvailable(boat));
        }
        #endregion AreBoatTilesUsedAvailable

        #region GetAmountOfTileInState
        [TestMethod]
        public void GetAmountOfTileInState_NoTileInState_Then0()
        {
            Assert.AreEqual(map.GetAmountOfTileInState(Enum.State.IsBoat), 0);
        }

        [TestMethod]
        public void GetAmountOfTileInState_AllTileInState_ThenMapSize()
        {
            Assert.AreEqual(map.GetAmountOfTileInState(Enum.State.IsEmpty), map.Tiles.Count);
        }

        [TestMethod]
        public void GetAmountOfTileInState_ThreeInState_Then3()
        {
            int RESULT_WANTED = 3;

            for(int i = 0; i < RESULT_WANTED; i++)
            {
                map.Tiles[i].State = Enum.State.IsBoat;
            }
            Assert.AreEqual(map.GetAmountOfTileInState(Enum.State.IsBoat), RESULT_WANTED);
        }
        #endregion GetAmountOfTileInState
    }
}
