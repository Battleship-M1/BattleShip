using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public class Boat
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public Tile TopLeft { get; set; }
        public int Length { get; set; }
        public Player Owner { get; set; }
        public Map map { get; set; }
        public Alignement Alignement { get; set; }
        public List<Tile> BoatTiles { get; set; }
        private List<string> errorList;

        public Boat() { 
            errorList = new List<string>();
        }
        // Factory public Boat(int,int) { }

        public Boolean IsPlaced()
        {
            throw new NotImplementedException();
        }

        public Boolean Verify() {
            return verifyBoatTiles() && verifyId() && verifyLength() && verifyName() && verifyPlayer() && verifyTopLeft();
        }

        private Boolean verifyBoatTiles() {
            if(BoatTiles == null) { return false; }
            return BoatTiles.Count == Length;
        }

        private Boolean verifyName()
        {
            if(Name == null)
            {
                return false;
            }
            return Name.Length > 0;
        }

        private Boolean verifyTopLeft()
        {
            if(TopLeft == null) { return false; }
            return TopLeft.Verify();
        }

        private Boolean verifyLength()
        {
            return Length > 0 && Length <= 5;
        }

        private Boolean verifyId()
        {
            return Id > 0;
        }

        private Boolean verifyPlayer()
        {
            return Owner.Verify();
        }
    }
}
