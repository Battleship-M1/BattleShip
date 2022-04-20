using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public class Tile
    {
        public int X { get; set; }
        public int Y { get; set; }
        //public TileState State { get; set; }
        //public ShotState ShotState { get; set; }

        public Tile() { }
        // Factory public Tile(int,int){}

        public Boolean Verify()
        {
            throw new NotImplementedException();
        }

        private Boolean verifyX()
        {
            throw new NotImplementedException();
        }

        private Boolean verifyY()
        {
            throw new NotImplementedException();
        }
    }
}
