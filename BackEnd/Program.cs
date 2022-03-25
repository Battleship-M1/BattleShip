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
            Boat b = new Boat(3);
            b.GenerateTilesUsed(new Tile(3, 4), b.Length, Enum.Alignement.HORIZONTAL, m);
            //Console.WriteLine("Hello World!");
            Console.ReadLine();
        }
    }
}
