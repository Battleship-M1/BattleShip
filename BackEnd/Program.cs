using System;

namespace BackEnd
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Boat bo = new Boat(1, new Tile(2, 2));
            bo.Show();
            if (bo.UpdateBoatProp(bo.Length+1))
            {
                bo.Show();
            }
            if (bo.UpdateBoatProp(new Tile(3, 3)))
            {
                bo.Show();
            }
            if (bo.UpdateBoatProp(new Tile(0, 0)))
            {
                bo.Show();
            }
            Console.ReadLine();
            return;
            Map m = new Map(8);
            GameManager gm = new GameManager();
            Boat boat = new Boat(3, new Tile(2, 4));
            Boat boat2 = new Boat(2, new Tile(0, 0));
            //boat2 = boat2.ChangeAlignement(Enums.Alignement.VERTICAL, ref m);
            m.PlaceBoatOnMap(boat);
            m.PlaceBoatOnMap(boat2);
            m.ShowMap();
            gm.MoveBoat(ref boat, ref m, Enums.Direction.RIGHT);
            m.ShowMap();
            //boat = boat.ChangeAlignement(Enums.Alignement.VERTICAL, ref m);
            gm.MoveBoat(ref boat, ref m, Enums.Direction.RIGHT);
            m.ShowMap();
            Console.ReadLine();
            return;
            gm.SetTileState(m, Enums.State.IsEmpty, m.Tiles);
            System.Collections.Generic.List<Tile> boatMod = new System.Collections.Generic.List<Tile>();
            boatMod.Add(new Tile(0, 0));
            boatMod.Add(new Tile(1, 1));
            boatMod.Add(new Tile(2, 2));
            boat.TilesUsed = boatMod;
            boat.NearBoatTiles = boat.GenerateNearBoatTiles();
            m.PlaceBoatOnMap(boat);
            m.ShowMap();
            Console.ReadLine();
            gm = new GameManager();
            gm.GenerateDefaultBoats();
            Boat b = new Boat(3, new Tile(1, 1));
            b = new Boat(2, new Tile(1, 1));
            gm.MoveBoat(ref b, ref m, Enums.Direction.TOP);
            b.GenerateTilesUsed(new Tile(3, 4), b.Length, Enums.Alignement.VERTICAL);
            //Console.WriteLine("Hello World!");
            Console.ReadLine();
        }
    }
}
