using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace BackEnd.Test
{
    [TestClass]
    public class GameManagerTester
    {
        GameManager gm = new GameManager();

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
    }
}
