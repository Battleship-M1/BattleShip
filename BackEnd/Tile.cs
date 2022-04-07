using BackEnd.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd
{
    public class Tile
    {

        #region Properties
        public int X { get; set; }
        public int Y { get; set; }
        public State State { get; set; }
        public bool HasBeenShoot { get; set; }
        #endregion Properties

        //----------------------------------------------------------------------------------//

        #region Constructors
        public Tile(int x, int y)
        {
            X = x;
            Y = y;
            State = State.IsEmpty;
        }
        #endregion Constructors

        //----------------------------------------------------------------------------------//

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

        public List<Tile> GetNearTiles()
        {
            List<Tile> nearTiles = new List<Tile>();

            foreach (Direction dir in (Direction[])Enum.GetValues(typeof(Direction)))
            {
                int x = GetXWithDirection(dir);
                int y = GetYWithDirection(dir);
                if (x >= 0 && y >= 0)
                {
                    nearTiles.Add(new Tile(x, y));
                }
            }

            return nearTiles;
        }

        public Tile GetTileWithDirection(Direction dir)
        {
            return new Tile(GetXWithDirection(dir), GetYWithDirection(dir));
        }

        public int GetXWithDirection(Direction dir)
        {
            switch (dir)
            {
                case Direction.RIGHT: case Direction.TOP_RIGHT: case Direction.BOTTOM_RIGHT:
                        return X + 1;
                case Direction.TOP: case Direction.BOTTOM:
                        return X;
            }
            return X - 1;
        }

        public int GetYWithDirection(Direction dir)
        {
            switch (dir)
            {
                case Direction.BOTTOM: case Direction.BOTTOM_RIGHT: case Direction.BOTTOM_LEFT:
                        return Y + 1;
                case Direction.LEFT: case Direction.RIGHT:
                        return Y;
            }
            return Y - 1;
        }

        public static Tile ErrorTile()
        {
            return new Tile(-1, -1);
        }
    }
}
