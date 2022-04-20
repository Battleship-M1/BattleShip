using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd
{
    public class BoatFactory
    {
        public Boat Test()
        {
            Boat b = new Boat();
            b.Length = 2;
            b.topLeft = new Tile(2, 2);
            b.Alignement = Enums.Alignement.HORIZONTAL;
            b.NearBoatTiles = b.GenerateNearBoatTiles();
            b.TilesUsed = b.GenerateTilesUsed();
            return b;
        }
    }
}
