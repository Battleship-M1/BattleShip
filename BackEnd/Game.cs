using System;
using System.Collections.Generic;
using BackEnd.Enums;

namespace BackEnd
{
    public class Game
    {
        public Player Player1;
        public Player Player2;
        public Player ActivePlayer;
        public Turn PlayerTurn;
        public Map Player1Map;
        public Map Player2Map;
        public Map ActivePlayerMap;
        public List<Tile> Player1ShotsMade;
        public List<Tile> Player2ShotsMade;

        public Boolean Shoot()
        {
            throw new NotImplementedException();
        }

        private Boolean SaveShot(Tile tileShot)
        {
            throw new NotImplementedException();
        }

        public Boolean End()
        {
            throw new NotImplementedException();
        }

        public Boolean ChangeTurn()
        {
            throw new NotImplementedException();
        }
    }
}
