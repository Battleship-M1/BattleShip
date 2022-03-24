using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BackEnd.Test
{
    [TestClass]
    public class MapTester
    {
        Map map = new Map(8);

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
    }
}
