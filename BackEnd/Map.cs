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
                    t = new Tile(x,y);
                    tilesGenerated.Add(t);
                }
            }
            return tilesGenerated;
        }

        public Map(int size)
        {
            Size = size;
            Tiles = GenerateMap();
            ShowMap();
        }

        public void ShowMap()
        {
            Console.WriteLine("Showing Map :\n");
            for(int width = 0; width < Size; width++)
            {
                for(int height = 0; height < Size; height++)
                {
                    Tile t = Tiles[width * Size + height];
                    Console.Write($"{t.X};{t.Y}|");
                }
                Console.WriteLine();
            }
            Console.WriteLine("\nMap Showed\n");
        }
    }
}
