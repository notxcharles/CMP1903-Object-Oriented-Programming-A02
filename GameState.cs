using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    internal class GameState
    {
        private int _roomNumber;
        private Player _player;
        private List<Room> _rooms;

        public GameState(int roomNumber, Player player, List<Room> rooms)
        {
            _roomNumber = roomNumber;
            _player = player;
            _rooms = rooms;
        }
        public int RoomNumber
        {
            get { return _roomNumber; }
        }
        public Player Player
        {
            get { return _player; }
        }
        public List<Room> Rooms
        {
            get { return _rooms; }
        }
    }
}
