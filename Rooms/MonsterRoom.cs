using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer.Rooms
{
    /// <summary>
    /// Represents a room that contains a monster.
    /// </summary>
    public class MonsterRoom : Room
    {
        [JsonProperty]
        private Monster _monsterInTheRoom;
        [JsonConstructor]
        public MonsterRoom()
        {
            Console.WriteLine("MonsterRoom JSON");
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="MonsterRoom"/> class with a monster, weapon, spell, and hint.
        /// </summary>
        /// <param name="monster">The monster present in the room.</param>
        /// <param name="weaponInTheRoom">The weapon associated with the room.</param>
        /// <param name="spellInTheRoom">The spell associated with the room.</param>
        /// <param name="hint">The hint associated with the room.</param>
        public MonsterRoom(Monster monster, Weapon weaponInTheRoom, Spell spellInTheRoom, Hint hint): base(weaponInTheRoom,  spellInTheRoom, hint)
        {
            _monsterInTheRoom = monster;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="MonsterRoom"/> class with a monster, weapon, and spell.
        /// </summary>
        /// <param name="monster">The monster present in the room.</param>
        /// <param name="weaponInTheRoom">The weapon associated with the room.</param>
        /// <param name="spellInTheRoom">The spell associated with the room.</param>
        public MonsterRoom(Monster monster, Weapon weaponInTheRoom, Spell spellInTheRoom) : base(weaponInTheRoom, spellInTheRoom)
        {
            _monsterInTheRoom = monster;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="MonsterRoom"/> class with a monster and weapon.
        /// </summary>
        /// <param name="monster">The monster present in the room.</param>
        /// <param name="weaponInTheRoom">The weapon associated with the room.</param>
        public MonsterRoom(Monster monster, Weapon weaponInTheRoom) : base(weaponInTheRoom)
        {
            _monsterInTheRoom = monster;
        }
        /// <summary>
        /// Gets a value indicating whether the monster in the room is alive.
        /// </summary>
        /// <returns><c>true</c> if the monster is alive; otherwise, <c>false</c>.</returns>
        public bool MonsterIsAlive
        {
            get { return _monsterInTheRoom != null && _monsterInTheRoom.Health > 0; }
        }
        /// <summary>
        /// Gets the monster present in the room.
        /// </summary>
        public Monster Monster
        {
            get { return _monsterInTheRoom; }
        }
        /// <summary>
        /// Marks the monster as defeated and removes it from the room.
        /// </summary>
        public void MonsterDefeated()
        {
            Debug.Assert(_monsterInTheRoom.Health <= 0, "Monster should have 0 or less health");
            _monsterInTheRoom = null;
            return;
        }
    }
}
