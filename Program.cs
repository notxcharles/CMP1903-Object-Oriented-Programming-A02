﻿using System;

namespace DungeonExplorer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player("charles", 250, 4);
            Game game = new Game("Dungeon Explorer", player);
            game.Start();
            Console.ReadKey();
        }
    }
}
