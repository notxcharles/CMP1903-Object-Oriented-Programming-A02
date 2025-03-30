using System;
using System.Diagnostics;

namespace DungeonExplorer
{
    /// <summary>
    /// Class <c>Room</c> controls the logic related to the Room
    /// </summary>
    public class Room
    {
        private string _roomName;
        private string _roomDescription;
        private Monster _monsterInTheRoom;
        private bool _doorIsLocked;
        private Weapon _weaponInTheRoom;
        private Spell _spellInTheRoom;
        private Hint _hintInTheRoom;
        private static string[] _roomNames = new string[] {
            "The Forgotten Hall",
            "Chamber of Chains",
            "The Damp Passage",
            "Fungi Cavern",
            "Banquet Ruins",
            "Statue Gallery",
            "Suspended Bridge",
            "Cathedral of Glass",
            "The Breathing Tunnel",
            "Iron Threshold",
            "The Slime Stairs",
            "Shattered Mirrors",
            "Frozen Abyss",
            "Silent Library",
            "Sunken Temple",
            "Vine Maze",
            "Chain Chamber",
            "Shifting Carvings",
            "Bone Pit",
            "The Still Lake"
        };
        private static string[] _roomDescriptions = new string[] {
            "A vast hall with towering stone pillars, their surfaces worn smooth by time. The air is thick with the scent of damp stone and something faintly metallic.",
            "A circular chamber, its walls lined with rusted chains and shattered weapons. Deep gouges in the floor hint at past struggles.",
            "A long, narrow corridor with an uneven floor, slick with moisture. Faint echoes of dripping water make it impossible to tell how deep the darkness ahead goes.",
            "A cavernous space where bioluminescent fungi cling to the walls, casting eerie blue-green light over jagged rock formations and pools of unknown liquid.",
            "A ruined banquet hall, its wooden tables long rotted, the remnants of a feast petrified in time. The scent of decay lingers despite the ages that have passed.",
            "A chamber filled with strange statues, each frozen in a pose of terror or agony. Their blank eyes seem to follow anyone who enters.",
            "A narrow bridge suspended over a chasm, the ropes frayed and the planks slick with something dark and unidentifiable.",
            "A grand cathedral-like space, where shattered stained glass windows cast fractured light across an altar covered in old, dried stains.",
            "A twisting tunnel with walls that pulse ever so slightly, as if breathing. The ground beneath is soft, like flesh rather than stone.",
            "A massive iron door stands ajar, revealing a cold, metallic room with grated floors. The scent of rust and something acrid fills the air.",
            "A spiral staircase leading downward, its steps uneven and slick with slime. The deeper one descends, the more the walls seem to close in.",
            "A desolate chamber with cracked mirrors covering every surface, each reflecting something just slightly... off.",
            "A frozen cavern where jagged icicles hang from the ceiling, the floor slick and treacherous. The air bites at exposed skin, and breath comes out in thick clouds.",
            "A grand library, its shelves stretching impossibly high. Books lie scattered, some pages torn, others missing entirely. The silence is absolute.",
            "A sunken ruin, half submerged in murky water. Columns rise from the depths, their bases lost in the abyss below.",
            "A maze of twisting roots and gnarled vines, the ground covered in thick, choking fog that swirls unnaturally at the slightest movement.",
            "A towering chamber where chains hang from the ceiling, some swaying ever so slightly despite the lack of any breeze.",
            "A forgotten temple, its walls covered in ancient carvings, some depicting scenes that seem to shift when not directly observed.",
            "A pit of bones, some yellowed with age, others still fresh. The walls are scratched, as if something has tried—and failed—to escape.",
            "A vast underground lake, the water impossibly still. Jagged rocks rise from the surface like teeth, and something beneath the water disturbs the reflection."
        };
        private static Random _random = new Random();
        // TODO: Update documentation to add spellInTheRoom and hint
        /// <summary>
        /// Class <c>Room</c>'s constructor
        /// </summary>
        /// <remarks>
        /// The name and the description of the room are picked at random from a list of premade names and descriptions.
        /// </remarks>
        /// <param name="monster">The instance of the monster</param>
        /// <param name="weaponInTheRoom"></param>
        public Room(Monster monster, Weapon weaponInTheRoom, Spell spellInTheRoom, Hint hint)
        {
            _roomName = CreateRoomName();
            _roomDescription = CreateRoomDescription();
            Debug.Assert(monster != null, "Error: the monster is null");
            this._monsterInTheRoom = monster;
            Debug.Assert(weaponInTheRoom != null, "Error: the weapon is null");
            this._weaponInTheRoom = weaponInTheRoom;
            _spellInTheRoom = spellInTheRoom;
            _hintInTheRoom = hint;
            _doorIsLocked = true;
        }
        // TODO: Update documentation to add spellInTheRoom
        /// <summary>
        /// Class <c>Room</c>'s constructor
        /// </summary>
        /// <remarks>
        /// The name and the description of the room are picked at random from a list of premade names and descriptions.
        /// </remarks>
        /// <param name="monster">The instance of the monster</param>
        /// <param name="weaponInTheRoom"></param>
        public Room(Monster monster, Weapon weaponInTheRoom, Spell spellInTheRoom)
        {
            _roomName = CreateRoomName();
            _roomDescription = CreateRoomDescription();
            Debug.Assert(monster != null, "Error: the monster is null");
            this._monsterInTheRoom = monster;
            Debug.Assert(weaponInTheRoom != null, "Error: the weapon is null");
            this._weaponInTheRoom = weaponInTheRoom;
            _spellInTheRoom = spellInTheRoom;
            _doorIsLocked = true;
        }
        /// <summary>
        /// Class <c>Room</c>'s constructor
        /// </summary>
        /// <remarks>
        /// The name and the description of the room are picked at random from a list of premade names and descriptions.
        /// </remarks>
        /// <param name="monster">The instance of the monster</param>
        /// <param name="weaponInTheRoom"></param>
        public Room(Monster monster, Weapon weaponInTheRoom)
        {
            _roomName = CreateRoomName();
            _roomDescription = CreateRoomDescription();
            Debug.Assert(monster != null, "Error: the monster is null");
            this._monsterInTheRoom = monster;
            Debug.Assert(weaponInTheRoom != null, "Error: the weapon is null");
            this._weaponInTheRoom = weaponInTheRoom;
            _doorIsLocked = true;
        }
        /// <summary>
        /// Create a random room name based on a list of premade room names
        /// </summary>
        /// <returns>The randomly selected room name</returns>
        private string CreateRoomName()
        {
            int index = _random.Next(0, _roomNames.Length);
            return _roomNames[index];
        }
        /// <summary>
        /// Create a random room description based on a list of premade room descriptions
        /// </summary>
        /// <returns>The randomly selected room name</returns>
        private string CreateRoomDescription()
        {
            int index = _random.Next(0, _roomDescriptions.Length);
            return _roomDescriptions[index];
        }
        // TODO: Documentation
        public string RoomName
        {
            get { return _roomName; }
        }
        // TODO: Documentation
        public string RoomDescription
        {
            get { return _roomDescription; }
        }
        // TODO: Documentation
        public Monster Monster
        {
            get { return _monsterInTheRoom; }
        }
        // TODO: Documentation
        public bool MonsterIsAlive
        {
            get { return _monsterInTheRoom != null && _monsterInTheRoom.Health > 0; }
        }
        // TODO: Documentation
        public bool DoorIsLocked
        {
            get { return _doorIsLocked; }
        }
        // TODO: Documentation
        public Weapon Weapon
        {
            get { return _weaponInTheRoom; }
        }
        // TODO: Documentation
        public Spell Spell
        {
            get { return _spellInTheRoom; }
        }
        public bool IsHint
        {
            get { return _hintInTheRoom != null; }
        }
        // TODO: Documentation
        public Hint Hint
        {
            get { return _hintInTheRoom; }
        }
        /// <summary>
        /// Set Room.WeaponInTheRoom to null
        /// </summary>
        public void WeaponPickedUp()
        {
            _weaponInTheRoom = null;
            return;
        }
        //TODO: Documentation
        public void SpellPickedUp()
        {
            _spellInTheRoom = null; 
            return;
        }
        public void MonsterDefeated()
        {
            Debug.Assert(_monsterInTheRoom.Health <= 0, "Monster should have 0 or less health");
            _monsterInTheRoom = null;
            return;
        }
        //TODO: Documentation
        public void UnlockDoor()
        {
            _doorIsLocked = false;
            return;
        }
        // TODO: Documentation
    }
}