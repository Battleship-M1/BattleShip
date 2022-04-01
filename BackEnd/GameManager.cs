using BackEnd.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd
{
    public class GameManager
    {
        public List<Player> PlayerList { get; set; }
        public Game Game { get; set; }
        public List<Map> Maps { get; set; }
        public List<Boat> BoatList {  get; set; }
        public bool IsMultiplayer { get; set; }
        public IA IA { get; set; }


        /// <summary>
        /// Generate a list of boat.
        /// </summary>
        /// <returns>Get a list of boat with length : 2,3,3,4,4,5.</returns>
        #region + GenerateDefaultBoats() : List<Boat>
        public List<Boat> GenerateDefaultBoats()
        {
            List<Boat> boats = new List<Boat>();
            boats.Add(new Boat(2, new Tile(1, 1)));
            boats.Add(new Boat(3, new Tile(1, 1)));
            boats.Add(new Boat(3, new Tile(1, 1)));
            boats.Add(new Boat(4, new Tile(1, 1)));
            boats.Add(new Boat(4, new Tile(1, 1)));
            boats.Add(new Boat(5, new Tile(1, 1)));
            return boats;
        }
        #endregion + GenerateDefaultBoats() : List<Boat>

        /// <summary>
        /// Change boat position and renew boat's tiles used.
        /// </summary>
        /// <param name="boat">Boat to move.</param>
        /// <param name="m">Map where boat is.</param>
        /// <param name="dir">Direction of the movement.</param>
        /// <returns>TRUE if boat is moved, else FALSE.</returns>
        #region + MoveBoat(Boat, Map, Direction) : boolean
        public bool MoveBoat(ref Boat boat, Map m, Direction dir)
        {
            Tile topleft = boat.topLeft;
            Tile newTopLeft = GetNewTileWithDirection(topleft, dir);

            #region Verifications
            if (newTopLeft == null || !newTopLeft.IsOnMap(m))
            {
                return false;
            }
            #endregion Verifications

            List<Tile> newTilesUsed = boat.GenerateTilesUsed(newTopLeft, boat.Length, boat.Alignement);

            #region Verifications
            foreach (Tile tile in newTilesUsed)
            {
                if (!(tile.IsOnMap(m)))
                {
                    return false;
                }
            }
            #endregion Verifications

            boat.topLeft = newTopLeft;
            boat.TilesUsed = newTilesUsed;
            return true;
        }
        #endregion + MoveBoat(Boat, Map, Direction) : boolean

        /// <summary>
        /// Get tile with new X & Y.
        /// </summary>
        /// <param name="tile">Tile to move.</param>
        /// <param name="dir">Direction where to move.</param>
        /// <returns>NULL if tile given is NOT OK.</returns>
        #region + GetNewTileWithDirection(Tile, Direction) : Tile
        public Tile GetNewTileWithDirection(Tile tile, Direction dir)
        {
            Tile newTile = null;

            #region Verifications
            if (!(tile == null))
            {
                newTile = tile;
            }
            else
            {
                return newTile;
            }
            #endregion Verifications

            switch (dir)
            {
                case Direction.TOP:
                    newTile.Y -= 1;
                    break;
                case Direction.RIGHT:
                    newTile.X += 1;
                    break;
                case Direction.BOTTOM:
                    newTile.Y += 1;
                    break;
                case Direction.LEFT:
                    newTile.X -= 1;
                    break;
            }
            return newTile;
        }
        #endregion + GetNewTileWithDirection(Tile, Direction) : Tile

        public Map SetTileState(Map m,State stateWanted, List<Tile> tileToBeEmpty)
        {
            Map newMap = m;

            foreach(Tile tileToEmpty in tileToBeEmpty)
            {
                foreach(Tile tileInMap in m.Tiles)
                {
                    if(tileInMap.X == tileToEmpty.X && tileInMap.Y == tileToEmpty.Y)
                    {
                        int index = m.Tiles.IndexOf(tileInMap);
                        newMap.Tiles[index].State = stateWanted;
                    }
                }
            }

            return newMap;
        }
    }
}
