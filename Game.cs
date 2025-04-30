using DungeonExplorer.Creatures;
using DungeonExplorer.Rooms;
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
        private int _roomNumber;
        private GameState _gameState;
        private Statistics _statistics;

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
            
        }
        /// <summary>
        /// The primary part of the game's logic
        /// </summary>
        public void Start()
        {
            _roomNumber = 0;
            UserInterface.DisplayGameStart(_gameName);
            int loadGame = UserInterface.GetInput(0, 1, false, false);
            if (loadGame == 0)
            {
                //Create a new game
                CreateNewGameState();
                UserInterface.ClearConsole();
            }
            else
            {
                //Load the game from a file
                LoadGameStateFromFile();
                Console.Clear();
            }
            while (_roomNumber < _numberOfRooms)
            {
                _currentRoom = _rooms[_roomNumber];
                if (_currentRoom is MonsterRoom monsterRoom)
                {
                    UserInterface.DisplayRoomInformation(monsterRoom, _roomNumber);
                    UserInterface.DisplayPlayerDetails(_player, _statistics);
                    UserInterface.ShowTurnDecisions(monsterRoom, _player);
                    int decision = UserInterface.GetInput(0, 9, true, true);
                    Debug.Assert(decision >= 0 && decision <= 11, "Error: Decision must be an integer value from 0 to 9 or 'm' or 's'");
                    HandleMonsterRoomLogic(decision, monsterRoom);
                }
                else if (_currentRoom is PuzzleRoom puzzleRoom)
                {
                    UserInterface.DisplayRoomInformation(puzzleRoom, _roomNumber);
                    UserInterface.DisplayPlayerDetails(_player, _statistics);
                    UserInterface.ShowTurnDecisions(puzzleRoom, _player);
                    int decision = UserInterface.GetInput(0, 9, true, true);
                    Debug.Assert(decision >= 0 && decision <= 11, "Error: Decision must be an integer value from 0 to 9 or 'm' or 's'");
                    HandlePuzzleRoomLogic(decision, puzzleRoom);
                }
                UserInterface.EndTurn();
            }
            string endGameStatistics = _statistics.GetEndGameStatisticsString();
            UserInterface.DisplayFinishGame(true, endGameStatistics);
            return;
        }
        /// <summary>
        /// Creates a new game state with predefined rooms and initializes the game.
        /// </summary>
        /// <returns>The newly created <see cref="GameState"/> object.</returns>
        public GameState CreateNewGameState()
        {
            MonsterRoom room1 = new MonsterRoom(
                new Witch("Witch", 110, new Weapon("Spell", 30), 70, 130, 40),
                new Weapon(90),
                new Spell("Potion of healing", 25),
                new Hint("Hint 1", "You must defeat the monster before you can advance to the next room!"));
            PuzzleRoom room2 = new PuzzleRoom(7,
                new Weapon(75),
                new Spell("Healing potion", 100),
                new Hint("Hint 2", $"The mystery number is 7"));
            MonsterRoom room3 = new MonsterRoom(
                new Dragon("Dragon", 120, new Weapon("Fire Breathing", 30), 60, 150, 35),
                new Weapon(82),
                new Spell("Potion of healing", 50));
            MonsterRoom room4 = new MonsterRoom(
                new Shulker("Shulker", 150, new Weapon("Homing Bullet", 30), 70, 140, 30),
                new Weapon(50));
            PuzzleRoom room5 = new PuzzleRoom(3,
                new Weapon(63),
                new Spell("Healing potion", 60),
                new Hint("Hint 2", $"The mystery number is 3"));
            MonsterRoom room6 = new MonsterRoom(
                new Skeleton("Skeleton", 130, new Weapon("Bow and Arrow", 30), 80, 150, 20),
                new Weapon(22),
                new Spell("Potion of healing", 178));
            MonsterRoom room7 = new MonsterRoom(
                new Warden("Warden", 200, new Weapon("Sonic Boom", 30), 90, 140, 10),
                new Weapon(125));
            _rooms.Add(room1);
            _rooms.Add(room2);
            _rooms.Add(room3);
            _rooms.Add(room4);
            _rooms.Add(room5);
            _rooms.Add(room6);
            _rooms.Add(room7);
            _map = new GameMap(_rooms);
            _numberOfRooms = _rooms.Count;
            _roomNumber = 0;
            _statistics = new Statistics();
            _gameState = new GameState(_roomNumber, _player, _rooms, _statistics);

            SaveHandler.SaveGameStateToFile(_gameState);
            return _gameState;
        }
        /// <summary>
        /// Loads the game state from a file.
        /// </summary>
        /// <returns>The loaded <see cref="GameState"/> object, or a new game state if loading fails.</returns>
        public GameState LoadGameStateFromFile()
        {
            GameState loadedGameState = SaveHandler.GetGameStateFromFile();
            if (loadedGameState == null)
            {
                Console.WriteLine("Error: Could not load game state from file. Creating a new game");
                return CreateNewGameState();
            }
            GameState _gameState = loadedGameState;

            _roomNumber = _gameState.RoomNumber;
            _player = _gameState.Player;
            List<Room> tempRoomList = _gameState.Rooms;
            _rooms = new List<Room>();

            foreach (Room room in _gameState.Rooms)
            {
                if (room is MonsterRoom monsterRoom)
                {
                    _rooms.Add(monsterRoom);
                }
                else if (room is PuzzleRoom puzzleRoom)
                {
                    _rooms.Add(puzzleRoom);
                }
            }

            _statistics = _gameState.Statistics;
            _map = new GameMap(_rooms);
            _numberOfRooms = _rooms.Count;
            Console.WriteLine("Game has been successfully loaded");
            return _gameState;
        }
        /// <summary>
        /// Manages the player's inventory by displaying items, checking inventory status, and sorting items based on user input.
        /// </summary>
        /// <param name="player">The player whose inventory is being managed.</param>
        public void ManageInventory(Player player)
        {
            UserInterface.ViewItemsInInventory(player);
            if (player.GetTotalItemsInInventory() == 0)
            {
                return;
            }
            if (player.GetTotalWeaponsInInventory() == 0)
            {
                return;
            }
            UserInterface.DisplaySortingOptions();
            Inventory.SortBy? sortingOption = UserInterface.GetSortingOption();
            if (sortingOption == null)
            {
                return;
            }
            UserInterface.ViewItemsInInventory(_player, sortingOption.Value);
        }
        /// <summary>
        /// Check if the currentRoom's door is locked
        /// </summary>
        /// <param name="currentRoom">Reference to the current Room object</param>
        /// <returns>
        /// true if <c>currentRoom.DoorIsLocked</c> is false. Otherwise returns false
        /// </returns>
        public bool CanGoToNextRoom(Room currentRoom)
        {
            Debug.Assert(currentRoom != null, "Error: room is null");
            if (currentRoom.DoorIsLocked == false)
            {
                Console.WriteLine("The door is unlocked. You proceed to the next room. . .");
                _statistics.PlayerCompletedARoom();
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
        public void PlayerFightsMonster(Player player, Monster monster, MonsterRoom room)
        {
            Debug.Assert(player != null, "Error: player is null");
            Debug.Assert(monster != null, "Error: monster is null");
            Debug.Assert(room != null, "Error: room is null");
            int playerAttackDamage = player.GetAttackDamage();
            monster.Health -= playerAttackDamage;
            int monsterAttackDamage = -1;

            bool wantsToFlee = monster.WantsToFlee(25);
            if (wantsToFlee)
            {
                monster.Health = 0;
            }
            if (monster.Health > 0)
            {
                monsterAttackDamage = monster.GetAttackDamage();
                player.Health -= monsterAttackDamage;
            }
            else
            {
                room.MonsterDefeated();
                room.UnlockDoor();
            }
            _statistics.PlayerDealtDamage(playerAttackDamage);
            if (monsterAttackDamage != -1)
            {
                _statistics.PlayerReceivedDamage(monsterAttackDamage);
            }
            UserInterface.DisplayAttackInformation(player, monster, wantsToFlee, playerAttackDamage, monsterAttackDamage, _statistics);
            return;
        }
        /// <summary>
        /// Handles the logic flow for player decisions in a monster room.
        /// </summary>
        /// <param name="decision">The player's decision, represented as an integer.</param>
        /// <param name="monsterRoom">The monster room the player is currently in.</param>
        /// <remarks>
        private void HandleMonsterRoomLogic(int decision, MonsterRoom monsterRoom)
        {
            if (decision == 0)
            {
                ManageInventory(_player);
            }
            else if (decision == 1)
            {
                // Player has chosen to change their equipped weapon
                PlayerDecidedToChangeWeapons();
            }
            else if (decision == 2)
            {
                // Player has chosen to change their equipped weapon
                PlayerDecidedToUseSpell();
            }
            else if (decision == 3)
            {
                PlayerDecidedToReadHint(monsterRoom);
            }
            else if (decision == 4)
            {
                //Player wants to goes to next room
                if (CanGoToNextRoom(monsterRoom))
                {
                    _roomNumber += 1;
                }
            }
            else if (decision == 5)
            {
                Console.WriteLine($"You are in {monsterRoom.RoomName}. {monsterRoom.RoomDescription}");
            }
            else if (decision == 6)
            {
                PlayerDecidedToFightMonster(monsterRoom);
            }
            else if (decision == 7)
            {
                PlayerDecidedToPickupSpell(monsterRoom);

            }
            else if (decision == 8)
            {
                PlayerDecidedToPickupWeapon(monsterRoom);
            }
            else if (decision == 9)
            {
                Environment.Exit(0);
            }
            else if (decision == 10)
            {
                //Show map
                _map.CreateAndDisplayMap(_roomNumber);
            }
            else if (decision == 11)
            {
                // Player wants to save their game
                _gameState = new GameState(_roomNumber, _player, _rooms, _statistics);
                SaveHandler.SaveGameStateToFile(_gameState);
                UserInterface.DisplaySavedGame();
            }
        }
        /// <summary>
        /// Handles the logic for player decisions in a puzzle room.
        /// </summary>
        /// <param name="decision">The player's decision, represented as an integer.</param>
        /// <param name="puzzleRoom">The puzzle room the player is currently in.</param>
        /// <remarks>
        private void HandlePuzzleRoomLogic(int decision, PuzzleRoom puzzleRoom)
        {
            if (decision == 0)
            {
                //Player wants to view inventory
                ManageInventory(_player);
            }
            else if (decision == 1)
            {
                // Player has chosen to change their equipped weapon
                PlayerDecidedToChangeWeapons();
            }
            else if (decision == 2)
            {
                // Player has chosen to use a spell
                PlayerDecidedToUseSpell();
            }
            else if (decision == 3)
            {
                // Read hint in the room
                PlayerDecidedToReadHint(puzzleRoom);
                
            }
            else if (decision == 4)
            {
                //Player wants to goes to next room
                if (CanGoToNextRoom(puzzleRoom))
                {
                    _roomNumber += 1;
                }
            }
            else if (decision == 5)
            {
                Console.WriteLine($"You are in {puzzleRoom.RoomName}. {puzzleRoom.RoomDescription}");
            }
            else if (decision == 6)
            {
                // Player wishes to attempt to solve the problem
                PlayerDecidedToSolveThePuzzle(puzzleRoom);
            }
            else if (decision == 7)
            {
                PlayerDecidedToPickupSpell(puzzleRoom);
                
            }
            else if (decision == 8)
            {
                PlayerDecidedToPickupWeapon(puzzleRoom);
            }
            else if (decision == 9)
            {
                Environment.Exit(0);
            }
            else if (decision == 10)
            {
                //Show map
                _map.CreateAndDisplayMap(_roomNumber);
            }
            else if (decision == 11)
            {
                // Player wants to save their game
                _gameState = new GameState(_roomNumber, _player, _rooms, _statistics);
                SaveHandler.SaveGameStateToFile(_gameState);
                UserInterface.DisplaySavedGame();
            }
        }
        /// <summary>
        /// Allows the player to change their equipped weapon by selecting from the weapons in their inventory.
        /// </summary>
        public void PlayerDecidedToChangeWeapons()
        {
            List<Weapon> weapons = _player.GetWeaponsInInventory(Inventory.SortBy.Ascending);
            if (weapons == null)
            {
                UserInterface.EndTurn();
                return;
            }
            UserInterface.DisplayEnumerable(weapons, true, _player);
            int weaponChosenIndex = UserInterface.GetInput(0, weapons.Count, false, false);
            if (weaponChosenIndex == -1)
            {
                UserInterface.EndTurn();
                return;
            }
            _player.EquipDifferentWeapon(weaponChosenIndex);
        }
        /// <summary>
        /// Allows the player to use a spell by selecting from the spells in their inventory.
        /// </summary>
        public void PlayerDecidedToUseSpell()
        {
            List<Spell> spells = _player.GetSpellsInInventory();
            if (spells == null)
            {
                UserInterface.EndTurn();
                return;
            }
            UserInterface.DisplayEnumerable(spells, true, _player);
            int spellChosenIndex = UserInterface.GetInput(0, spells.Count - 1, false, false);
            if (spellChosenIndex == -1)
            {
                UserInterface.EndTurn();
                return;
            }
            _player.UseSpell(spellChosenIndex);
        }
        /// <summary>
        /// Allows the player to read a hint in the current room.
        /// </summary>
        /// <param name="room">The current room the player is in.</param>
        public void PlayerDecidedToReadHint(Room room)
        {
            if (room.IsHint)
            {
                Console.WriteLine($"The clue is: {room.Hint.Clue}");
            }
            else
            {
                Console.WriteLine("There is no hint in this room.");
            }
        }
        /// <summary>
        /// Allows the player to solve a puzzle in the current room.
        /// </summary>
        /// <param name="puzzleRoom">The puzzle room the player is in.</param>
        public void PlayerDecidedToSolveThePuzzle(PuzzleRoom puzzleRoom)
        {
            if (puzzleRoom.PuzzleIsSolved)
            {
                Console.WriteLine("Invalid input! You cannot solve a puzzle twice!");
                return;
            }
            int guess = UserInterface.GetGuessLessThan();
            if (puzzleRoom.GuessLowerThan(guess))
            {
                Console.WriteLine("Congratulations, you have guessed correctly. The door is unlocked.");
                puzzleRoom.PuzzleIsSolved = true;
                puzzleRoom.UnlockDoor();
            }
            else
            {
                _player.Health = (int)(_player.Health / 2);
                Console.WriteLine($"Incorrect. Your health is now {_player.Health}.\nConsider looking at the hint");
            }
        }
        /// <summary>
        /// Allows the player to pick up a spell from the current room.
        /// </summary>
        /// <param name="room">The current room the player is in.</param>
        public void PlayerDecidedToPickupSpell(Room room)
        {
            if (_player.GetTotalItemsInInventory() == _player.MaxInventoryLength)
            {
                Console.WriteLine("Your inventory is full, you may not collect any more spells");
            }
            else
            {
                _player.PickUpSpell(room.Spell);
                room.SpellPickedUp();
            }
        }
        /// <summary>
        /// Allows the player to pick up a weapon from the current room.
        /// </summary>
        /// <param name="room">The current room the player is in.</param>
        public void PlayerDecidedToPickupWeapon(Room room)
        {
            if (_player.GetTotalItemsInInventory() == _player.MaxInventoryLength)
            {
                Console.WriteLine("Your inventory is full, you may not collect any more weapons");
            }
            else
            {
                _player.PickUpWeapon(room.Weapon);
                room.WeaponPickedUp();
            }
        }
        /// <summary>
        /// Allows the player to fight a monster in the current room.
        /// </summary>
        /// <param name="monsterRoom">The monster room the player is in.</param>
        public void PlayerDecidedToFightMonster(MonsterRoom monsterRoom)
        {
            if (!monsterRoom.MonsterIsAlive)
            {
                Console.WriteLine("Invalid input! You cannot fight a monster as there is no monster in the room!");
                return;
                
            }
            PlayerFightsMonster(_player, monsterRoom.Monster, monsterRoom);
        }
    }
}