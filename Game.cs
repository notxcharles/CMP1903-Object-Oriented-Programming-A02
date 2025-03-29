using DungeonExplorer.Creatures;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace DungeonExplorer
{   
    /// <summary>
    /// Class <c>Game</c> handles the flow and the logic of the Game
    /// </summary>
    internal class Game
    {
        private string _gameName;
        private Player _player;
        private Room _currentRoom;
        private int _numberOfRooms;
        private GameMap _map;
        private static Random _random = new Random();

        private List<Room> _rooms = new List<Room>();
        /// <summary>
        /// Class <c>Game</c>'s constructor
        /// </summary>
        /// <param name="gameName">Name of the game</param>
        /// <param name="amountOfRooms">Number of rooms that the player must progress through</param>
        /// <param name="player">Instance of the game object</param>
        public Game(string gameName, Player player)
        {
            Debug.Assert(gameName != null, "Error: gameName is null");
            Debug.Assert(player != null, "Error: player is null");
            // Initialize the game with one room and one player
            _gameName = gameName;
            _player = player;

            Room room1 = new Room(new Witch("Witch", 100, new Weapon("Spell", 30)), new Weapon(100), new Spell("Potion of healing", 25), new Hint("Hint 1", "You must defeat the monster before you can advance to the next room!"));
            Room room2 = new Room(new Dragon("Dragon", 100, new Weapon("Fire Breating", 30)), new Weapon(100), new Spell("Potion of healing", 50));
            Room room3 = new Room(new Shulker("Shulker", 100, new Weapon("Homing Bullet", 30), 70, 140), new Weapon(100));
            Room room4 = new Room(new Skeleton("Skeleton", 100, new Weapon("Bow and Arrow", 30), 80, 150), new Weapon(100), new Spell("Potion of healing", 150));
            Room room5 = new Room(new Warden("Warden", 100, new Weapon("Sonic Boom", 30)), new Weapon(100));
            _rooms.Add(room1);
            _rooms.Add(room2);
            _rooms.Add(room3);
            _rooms.Add(room4);
            _rooms.Add(room5);
            _map = new GameMap(_rooms);
            _numberOfRooms = _rooms.Count;
        }
        /// <summary>
        /// The primary part of the game's logic
        /// </summary>
        public void Start()
        {
            int roomNumber = 0;
            UserInterface.DisplayGameStart(_gameName);
            _currentRoom = _rooms[roomNumber];
            while (roomNumber < _numberOfRooms)
            {
                _currentRoom.WelcomePlayer(roomNumber);
                int decision = _player.GetTurnDecisions(_currentRoom);
                Debug.Assert(decision >= 0 && decision <= 10, "Error: Decision must be an integer value from 0 to 8");
                if (decision == 0)
                {
                    //Player wants to view inventory
                    _player.ViewItemsInInventory();
                }
                else if (decision == 1)
                {
                    //player has chosen to change their equipped item
                    List<Weapon> weapons = _player.GetWeaponsInInventory();
                    if (weapons == null)
                    {
                        UserInterface.EndTurn();
                        continue;
                    }
                    UserInterface.DisplayEnumerable(weapons, true, _player);
                    int weaponChosenIndex = UserInterface.GetInput(0, weapons.Count);
                    if (weaponChosenIndex == -1)
                    {
                        UserInterface.EndTurn();
                        continue;
                    }
                    _player.EquipDifferentWeapon(weaponChosenIndex);
                }
                else if (decision == 2)
                {
                    //player has chosen to use a spell
                    List<Spell> spells = _player.GetSpellsInInventory();
                    if (spells == null)
                    {
                        UserInterface.EndTurn();
                        continue;
                    }
                    UserInterface.DisplayEnumerable(spells, true, _player);
                    int spellChosenIndex = UserInterface.GetInput(0, spells.Count);
                    if (spellChosenIndex == -1)
                    {
                        UserInterface.EndTurn();
                        continue;
                    }
                    _player.UseSpell(spellChosenIndex);
                }
                else if (decision == 3)
                {
                    // Read hint in the room
                    if (_currentRoom.ClueInTheRoom != null)
                    {
                        Console.WriteLine($"The clue is: {_currentRoom.ClueInTheRoom.Clue}");
                    }
                    else
                    {
                        Console.WriteLine("There is no hint in this room.");
                    }
                }
                else if (decision == 4)
                {
                    //Player wants to goes to next room
                    if (NextRoom(_currentRoom))
                    {
                        roomNumber += 1;
                        _currentRoom = _rooms[roomNumber];
                    }
                }
                else if (decision == 5)
                {
                    Console.WriteLine($"You are in {_currentRoom.GetRoomName()}. {_currentRoom.GetDescription()}");
                }
                else if (decision == 6)
                {
                    if (_currentRoom.IsMonsterAlive())
                    {
                        PlayerFightsMonster(_player, _currentRoom.MonsterInTheRoom, _currentRoom);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input! You cannot fight a monster as there is no monster in the room!");
                    }

                }
                else if (decision == 7)
                {
                    if (_player.GetTotalItemsInInventory() == _player.MaxInventorySpace)
                    {
                        Console.WriteLine("Your inventory is full, you may not collect any more spells");
                    }
                    else
                    {
                        _player.PickUpSpell(_currentRoom.SpellInTheRoom);
                        _currentRoom.SpellPickedUp();
                    }
                }
                else if (decision == 8)
                {
                    if (_player.GetTotalItemsInInventory() == _player.MaxInventorySpace)
                    {
                        Console.WriteLine("Your inventory is full, you may not collect any more weapons");
                    }
                    else
                    {
                        _player.PickUpWeapon(_currentRoom.WeaponInTheRoom);
                        _currentRoom.WeaponPickedUp();
                    }
                }
                else if (decision == 10)
                {
                    //Show map
                    _map.CreateMap(roomNumber);
                }
                UserInterface.EndTurn();
            }
            UserInterface.DisplayFinishGame();
            return;
        }
        
        /// <summary>
        /// Check if the currentRoom's door is locked
        /// </summary>
        /// <param name="currentRoom">Reference to the current Room object</param>
        /// <returns>
        /// true if <c>currentRoom.DoorIsLocked</c> is false. Otherwise returns false
        /// </returns>
        public bool NextRoom(Room currentRoom)
        {
            Debug.Assert(currentRoom != null, "Error: room is null");
            if (currentRoom.DoorIsLocked == false)
            {
                Console.WriteLine("The door is unlocked. You proceed to the next room. . .");
                return true;
            }
            Console.WriteLine("The door is locked! Have you defeated the monster?");
            return false;
        }
        /// <summary>
        /// Handles the Player and the Monster fighting
        /// </summary>
        /// <remarks>
        /// Calculates the attack damage of the Player and applies it to the Monster. If the monster still has positive health after
        /// this, the inverse is done and the function calculates the attack damage of the Monster and applies it to the player.
        /// If the Monster or the Player has 0 or less health, a message is printed to the console informing us of the outcome.
        /// </remarks>
        /// <param name="player">Reference to the current Player object</param>
        /// <param name="monster">Reference to the current Monster object</param>
        /// <param name="room">Reference to the current Room object</param>
        public void PlayerFightsMonster(Player player, Monster monster, Room room)
        {
            Debug.Assert(player != null, "Error: player is null");
            Debug.Assert(monster != null, "Error: monster is null");
            Debug.Assert(room != null, "Error: room is null");
            int playerAttackDamage = player.GetAttackDamage();
            monster.Health -= playerAttackDamage;
            int monsterAttackDamage = -1;
            if (monster.Health > 0)
            { 
                monsterAttackDamage = monster.GetAttackDamage();
                player.Health -= monsterAttackDamage;
            }
            if (monster.Health <= 0)
            {
                Console.WriteLine($"You have killed the monster! You did {playerAttackDamage} damage. Congratulations!");
                room.MonsterInTheRoom = null;
                room.DoorIsLocked = false;
            }
            else if (player.Health <= 0)
            {
                Console.WriteLine($"The monster has killed you! You took {monsterAttackDamage} damage. Game Over");
                Environment.Exit(1);
            }
            else
            {
                Console.WriteLine($"You have hit the monster for {playerAttackDamage} damage. " +
                    $"The monster now has {monster.Health}/{monster.MaxHealth}");
                monster.DisplayAttack(monsterAttackDamage);
                Console.WriteLine($"The monster has hit you for {monsterAttackDamage} damage. " +
                    $"You now have {player.Health}/{player.MaxHealth}");
            }
            Console.WriteLine("here");
            return;
        }
        
    }
}