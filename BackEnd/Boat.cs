using BackEnd.Enum;
using System;
using System.Collections.Generic;

namespace BackEnd
{
    public class Boat
    {
        public int Length { get; set; }
        public Alignement Alignement { get; set; }
        public List<Tile> TilesUsed { get; set; }
        public Tile topLeft { get; set; }
        public string Name { get; set; }





        #region Constructors
        public Boat(int length, Tile topleft)
        {
            Length = length;
            topLeft = topleft;
            Alignement = Alignement.HORIZONTAL;
            Name = AffectName();
            TilesUsed = GenerateTilesUsed(topleft, length,Alignement);
        }
        #endregion Constructors





        /// <summary>
        /// Applied default name for a boat : long<Length>.
        /// </summary>
        /// <returns>String with name.</returns>
        #region + AffectName() : string
        public string AffectName()
        {
            return new string("long"+Length);
        }
        #endregion + AffectName() : string

        /// <summary>
        /// Check if the boat placement is ok or not.
        /// </summary>
        /// <param name="m">Map to place the boat.</param>
        /// <param name="topLeft">TopLeft tile of the boat.</param>
        /// <param name="length">Length of the boat.</param>
        /// <param name="alignement">Alignement of the boat.</param>
        /// <returns>TRUE if placement OK, else returns FALSE.</returns>
        #region + IsOnMap(Map, Tile, int, Alignement) : boolean
        public bool IsOnMap(Map m, Tile topLeft, int length, Alignement alignement)
        {
            if (m.Size < 1) { return false; }
            if(length < 1) { return false; }
            if(!(topLeft.IsOnMap(m))){ return false; }
            if(alignement == Alignement.VERTICAL)
            {
                topLeft.Y += length;
            }
            else
            {
                topLeft.X += length;
            }
            if(!(topLeft.IsOnMap(m))){ return false; }
            this.topLeft = topLeft;
            return true;
        }
        #endregion + IsOnMap(Map, Tile, int, Alignement) : boolean
        #region + IsOnMap(Map) : boolean
        public bool IsOnMap(Map m)
        {
            return this.IsOnMap(m, this.topLeft, this.Length, this.Alignement);
        }
        #endregion + IsOnMap(Map) : boolean


        /// <summary>
        /// Get a list of tile used by the boat.
        /// </summary>
        /// <param name="topLeft">Top left tile of the boat.</param>
        /// <param name="length">Length of the boat.</param>
        /// <param name="alignement">Alignement of the boat.</param>
        /// <returns>Returns a LIST of TILE. If the boat is not Ok, the list is NULL.</returns>
        #region + GenerateTilesUsed(Tile, int, Alignement) : List<Tile>
        public List<Tile> GenerateTilesUsed(Tile topLeft, int length, Alignement alignement)
        {
            List<Tile> tilesUsed = null;
            if(length < 1)
            {
                return tilesUsed;
            }
            tilesUsed = new List<Tile>();
            tilesUsed.Add(topLeft);
            for(int i = 1; i < length; i++)
            {
                if(alignement == Alignement.VERTICAL)
                {
                    Tile t = new Tile(topLeft.X, topLeft.Y + i);
                    t.State = State.IsBoat;
                    Console.WriteLine("VERTICAL : "+t.X+" "+t.Y);
                    tilesUsed.Add(t);
                }
                else
                {
                    Tile t = new Tile(topLeft.X + i, topLeft.Y);
                    t.State = State.IsBoat;
                    Console.WriteLine("HORIZONTHAL : "+t.X + " " + t.Y);
                    tilesUsed.Add(t);
                }
            }
            this.topLeft = topLeft;
            return tilesUsed;
        }
        #endregion + GenerateTilesUsed(Tile, int, Alignement, Map) : List<Tile>
        #region + GenerateTilesUsed(Map)
        public List<Tile> GenerateTilesUsed()
        {
            return GenerateTilesUsed(topLeft, Length, Alignement);
        }
        #endregion + GenerateTilesUsed(Map)

    }
}
