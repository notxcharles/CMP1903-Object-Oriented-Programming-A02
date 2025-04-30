using DungeonExplorer.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{

    /// <summary>
    /// Represents the map of the game, containing a list of rooms.
    /// </summary
    public class GameMap
    {
        private List<Room> _rooms;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameMap"/> class with a specified list of rooms.
        /// </summary>
        /// <param name="rooms">The list of rooms in the game map.</param>
        public GameMap(List<Room> rooms)
        {
            _rooms = rooms;
        }
        /// <summary>
        /// Displays the upcoming rooms starting from the specified current room index.
        /// </summary>
        /// <param name="currentRoomIndex">The index of the current room.</param>
        public void CreateAndDisplayMap(int currentRoomIndex)
        {
            Console.WriteLine("Upcoming Rooms:");
            for (int i = currentRoomIndex; i < _rooms.Count; i++)
            {
                if (_rooms[i] is MonsterRoom monsterRoom)
                {
                    
                    if (i == currentRoomIndex)
                    {
                        Console.Write("--> Current ");
                    }
                    CreateRoomDescription(monsterRoom, i);
                    
                }
                else if (_rooms[i] is PuzzleRoom puzzleRoom)
                {
                    
                    if (i == currentRoomIndex)
                    {
                        Console.Write("--> Current ");
                    }
                    CreateRoomDescription(puzzleRoom, i);
                }
            } 
        }
        
        /// <summary>
        /// Creates a description for a monster room and displays it.
        /// </summary>
        /// <param name="monsterRoom">The monster room to describe.</param>
        /// <param name="iteration">The current iteration index.</param>
        public void CreateRoomDescription(MonsterRoom monsterRoom, int iteration)
        {
            string roomName = monsterRoom.RoomName;
            string monsterType = monsterRoom.Monster.GetType().Name;
            int monsterAttackDamage = monsterRoom.Monster.Weapon.AttackDamage;
            Console.Write($"Room {iteration + 1}: {roomName} contains a {monsterType} that deals {monsterAttackDamage} damage.");
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
        
        /// <summary>
        /// Creates a description for a puzzle room and displays it.
        /// </summary>
        /// <param name="puzzleRoom">The puzzle room to describe.</param>
        /// <param name="iteration">The current iteration index.</param>
        public void CreateRoomDescription(PuzzleRoom puzzleRoom, int iteration)
        {
            string roomName = puzzleRoom.RoomName;
            Console.Write($"Room {iteration + 1}: {roomName} contains a puzzle that involves guessing a number!");
            if (puzzleRoom.Weapon != null)
            {
                string weaponName = puzzleRoom.Weapon.Name;
                Console.Write($" Contains a {weaponName}.");
            }
            if (puzzleRoom.Spell != null)
            {
                string spellName = puzzleRoom.Spell.Name;
                Console.Write($" Contains a {spellName}. ");
            }
            Console.Write("\n");
        }
    }
}
