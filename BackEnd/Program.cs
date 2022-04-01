using System;

namespace BackEnd
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Map m = new Map(8);
            GameManager gm = new GameManager();
            gm.GenerateDefaultBoats();
            Boat b = new Boat(3, new Tile(1, 1));
            b = new Boat(2, new Tile(1, 1));
            gm.MoveBoat(ref b, m, Enum.Direction.TOP);
            b.GenerateTilesUsed(new Tile(3, 4), b.Length, Enum.Alignement.VERTICAL);
            //Console.WriteLine("Hello World!");
            Console.ReadLine();
        }
    }
}
