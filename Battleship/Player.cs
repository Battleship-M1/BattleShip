using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Map Map { get; set; }
        public List<Boat> Boats { get; set; }

        public Player()
        {
            Boats = new List<Boat>();
        }

        // Factory public Player(int,int){}

        public Boolean Verify()
        {
            throw new NotImplementedException();
        }

        private Boolean verifyId()
        {
            throw new NotImplementedException();
        }

        private Boolean verifyName()
        {
            throw new NotImplementedException();
        }

        private Boolean verifyMap()
        {
            throw new NotImplementedException();
        }

        private Boolean verifyBoats()
        {
            throw new NotImplementedException();
        }
    }
}
