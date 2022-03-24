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
    }
}
