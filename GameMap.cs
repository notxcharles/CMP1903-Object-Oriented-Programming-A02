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
            //TODO: I WILL FIX THIS
            //Console.WriteLine("Upcoming Rooms:");
            //for (int i = currentRoomIndex; i < _rooms.Count; i++)
            //{
            //    string roomName = _rooms[i].RoomName;
            //    string monsterType = _rooms[i].Monster.GetType().Name;
            //    int monsterAttackDamage = _rooms[i].Monster.AverageAttackDamage;
            //    if (i == currentRoomIndex)
            //    {
            //        Console.Write("--> Current ");
            //    }
            //    Console.Write($"Room {i + 1}: {roomName} contains a {monsterType} that deals {monsterAttackDamage} damage.");
            //    if (_rooms[i].Weapon != null)
            //    {
            //        string weaponName = _rooms[i].Weapon.Name;
            //        Console.Write($" Contains a {weaponName}.");
            //    }
            //    if (_rooms[i].Spell != null)
            //    {
            //        string spellName = _rooms[i].Spell.Name;
            //        Console.Write($" Contains a {spellName}. ");
            //    }
            //    Console.Write("\n);
            //}
        }
    }
}
