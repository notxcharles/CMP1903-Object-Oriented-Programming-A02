using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DungeonExplorer
{
    [TestClass]
    public class UnitTests
    {
        private Game _game;
        private Player _player;
        public UnitTests() 
        {
            _player = new Player("TestingPlayer", 500, 8);
            _game = new Game("TestingGame", _player);
        }

    }
}
