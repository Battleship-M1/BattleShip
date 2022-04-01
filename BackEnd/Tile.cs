using BackEnd.Enum;
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
        public State State { get; set; }
        public bool HasBeenShoot { get; set; }




        #region Constructors
        public Tile(int x, int y)
        {
            X = x;
            Y = y;
            State = State.IsEmpty;
        }
        #endregion Constructors




        /// <summary>
        /// Verify if a Tile is on the map.
        /// </summary>
        /// <param name="m">Map to check with.</param>
        /// <returns>TRUE if on map, else FALSE.</returns>
        #region + IsOnMap(Map) : boolean
        public bool IsOnMap(Map m)
        {
            return X < m.Size && Y < m.Size && X >= 0 && Y >= 0; 
        }
        #endregion + IsOnMap(Map) : boolean

    }
}
