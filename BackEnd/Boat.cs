using BackEnd.Enums;
using System;
using System.Collections.Generic;

namespace BackEnd
{
    public class Boat
    {
        #region Properties
        public int Length { get; set; }
        public Alignement Alignement { get; set; }
        public List<Tile> TilesUsed { get; set; }
        public List<Tile> NearBoatTiles { get; set; }
        public Tile topLeft { get; set; }
        public string Name { get; set; }
        public List<Boat> BoatStates { get; set; } = new List<Boat>();
        private Boat WorkingBoat { get; set; }
        private Tile ErrorTile = Tile.ErrorTile();
        #endregion Properties

        //----------------------------------------------------------------------------------//

        #region Constructors
        public Boat(int length, Tile topleft)
        {
            Length = length;
            topLeft = topleft;
            Alignement = Alignement.HORIZONTAL;
            Name = AffectName();
            TilesUsed = GenerateTilesUsed(topleft, length,Alignement);
            NearBoatTiles = GenerateNearBoatTiles(this);
            WorkingBoat = new Boat();
        }
        public Boat() { }
        #endregion Constructors

        //----------------------------------------------------------------------------------//

        // + public

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
        #region + GenerateTilesUsed()
        public List<Tile> GenerateTilesUsed()
        {
            return GenerateTilesUsed(topLeft, Length, Alignement);
        }
        #endregion + GenerateTilesUsed()

        /// <summary>
        /// Get a list of tile near tile used by the boat.
        /// </summary>
        /// <returns>Returns a LIST of TILE. If the boat is not Ok, the list is EMPTY</returns>
        #region + GenerateNearBoatTiles() ; List<Tile>
        public List<Tile> GenerateNearBoatTiles(Boat b = null)
        {
            Boat functionBoat = b;
            if(b == null) { b = this; }
            List<Tile> tiles = new List<Tile>();

            if(b.TilesUsed == null)
            {
                return tiles;
            }

            foreach(Tile t in b.TilesUsed)
            {
                foreach(Tile tilesNear in t.GetNearTiles())
                {
                    if (GameManager.GetTileIndex(tilesNear.X, tilesNear.Y, tiles) == -1 && (GameManager.GetTileIndex(tilesNear.X, tilesNear.Y, TilesUsed) == -1))
                    {
                        tilesNear.State = State.IsNearBoat;
                        tiles.Add(tilesNear);
                    }
                }
            }
            return tiles;
        }
        #endregion + GenerateNearBoatTiles() ; List<Tile>

        /// <summary>
        /// Change properties and update linked properties.
        /// </summary>
        /// <param name="newLength">New length.</param>
        /// <returns>TRUE if success.</returns>
        #region + UpdateBoatProp(int) : Boolean
        public Boolean UpdateBoatProp(int newLength)
        {
            Clone(this, WorkingBoat);
            WorkingBoat.Length = newLength;
            if (newLength <= -1) { WorkingBoat.Length = this.Length; }
            if ((TryUpdateTileUsed() && TryUpdateNearBoatTiles()))
            {
                BoatStates.Add(Clone(this, new Boat()));
                Clone(WorkingBoat, this);
                WorkingBoat = new Boat();
                return true;
            }
            WorkingBoat = new Boat();
            return false;
        }
        #endregion + UpdateBoatProp(int) : Boolean
        #region + UpdateBoatProp(Alignement) : Boolean
        public Boolean UpdateBoatProp(Alignement newAlignement)
        {
            Clone(this, WorkingBoat);
            WorkingBoat.Alignement = newAlignement;
            if (newAlignement == Alignement.NONE) { WorkingBoat.Alignement = this.Alignement; }
            if ((TryUpdateTileUsed() && TryUpdateNearBoatTiles()))
            {
                BoatStates.Add(this);
                Clone(WorkingBoat, this);
                WorkingBoat = new Boat();
                return true;
            }
            WorkingBoat = new Boat();
            return false;
        }
        #endregion + UpdateBoatProp(Alignement) : Boolean
        #region + UpdateBoatProp(Tile) : Boolean
        public Boolean UpdateBoatProp(Tile newTopLeft)
        {
            Clone(this, WorkingBoat);
            WorkingBoat.topLeft = newTopLeft;
            if (newTopLeft == null || newTopLeft.X <=-1 || newTopLeft.Y <= -1) { WorkingBoat.topLeft = this.topLeft; }
            if ((TryUpdateTileUsed() && TryUpdateNearBoatTiles()))
            {
                BoatStates.Add(this);
                Clone(WorkingBoat, this);
                WorkingBoat = new Boat();
                return true;
            }
            WorkingBoat = new Boat();
            return false;
        }
        #endregion + UpdateBoatProp(Tile) : Boolean

