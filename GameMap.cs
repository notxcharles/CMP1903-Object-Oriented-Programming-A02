using DungeonExplorer.Rooms;
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
                if (_rooms[i] is MonsterRoom monsterRoom)
                {
                    string roomName = monsterRoom.RoomName;
                    string monsterType = monsterRoom.Monster.GetType().Name;
                    int monsterAttackDamage = monsterRoom.Monster.Weapon.AttackDamage;
                    if (i == currentRoomIndex)
                    {
                        Console.Write("--> Current ");
                    }
                    Console.Write($"Room {i + 1}: {roomName} contains a {monsterType} that deals {monsterAttackDamage} damage.");
                    if (monsterRoom.Weapon != null)
                    {
                        string weaponName = monsterRoom.Weapon.Name;
                        Console.Write($" Contains a {weaponName}.");
                    }
                    if (monsterRoom.Spell != null)
                    {
                        string spellName = monsterRoom.Spell.Name;
                        Console.Write($" Contains a {spellName}. ");
                    }
                    Console.Write("\n");
                }
                else if (_rooms[i] is PuzzleRoom puzzleRoom)
                {

                }
            }
            
        }
    }
}
