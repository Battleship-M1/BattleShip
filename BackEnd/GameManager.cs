using BackEnd.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd
{
    public class GameManager
    {

        #region Properties
        public List<Player> PlayerList { get; set; }
        public Game Game { get; set; }
        public List<Map> Maps { get; set; }
        public List<Boat> BoatList {  get; set; }
        public bool IsMultiplayer { get; set; }
        public IA IA { get; set; }
        private Boat PreBoat = new Boat();
        #endregion Properties

        //----------------------------------------------------------------------------------//

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
        public bool MoveBoat(ref Boat boat, ref Map m, Direction dir)
        {
            Boat saveBoat = boat;
            Tile newTopLeft = GetNewTileWithDirection(boat.topLeft, dir);
            boat.topLeft = newTopLeft;

            #region Verifications
            if (!(boat.topLeft.IsOnMap(m)))
            {
                boat = saveBoat;
                return false;
            }
            #endregion Verifications

            SetTileState(m, State.IsEmpty, boat.TilesUsed);
            SetTileState(m, State.IsEmpty, boat.NearBoatTiles);
            boat.topLeft = newTopLeft;
            boat.TilesUsed = boat.GenerateTilesUsed();
            boat.NearBoatTiles = boat.GenerateNearBoatTiles();

            #region Verifications
            if (!(m.AreTilesAvailable(boat.TilesUsed)))
            {
                boat = saveBoat;
                return false;
            }
            foreach (Tile tile in boat.TilesUsed)
            {
                if (!(tile.IsOnMap(m)))
                {
                    boat = saveBoat;
                    return false;
                }
            }
            foreach (Tile tile in boat.NearBoatTiles)
            {
                if (!(tile.IsOnMap(m)))
                {
                    boat = saveBoat;
                    return false;
                }
            }
            #endregion Verifications

            m.PlaceBoatOnMap(boat);

            return true;
        }
        #endregion + MoveBoat(Boat, Map, Direction) : boolean
        #region + MoveBoat(Boat, Map, Tile) : boolean
        public bool MoveBoat(ref Boat boat, ref Map m, Tile newTopLeft)
        {
            Boat saveBoat = boat;
            boat.topLeft = newTopLeft;

            #region Verifications
            if (newTopLeft == null || !newTopLeft.IsOnMap(m))
            {
                boat = saveBoat;
                return false;
            }
            #endregion Verifications

            SetTileState(m, State.IsEmpty, boat.TilesUsed);
            SetTileState(m, State.IsEmpty, boat.NearBoatTiles);
            boat.topLeft = newTopLeft;
            boat.TilesUsed = boat.GenerateTilesUsed();
            boat.NearBoatTiles = boat.GenerateNearBoatTiles();

            #region Verifications
            if (!(m.AreTilesAvailable(boat.TilesUsed)))
            {
                boat = saveBoat;
                return false;
            }
            foreach (Tile tile in boat.TilesUsed)
            {
                if (!(tile.IsOnMap(m)))
                {
                    boat = saveBoat;
                    return false;
                }
            }
            foreach (Tile tile in boat.NearBoatTiles)
            {
                if (!(tile.IsOnMap(m)))
                {
                    boat = saveBoat;
                    return false;
                }
            }
            #endregion Verifications

            m.PlaceBoatOnMap(boat);

            return true;
        }
        #endregion + MoveBoat(Boat, Map, Tile) : boolean

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
                case Direction.TOP_LEFT:
                    newTile.X -= 1;
                    newTile.Y -= 1;
                    break;
                case Direction.TOP_RIGHT:
                    newTile.X += 1;
                    newTile.Y -= 1;
                    break;
                case Direction.BOTTOM_LEFT:
                    newTile.X -= 1;
                    newTile.Y += 1;
                    break;
                case Direction.BOTTOM_RIGHT:
                    newTile.X += 1;
                    newTile.Y -= 1;
                    break;
            }

            return newTile;
        }
        #endregion + GetNewTileWithDirection(Tile, Direction) : Tile

        /// <summary>
        /// DEBUG ONLY, Change tile's state of tile list and returns a map.
        /// </summary>
        /// <param name="m">Map to work with.</param>
        /// <param name="stateWanted">State to place.</param>
        /// <param name="tileToBeEmpty">Tiles affected by the state to place.</param>
        /// <returns>New map with updated tiles state.</returns>
        #region + SetTileState(Map,State,List<Tile>) : Map
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
        #endregion + SetTileState(Map,State,List<Tile>) : Map

        /// <summary>
        /// Get the index of the tile in a list based on X and Y of wanted tile.
        /// </summary>
        /// <param name="X">X of wanted tile.</param>
        /// <param name="Y">Y of wanted tile.</param>
        /// <param name="tiles">The list of tile where we look for tile.</param>
        /// <returns>INDEX in the list, ELSE -1.</returns>
        #region STATIC + GetTileIndex(int,int,List<Tile>) : int
        public static int GetTileIndex(int X, int Y, List<Tile> tiles)
        {
            foreach (Tile t in tiles)
            {
                if (X < 0 || Y < 0) { return -1; }
                if (t.X == X && t.Y == Y)
                {
                    return tiles.IndexOf(t);
                }
            }
            return -1;
        }
        #endregion STATIC + GetTileIndex(int,int,List<Tile>) : int

        public static Boolean HaveListSameContent(List<Tile> t1, List<Tile> t2)
        {
            foreach(Tile tile in t1)
            {
                if(GetTileIndex(tile.X, tile.Y, t2) == -1) { return false; }
            }
            return t1.Count == t2.Count;
        }

        public bool PreBoatLength(int length)
        {
            if (length <= 0) { return false; }
            PreBoat.Length = length;
            return true;
        }
    }
}