        /// <summary>
        /// Apply the last correct state on the current boat. 
        /// </summary>
        /// <returns>TRUE if success.</returns>
        #region + ApplyLastState() : Boolean
        public Boolean ApplyLastState()
        {
            try
            {
                Clone(BoatStates[BoatStates.Count - 1], this);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        #endregion + ApplyLastState() : Boolean

        // - private

        /// <summary>
        /// Updates working boat tiles used.
        /// </summary>
        /// <returns>TRUE if success.</returns>
        #region - TryUpdateTileUsed() : Boolean
        private Boolean TryUpdateTileUsed(){
            List<Tile> workingTileUsed = new List<Tile>();
            workingTileUsed.Add(WorkingBoat.topLeft);

            Tile temp = WorkingBoat.topLeft;
            for(int i = 1; i < WorkingBoat.Length; i++)
            {
                if(WorkingBoat.Alignement == Alignement.VERTICAL)
                {
                    temp = temp.GetTileWithDirection(Direction.BOTTOM);
                    workingTileUsed.Add(temp);
                }
                if (WorkingBoat.Alignement == Alignement.HORIZONTAL)
                {
                    temp = temp.GetTileWithDirection(Direction.RIGHT);
                    workingTileUsed.Add(temp);
                }
            }
            WorkingBoat.TilesUsed = workingTileUsed;
            // return r same list dans game manager
            var res = GameManager.HaveListSameContent(WorkingBoat.TilesUsed, GenerateTilesUsed(WorkingBoat.topLeft, WorkingBoat.Length, WorkingBoat.Alignement));
            Console.WriteLine($"GenTileUsed : {res}");
            return res;
        }
        #endregion - TryUpdateTileUsed() : Boolean

        /// <summary>
        /// Updates working boat near tiles.
        /// </summary>
        /// <returns>TRUE if success.</returns>
        #region - TryUpdateNearBoatTiles() : Boolean
        private Boolean TryUpdateNearBoatTiles() {
            List<Tile> workingNearBoatTiles = new List<Tile>();
            foreach(Tile tileUse in WorkingBoat.TilesUsed)
            {
                foreach (Tile tilesNear in tileUse.GetNearTiles())
                {
                    if (GameManager.GetTileIndex(tilesNear.X, tilesNear.Y, workingNearBoatTiles) == -1 && (GameManager.GetTileIndex(tilesNear.X, tilesNear.Y, WorkingBoat.TilesUsed) == -1))
                    {
                            tilesNear.State = State.IsNearBoat;
                            workingNearBoatTiles.Add(tilesNear);
                    }
                }
            }
            WorkingBoat.NearBoatTiles = workingNearBoatTiles;
            return true;
        }
        #endregion - TryUpdateNearBoatTiles() : Boolean

        /// <summary>
        /// Clone boat so RAM reference is different.
        /// </summary>
        /// <returns>Boat cloned.</returns>
        #region - Clone() : Boat
        private Boat Clone(Boat from, Boat to)
        {
            foreach (var prop in from.GetType().GetProperties())
            {
                var val = prop.GetValue(from);
                prop.SetValue(to, val);
            }
            return to;
        }
        #endregion - Clone() : Boat

        //----------------------------------------------------------------------------------/

        // DEBUG ONLY

        /// <summary>
        /// Prints main information for debug.
        /// </summary>
        #region + Show() : void
        public void Show()
        {
            Console.WriteLine($"Length:{Length}, tilesUsed:{TilesUsed.Count},tilesNear:{NearBoatTiles.Count},State:{BoatStates.Count},TopLeft:{topLeft.Informations()}");
        }
        #endregion + Show() : void
    }
}
