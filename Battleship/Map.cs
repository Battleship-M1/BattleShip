using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public class Map
    {
        public List<Tile> Tiles { get; set; }
        public List<Boat> Boats { get; set; }
        private List<Tile> nearTilesBoats;
        public int Width { get; set; }
        public int Height { get; set; }
        
        public Map()
        {
            nearTilesBoats = new List<Tile>();
            Boats = new List<Boat>();
            Tiles = new List<Tile>();
        }

        // Factory public Map(int,int){}

        public Boolean Verify()
        {
            throw new NotImplementedException();
        }

        private Boolean verifyWidth()
        {
            throw new NotImplementedException();
        }

        private Boolean verifyHeight()
        {
            throw new NotImplementedException();
        }

        private Boolean verifyTiles()
        {
            throw new NotImplementedException();
        }

        private Boolean verifyBoats()
        {
            throw new NotImplementedException();
        }

        private Boolean verifyNearBoatTiles()
        {
            throw new NotImplementedException();
        }

        public Boolean PlaceBoat(Boat boatToPlace)
        {
            throw new NotImplementedException();
        }

        public Boolean GenerateTiles()
        {
            throw new NotImplementedException();
        }
    }
}
