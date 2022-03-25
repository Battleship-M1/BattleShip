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
            //Console.WriteLine("Hello World!");
            Console.ReadLine();
        }
    }
}
