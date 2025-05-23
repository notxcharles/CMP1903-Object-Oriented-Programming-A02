﻿using DungeonExplorer.Rooms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    /// <summary>
    /// Provides methods for displaying information and interacting with the user via the console.
    /// This class handles all user interface logic for the game.
    /// </summary>
    public class UserInterface
    {
        /// <summary>
        /// Clears the games console
        /// </summary>
        public static void ClearConsole()
        {
            Console.Clear();
            // Ocasionally, Console.Clear() won't completely clear the console, so the following line solves that error
            Console.WriteLine("\x1b[3J");
            return;
        }
        /// <summary>
        /// Prompts the player to press a key to advance to the next turn
        /// </summary>
        public static void EndTurn()
        {
            Console.WriteLine("Press any key to continue");
            ConsoleKeyInfo key = Console.ReadKey();
            ClearConsole();
        }
        /// <summary>
        /// Displays the start screen for the game, including the game name and options to start a new game or load a game from a file.
        /// </summary>
        /// <param name="gameName">The name of the game to be displayed.</param>
        public static void DisplayGameStart(string gameName)
        {
            ClearConsole();
            Console.WriteLine($"Welcome to {gameName}");
            Console.WriteLine($"You must battle your way through each room. In each room you will have to defeat a " +
                $"monster who will have the the key to unlock the door!");
            Console.WriteLine();
            Console.WriteLine($"Would you like to:");
            Console.WriteLine($"(0) Start a new game");
            Console.WriteLine($"(1) Load game from file");
            return;
        }
        /// <summary>
        /// Displays information about the current room, including its name, description, 
        /// and any objects or creatures present.
        /// </summary>
        /// <param name="room">The monster room to display information for.</param>
        /// <param name="roomNumber">The index of the room in the dungeon sequence.</param>
        public static void DisplayRoomInformation(MonsterRoom room, int roomNumber)
        {
            Tests.TestForZeroOrAbove(roomNumber);
            Console.WriteLine($"Welcome to Room {room.RoomName} (Room {roomNumber + 1})");
            Console.WriteLine($"{room.RoomDescription}\n");
            if (room.Monster != null)
            {
                Console.WriteLine($"A {room.Monster.GetType().Name} called {room.Monster.Name} is present! It has {room.Monster.Health} " +
                    $"health and does an average of {room.Monster.GetAttackDamage()} attack damage! Monster's difficulty: {room.Monster.DifficultyLevel}");
            }
            else
            {
                Console.WriteLine($"There is no monster in this room!");
            }
            if (room.Hint != null)
            {
                Console.WriteLine($"There is a clue- you should read it!");
            }
            if (room.Weapon != null)
            {
                Console.WriteLine($"There is a weapon inside this room that you can pick up- A {room.Weapon.CreateSummary()}");
            }
            if (room.Spell != null)
            {
                Console.WriteLine($"There is a spell that you can pick up - {room.Spell.CreateSummary()}");
            }
            Console.WriteLine();
        }
        /// <summary>
        /// Displays information about the current room, including its name, description, 
        /// and any objects or what the room's puzzle is
        /// </summary>
        /// <param name="room">The puzzle room to display information for.</param>
        /// <param name="roomNumber">The index of the room in the dungeon sequence.</param>
        public static void DisplayRoomInformation(PuzzleRoom room, int roomNumber)
        {
            Tests.TestForZeroOrAbove(roomNumber);
            Console.WriteLine($"Welcome to Room {room.RoomName} (Room {roomNumber + 1})");
            Console.WriteLine($"{room.RoomDescription}\n");
            Console.WriteLine($"There is no monster in this room, instead there is a puzzle to solve.");
            if (room.Hint != null)
            {
                Console.WriteLine($"There is a clue- you should read it if you need help!");
            }
            if (room.Weapon != null)
            {
                Console.WriteLine($"There is a weapon inside this room that you can pick up- A {room.Weapon.CreateSummary()}");
            }
            if (room.Spell != null)
            {
                Console.WriteLine($"There is a spell that you can pick up - {room.Spell.CreateSummary()}");
            }
            Console.WriteLine();
        }
        /// <summary>
        /// Displays the player's current details, including score, health, and equipped weapon.
        /// </summary>
        /// <param name="player">The player whose details are to be displayed.</param>
        public static void DisplayPlayerDetails(Player player, Statistics statistics)
        {
            Console.WriteLine($"\nCharacter Details:");
            Console.WriteLine($"Score: {statistics.Score}"); 
            Console.WriteLine($"Health: {player.Health}/{player.MaxHealth}");
            Console.WriteLine($"Equipped Weapon: {player.Weapon.CreateSummary()}\n");
            return;
        }
        /// <summary>
        /// Presents the player with a list of possible actions they can take during their turn.
        /// The available options depend on the state of the room and the player's inventory.
        /// </summary>
        /// <param name="room">The room in which the player is currently located.</param>
        /// <param name="player">The player making the decision.</param>
        public static void ShowTurnDecisions(Room room, Player player)
        {
            Debug.Assert(room != null, "Error: room is null");
            Debug.Assert(player != null, "Error: player is null");
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("(0) View Inventory");
            Console.WriteLine("(1) Change Equipped Weapon");
            Console.WriteLine("(2) Use a spell");
            if (room.Hint != null)
            {
                Console.WriteLine("(3) Read the clue");
            }
            Console.WriteLine("(4) Open the door");
            Console.WriteLine("(5) View room name and description again");
            if (room is MonsterRoom mRoom)
            {
                if (mRoom.MonsterIsAlive)
                {
                    Console.WriteLine($"(6) Attack Monster with {player.Weapon.Name}");
                }
            }
            else if (room is PuzzleRoom pRoom)
            {
                if (pRoom.PuzzleIsSolved == false)
                {
                    Console.WriteLine("(6) Attempt to solve the puzzle");
                }
            }
            if (room.Spell != null)
            {
                Console.WriteLine($"(7) Pick up spell");
            }
            if (room.Weapon != null)
            {
                Console.WriteLine($"(8) Pick up weapon");
            }

            Console.WriteLine("(9) Exit game");
            Console.WriteLine("(m) Display map");
            Console.WriteLine("(s) Save game");
            return;
        }
        /// <summary>
        /// Displays the end-game message and presents the player's final game statistics.
        /// </summary>
        /// <param name="endGameStatistics">If true, display a string containing various game statistic</param>
        public static void DisplayFinishGame(bool win, string endGameStatistics)
        {
            if (win)
            {
                Console.WriteLine("Congratulations. You have won! Here is your treasure");
            }
            else
            {
                Console.WriteLine("You have lost.");
            }

            Console.WriteLine("Game statistics:");
            Console.WriteLine(endGameStatistics);
            return;
        }
        /// <summary>
        /// Displays the sorting options for weapons to the user.
        /// </summary>
        public static void DisplaySortingOptions()
        {
            Console.WriteLine("How would you like to sort the Weapons?");
            Console.WriteLine($"(1) Sort by ascending damage");
            Console.WriteLine($"(2) Sort by decending damage");
            Console.WriteLine($"(3) Sort alphabetically (using Weapon name)");
            Console.WriteLine($"(4) Cancel");
        }
        /// <summary>
        /// Gets the sorting option selected by the user.
        /// </summary>
        /// <returns>The selected sorting option, or <c>null</c></returns>
        public static Inventory.SortBy? GetSortingOption()
        {
            int input = GetInput(1, 4, false, false);
            if (input == 1)
            {
                return Inventory.SortBy.Ascending;
            }
            else if (input == 2)
            {
                return Inventory.SortBy.Descending;
            }
            else if (input == 3)
            {
                return Inventory.SortBy.Alphabetically;
            }
            return null;
        }

        /// <summary>
        /// Reads a key press from the console and converts it to an integer within a specified range. 
        /// Optionally, specific keys can be mapped to special values.
        /// </summary>
        /// <param name="minInput">The minimum valid integer input.</param>
        /// <param name="maxInput">The maximum valid integer input.</param>
        /// <param name="mAsInput">If true, the 'm' key is mapped to the value 10.</param>
        /// <param name="sAsInput">If true, the 's' key is mapped to the value 11.</param>
        /// <returns>The integer value corresponding to the key press.</returns>
        public static int GetInput(int minInput, int maxInput, bool mAsInput, bool sAsInput)
        {
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey();
                try
                {
                    int keyAsInt = Convert.ToInt32(key.KeyChar.ToString());
                    if (keyAsInt >= minInput && keyAsInt <= maxInput)
                    {
                        Console.WriteLine();
                        return keyAsInt;
                    }
                    else
                    {
                        Console.WriteLine($"{key} was pressed. You must press a key from {minInput} to {maxInput}");
                    }
                }
                catch (FormatException e)
                {
                    if (mAsInput && key.KeyChar.ToString() == "m")
                    {
                        Console.WriteLine();
                        return 10;
                    }
                    if (mAsInput && key.KeyChar.ToString() == "s")
                    {
                        Console.WriteLine();
                        return 11;
                    }
                    Console.WriteLine($"{key} was pressed. You may only press a key from {minInput} to {maxInput}");
                }
            }
        }

        /// <summary>
        /// Prompts the user to guess a number.
        /// </summary>
        /// <returns>The user's guessed number.</returns>
        public static int GetGuessLessThan()
        {
            Console.WriteLine($"You must guess a number. If your guess is less than the mystery number then you may progress. If it is not, your health will be reduced!");
            return GetInput(0, 9, false, false);
        }

        /// <summary>
        /// Prompts the user to guess a number.
        /// </summary>
        /// <returns>The user's guessed number.</returns>
        public static int GetGuessGreaterThan()
        {
            Console.WriteLine($"You must guess a number. If your guess is greater than the mystery number then you may progress. If it is not, your health will be reduced!");
            return GetInput(0, 9, false, false);
        }

        /// <summary>
        /// Displays the outcome of an attack between the player and a monster, including damage dealt and received, and updates the game state accordingly.
        /// </summary>
        /// <param name="player">The player involved in the attack.</param>
        /// <param name="monster">The monster involved in the attack.</param>
        /// <param name="monsterHasFled">Indicates whether the monster has fled the battle.</param>
        /// <param name="playerAttackDamage">The amount of damage dealt by the player to the monster.</param>
        /// <param name="monsterAttackDamage">The amount of damage dealt by the monster to the player.</param>
        /// <param name="statistics">The game statistics to be updated and displayed if the game ends.</param>
        /// <remarks>
        /// If the monster has fled, a message is displayed and the method returns.
        /// If the monster is killed, a message is displayed and the method returns.
        /// If the player is killed, a game over message is displayed, end game statistics are shown, and the game exits.
        /// Otherwise, the method displays the current health of both the player and the monster after the 

        public static void DisplayAttackInformation(Player player, Monster monster, bool monsterHasFled, int playerAttackDamage, int monsterAttackDamage, Statistics statistics)
        {
            if (monsterHasFled)
            {
                Console.WriteLine($"The monster has fled after you dealt {playerAttackDamage} damage. Congratulations!");
                return;
            }
            if (monster.Health <= 0)
            {
                Console.WriteLine($"You have killed the monster! You dealt {playerAttackDamage} damage. Congratulations!");
                return;
            }
            else if (player.Health <= 0)
            {
                Console.WriteLine($"The monster has killed you! You took {monsterAttackDamage} damage. Game Over.");
                string endGameStatistics = statistics.GetEndGameStatisticsString();
                DisplayFinishGame(false, endGameStatistics);
                Environment.Exit(1);
                return;
            }
            string playerAttackMessage = player.GetAttackMessage(playerAttackDamage);
            Console.WriteLine(playerAttackMessage + $"! The monster now has {monster.Health}/{monster.MaxHealth} hp.");
            string monsterAttackMessage = monster.GetAttackMessage(monsterAttackDamage);
            Console.WriteLine(monsterAttackMessage + $"You now have {player.Health}/{player.MaxHealth} hp.");
        }

        /// <summary>
        /// Displays the items in the player's inventory, including equipped weapons and spells.
        /// </summary>
        /// /// <remarks>
        /// If the player's inventory is empty, an error message is displayed.
        /// Otherwise, the method lists the currently equipped weapon, weapons in the inventory sorted by the specified order, and spells in the inventory.
        /// The method also displays the maximum number of items the player can hold and the current number of items in the inventory.
        /// </remarks>
        /// <param name="player">The player whose inventory is to be viewed.</param>
        /// <param name="sortBy">The sorting order for the inventory items. Default is ascending.</param>
        public static void ViewItemsInInventory(Player player, Inventory.SortBy sortBy = Inventory.SortBy.Ascending)
        {
            // If there are no items in the inventory, show an error
            if (player.GetTotalItemsInInventory() == 0)
            {
                Console.WriteLine($"You have no items in your inventory. You can hold up to {player.MaxInventoryLength} items.");
            }
            else
            {
                Console.WriteLine($"Current equipped weapon: {player.Weapon.CreateSummary()}");
                List<Weapon> weapons = player.GetWeaponsInInventory(sortBy);
                if (weapons != null)
                {
                    Console.WriteLine($"Weapons in your inventory:");
                    foreach (Weapon weapon in weapons)
                    {
                        Console.WriteLine($"- {weapon.CreateSummary()}");
                    }
                }
                List<Spell> spells = player.GetSpellsInInventory();
                if (spells  != null)
                {
                    Console.WriteLine($"Spells in your inventory:");

                    foreach (var spell in spells)
                    {
                        Console.WriteLine($"- {spell.CreateSummary()}");
                    }
                }
                Console.WriteLine($"You can hold up to {player.MaxInventoryLength} items in your inventory. You " +
                    $"are currently holding {player.GetTotalItemsInInventory()} items.");
            }
            return;
        }
        /// <summary>
        /// Displays the player's weapon inventory, including the equipped weapon and other weapons.
        /// If showIndex is true, the index of the weapon in the inventory is shown
        /// </summary>
        /// <param name="weaponEnumerable">The collection of weapons in the player's inventory.</param>
        /// <param name="showIndex">If true, each weapon is prefixed with its index in the list.</param>
        /// <param name="player">The player whose inventory is being displayed.</param>
        public static void DisplayEnumerable(IEnumerable<Weapon> weaponEnumerable, bool showIndex, Player player)
        {
            if (weaponEnumerable.Count() == 0)
            {
                Console.WriteLine($"You have no Weapons in your inventory. You can hold up to {player.MaxInventoryLength - player.GetTotalItemsInInventory()} weapons.");
                return;
            }
            List<Weapon> weaponsList = weaponEnumerable.ToList();
            Console.WriteLine($"Current equipped weapon: {player.Weapon.CreateSummary()}");
            Console.WriteLine($"Weapons in your inventory, press the corresponding key to equip the weapon:");
            for (int i = 0; i < weaponsList.Count; i++)
            {
                if (showIndex)
                {
                    Console.WriteLine($"-{i}: {weaponsList[i].CreateSummary()}");
                }
                else
                {
                    Console.WriteLine($"- {weaponsList[i].CreateSummary()}");
                }
            }
        }
        /// <summary>
        /// Displays the player's spell inventory, listing all available spells.
        /// If showIndex is true, the index of the spell in the inventory is shown
        /// </summary>
        /// <param name="spellEnumerable">The collection of spells in the player's inventory.</param>
        /// <param name="showIndex">If true, each spell is prefixed with its index in the list.</param>
        /// <param name="player">The player whose inventory is being displayed.</param>
        public static void DisplayEnumerable(IEnumerable<Spell> spellEnumerable, bool showIndex, Player player)
        {
            if (spellEnumerable.Count() == 0)
            {
                Console.WriteLine($"You have no Spells in your inventory. You can hold up to {player.MaxInventoryLength - player.GetTotalItemsInInventory()} spells.");
                return;
            }
            List<Spell> spellList = spellEnumerable.ToList();
            Console.WriteLine($"{spellEnumerable.Count()} Spells in your inventory, press the corresponding key to equip the spell:");
            for (int i = 0; i < spellList.Count; i++)
            {
                if (showIndex)
                {
                    Console.WriteLine($"-{i}: {spellList[i].CreateSummary()}");
                }
                else
                {
                    Console.WriteLine($"- {spellList[i].CreateSummary()}");
                }
            }
        }
        /// <summary>
        /// Informs the user that the game has saved
        /// </summary>
        public static void DisplaySavedGame()
        {
            Console.WriteLine("\nGame has been saved successfully");
            return;
        }
    }
}
