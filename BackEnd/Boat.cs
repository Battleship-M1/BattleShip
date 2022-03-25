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

        public Boat(int length)
        {
            Length = length;
        }

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

        public List<Tile> GenerateTilesUsed(Tile topLeft, int length, Alignement alignement, Map m)
        {
            List<Tile> tilesUsed = null;
            if (!(topLeft.IsOnMap(m)))
            {
                return tilesUsed;
            }
            if(length < 1)
            {
                return tilesUsed;
            }
            tilesUsed = new List<Tile>();
            tilesUsed.Add(topLeft);
            for(int i = 0; i < length; i++)
            {
                if(alignement == Alignement.VERTICAL)
                {
                    Tile t = new Tile(topLeft.X, topLeft.Y+(i+1));
                    tilesUsed.Add(t);
                }
                else
                {
                    Tile t = new Tile(topLeft.X + (i + 1), topLeft.Y);
                    tilesUsed.Add(t);
                }
            }
            return tilesUsed;
        }
    }
}
