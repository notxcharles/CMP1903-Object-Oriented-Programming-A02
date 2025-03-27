using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    // TODO: Documentation
    public class GameMap
    {
        private List<Room> _rooms;
        // TODO: Documentation
        public GameMap(List<Room> rooms)
        {
            _rooms = rooms;
        }
        // TODO: Documentation
        public void CreateMap(int currentRoomIndex)
        {
            Console.WriteLine("Upcoming Rooms:");
            for (int i = currentRoomIndex; i < _rooms.Count; i++)
            {
                string roomName = _rooms[i].RoomName;
                string monsterType = _rooms[i].MonsterInTheRoom.GetType().Name;
                int monsterAttackDamage = _rooms[i].MonsterInTheRoom.AverageAttackDamage;
                if (i == currentRoomIndex)
                {
                    Console.Write("--> Current ");
                }
                Console.Write($"Room {i + 1}: {roomName} contains a {monsterType} that deals {monsterAttackDamage} damage.");
                if (_rooms[i].WeaponInTheRoom != null)
                {
                    string weaponName = _rooms[i].WeaponInTheRoom.Name;
                    Console.Write($" Contains a {weaponName}.");
                }
                if (_rooms[i].SpellInTheRoom != null)
                {
                    string spellName = _rooms[i].SpellInTheRoom.Name;
                    Console.Write($" Contains a {spellName}. ");
                }
                Console.Write("\n");


            }
        }
    }
}
