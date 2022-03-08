using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd
{
    public class Map
    {
        public int Size { get; set; }
        public List<Tile> Tiles { get; set; }

        public List<Tile> GenerateMap()
        {
            List<Tile> tilesGenerated = new List<Tile>();
            Tile t = null;
            for(int x = 0; x < Size; x++)
            {
                for (int y = 0; y < Size; y++)
                {
                    t = new Tile();
                    tilesGenerated.Add(t);
                }
            }
            return tilesGenerated;
        }
    }
}
