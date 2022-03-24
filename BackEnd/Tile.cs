using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd
{
    public class Tile
    {
        public int X { get; set; }
        public int Y { get; set; }

        public bool IsOnMap(Map m)
        {
            return X < m.Size && Y < m.Size; 
        }
        public Tile(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
