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

        public List<Boat> GenerateDefaultBoats()
        {
            List<Boat> boats = new List<Boat>();
            boats.Add(new Boat(2));
            boats.Add(new Boat(3));
            boats.Add(new Boat(3));
            boats.Add(new Boat(4));
            boats.Add(new Boat(4));
            boats.Add(new Boat(5));
            return boats;
        }
    }
}
