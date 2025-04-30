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
        private Statistics _statistics;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameState"/> class.
        /// </summary>
        /// <param name="roomNumber">The current room number in the game.</param>
        /// <param name="player">The player object representing the current player.</param>
        /// <param name="rooms">The list of rooms in the game.</param>
        /// <param name="statistics">The game statistics.</param>
        /// <remarks>
        public GameState(int roomNumber, Player player, List<Room> rooms, Statistics statistics)
        {
            _roomNumber = roomNumber;
            _player = player;
            _rooms = rooms;
            _statistics = statistics;
        }
        /// <summary>
        /// Gets the current room number in the game.
        /// </summary>
        /// <value>The current room number.</value
        public int RoomNumber
        {
            get { return _roomNumber; }
            private set { _roomNumber = value; }
        }
        /// <summary>
        /// Gets the player object representing the current player.
        /// </summary>
        /// <value>The player object.</value>
        public Player Player
        {
            get { return _player; }
            private set { _player = value; }
        }
        /// <summary>
        /// Gets the list of rooms in the game.
        /// </summary>
        /// <value>A list of <see cref="Room"/> objects.</value>
        public List<Room> Rooms
        {
            get { return _rooms; }
            private set { _rooms = value; }
        }
        /// <summary>
        /// Gets the game statistics.
        /// </summary>
        /// <value>The game statistics.</
        public Statistics Statistics
        {
            get { return _statistics; }
            private set { _statistics = value; }
        }
    }
}
