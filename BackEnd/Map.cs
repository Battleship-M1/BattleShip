using BackEnd.Enum;
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
        public int BoatPlaced { get; set; }





        #region Constructors
        public Map(int size)
        {
            Size = size;
            Tiles = GenerateMap();
            BoatPlaced = 0;
            ShowMap();
        }
        #endregion Constructors






        /// <summary>
        /// Create a list of Tile based on map's size².
        /// </summary>
        /// <returns>LIST of TILE.</returns>
        #region + GenerateMap() : List<Tile>
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
        #endregion + GenerateMap() : List<Tile>


        /// <summary>
        /// Show the map in console.
        /// </summary>
        #region + ShowMap() : void
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
        #endregion + ShowMap() : void

        public bool PlaceBoatOnMap(Boat boat)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Verify if boat tiles used are empty.
        /// </summary>
        /// <param name="boat">Boat's tiles to verify.</param>
        /// <returns>TRUE if all tiles are empty, ELSE return FALSE.</returns>
        #region + AreBoatTilesUsedAvailable(Boat) : boolean
        public bool AreBoatTilesUsedAvailable(Boat boat)
        {
            foreach(Tile boatTile in boat.TilesUsed)
            {
                if(!(boatTile.IsOnMap(this))) { return false; }
                foreach(Tile mapTile in this.Tiles)
                {
                    if(boatTile.X == mapTile.X && boatTile.Y == mapTile.Y)
                    {
                        if (!(mapTile.State == State.IsEmpty))
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }
        #endregion + AreBoatTilesUsedAvailable(Boat) : boolean

        /// <summary>
        /// Returns the amount of tile in a specific state.
        /// </summary>
        /// <param name="wantedState">The specific state.</param>
        /// <returns>The amount of tile.</returns>
        #region + GetAmountOfTileInState(State) : int
        public int GetAmountOfTileInState(State wantedState)
        {
            int amount = 0;

            foreach (Tile t in this.Tiles)
            {
                amount = t.State == wantedState ? amount + 1 : amount;
            }

            return amount;
        }
        #endregion + GetAmountOfTileInState(State) : int
    }
}
