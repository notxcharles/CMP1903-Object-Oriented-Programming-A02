using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer.Rooms
{
    public class MonsterRoom : Room
    {
        private Monster _monsterInTheRoom;
        public MonsterRoom(Monster monster, Weapon weaponInTheRoom, Spell spellInTheRoom, Hint hint): base(weaponInTheRoom,  spellInTheRoom, hint)
        {
            _monsterInTheRoom = monster;
        }
        public MonsterRoom(Monster monster, Weapon weaponInTheRoom, Spell spellInTheRoom) : base(weaponInTheRoom, spellInTheRoom)
        {
            _monsterInTheRoom = monster;
        }
        public MonsterRoom(Monster monster, Weapon weaponInTheRoom) : base(weaponInTheRoom)
        {
            _monsterInTheRoom = monster;
        }
        // TODO: Documentation
        public bool MonsterIsAlive
        {
            get { return _monsterInTheRoom != null && _monsterInTheRoom.Health > 0; }
        }
        // TODO: Documentation
        public Monster Monster
        {
            get { return _monsterInTheRoom; }
        }
        public void MonsterDefeated()
        {
            Debug.Assert(_monsterInTheRoom.Health <= 0, "Monster should have 0 or less health");
            _monsterInTheRoom = null;
            return;
        }
    }
}
