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
            return true;
        }

        public List<Tile> GenerateTilesUsed(Tile topLeft, int length, Alignement alignement)
        {
            throw new NotImplementedException();
        }
    }
}
