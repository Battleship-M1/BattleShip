using Microsoft.VisualStudio.TestTools.UnitTesting;
using BackEnd.Enums;

namespace BackEnd.Test
{
    [TestClass]
    public class MapTester
    {
        BoatFactory boatFactory = new BoatFactory();
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
            Assert.IsFalse(emptyMap.AreTilesAvailable(boat.TilesUsed));
        }

        [TestMethod]
        public void AreBoatTilesUsedAvailable_OnAvailableTiles_thenTrue()
        {
            Assert.IsTrue(map.AreTilesAvailable(boat.TilesUsed));
        }

        [TestMethod]
        public void AreBoatTilesUsedAvailable_OnUsedTiles_thenFalse()
        {
            GameManager gm = new GameManager();
            Map fullBoatMap = gm.SetTileState(map, State.IsBoat, map.Tiles);
            Assert.IsFalse(fullBoatMap.AreTilesAvailable(boat.TilesUsed));
        }
        #endregion AreBoatTilesUsedAvailable

        #region GetAmountOfTileInState
        [TestMethod]
        public void GetAmountOfTileInState_NoTileInState_Then0()
        {
            Assert.AreEqual(map.GetAmountOfTileInState(State.IsBoat), 0);
        }

        [TestMethod]
        public void GetAmountOfTileInState_AllTileInState_ThenMapSize()
        {
            Assert.AreEqual(map.GetAmountOfTileInState(State.IsEmpty), map.Tiles.Count);
        }

        [TestMethod]
        public void GetAmountOfTileInState_ThreeInState_Then3()
        {
            int RESULT_WANTED = 3;

            for(int i = 0; i < RESULT_WANTED; i++)
            {
                map.Tiles[i].State = State.IsBoat;
            }
            Assert.AreEqual(map.GetAmountOfTileInState(State.IsBoat), RESULT_WANTED);
        }
        #endregion GetAmountOfTileInState

        #region PlaceBoatOnMap()
        [TestMethod]
        public void PlaceBoatOnMap_OnFreeTiles_ThenTrue()
        {
            Map m = new Map(8);
            Boat b = boatFactory.Test();
            Assert.IsTrue(m.PlaceBoatOnMap(b));
        }
        [TestMethod]
        public void PlaceBoatOnMap_OnUsedTiles_ThenFalse()
        {
            Map m = new Map(8);
            Boat b = boatFactory.Test();
            m.PlaceBoatOnMap(b);
            Assert.IsFalse(m.PlaceBoatOnMap(b));
        }
        #endregion PlaceBoatOnMap()
    }
}
