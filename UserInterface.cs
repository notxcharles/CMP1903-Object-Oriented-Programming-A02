using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    // TODO: Documentation
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
        /// Prints the display for the start of the game
        /// </summary>
        /// <remarks>
        /// This prints multiple messages to the console, welcoming the user to the game. <c>this._gameName</c> is
        /// used as the title of the game
        /// </remarks>
        public static void DisplayGameStart(string gameName)
        {
            ClearConsole();
            Console.WriteLine($"Welcome to {gameName}");
            Console.WriteLine($"You must battle your way through each room. In each room you will have to defeat a " +
                $"monster who will have the the key to unlock the door!");
            EndTurn();
            return;
        }
        // TODO : Documentation
        /// <summary>
        /// Prints multiple lines to the console displaying information about the Player
        /// </summary>
        /// <remarks>
        /// Shows the Player's health, maximum health and what weapon is currently equipped
        /// </remarks>
        public static void DisplayPlayerDetails(Player player)
        {
            Console.WriteLine($"\nCharacter Details:");
            Console.WriteLine($"Health: {player.Health}/{player.MaxHealth}");
            Console.WriteLine($"Equipped Weapon: {player.Weapon.CreateSummary()}\n");
            return;
        }
        /// <summary>
        /// <c>ShowTurnDecisions</c> prints all decisions that the Player can make to the console
        /// </summary>
        /// <param name="monsterAlive">true if the Monster's health is greater than 0</param>
        public static void ShowTurnDecisions(Room room, Player player)
        {
            Debug.Assert(!(room.IsMonsterAlive() == true && room.IsMonsterAlive() == false), "Error: monsterAlive was both true and false");
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("(0) View Inventory");
            Console.WriteLine("(1) Change Equipped Weapon");
            Console.WriteLine("(2) Use a spell");
            if (room.ClueInTheRoom != null)
            {
                Console.WriteLine("(3) Read the clue");
            }
            Console.WriteLine("(4) Open the door");
            Console.WriteLine("(5) View room name and description again");
            if (room.IsMonsterAlive())
            {
                Console.WriteLine($"(6) Attack Monster with {player.Weapon.Name}");
            }
            if (room.SpellInTheRoom != null)
            {
                Console.WriteLine($"(7) Pick up spell");
            }
            if (room.WeaponInTheRoom != null)
            {
                Console.WriteLine($"(8) Pick up weapon");
            }

            Console.WriteLine("(9) Exit game");
            Console.WriteLine("(m) Display map");
            return;
        }
        /// <summary>
        /// <c>FinishGame</c> prints a message to the console that lets the user know that they have finished the game
        /// </summary>
        public static void DisplayFinishGame()
        {
            Console.WriteLine("Congratulations. You have won! Here is your treasure");
            return;
        }
        // TODO: Documentation
        public static int GetInput(int minInput, int maxInput, bool mAsInput)
        {
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey();
                try
                {
                    int keyAsInt = Convert.ToInt32(key.KeyChar.ToString());
                    if (keyAsInt >= minInput && keyAsInt <= maxInput)
                    {
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
                        return 10;
                    }
                    Console.WriteLine($"{key} was pressed. You may only press a key from {minInput} to {maxInput}");
                }
            }
        }
        // TODO: Documentation
        public static void DisplayAttackInformation(Player player, Monster monster, int playerAttackDamage, int monsterAttackDamage)
        {
            if (monster.Health <= 0)
            {
                Console.WriteLine($"You have killed the monster! You did {playerAttackDamage} damage. Congratulations!");
                return;
            }
            else if (player.Health <= 0)
            {
                Console.WriteLine($"The monster has killed you! You took {monsterAttackDamage} damage. Game Over");
                Environment.Exit(1);
                return;
            }
            string playerAttackMessage = player.GetAttackMessage(playerAttackDamage);
            Console.WriteLine(playerAttackMessage + $"The monster now has {monster.Health}/{monster.MaxHealth}");
            string monsterAttackMessage = monster.GetAttackMessage(monsterAttackDamage);
            Console.WriteLine(monsterAttackMessage + $"You now have {player.Health}/{player.MaxHealth}");
        }
        // TODO: Documentation
        public static void DisplayEnumerable(IEnumerable<object> enumerable, bool showIndex)
        {
            if (enumerable.Count() == 0)
            {
                Debug.Assert(enumerable.Count() <= 0, "The enumerable should not be empty");
                return;
            }
            List<object> list = enumerable.ToList();
            for (int i = 0; i < list.Count(); i++)
            {
                if (showIndex)
                {
                    Console.WriteLine($"-{i}: {list[i]}");
                }
                else
                {
                    Console.WriteLine($"- {list[i]}");
                }
                    
            }
            return;
        }
        // TODO: Documentation
        public static void DisplayEnumerable(IEnumerable<Weapon> weaponEnumerable, bool showIndex, Player player)
        {
            if (weaponEnumerable.Count() == 0)
            {
                Console.WriteLine($"You have no Weapons in your inventory. You can hold up to {player.MaxInventorySpace - player.GetTotalItemsInInventory()} weapons.");
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
        // TODO: Documentation
        public static void DisplayEnumerable(IEnumerable<Spell> spellEnumerable, bool showIndex, Player player)
        {
            if (spellEnumerable.Count() == 0)
            {
                Console.WriteLine($"You have no Spells in your inventory. You can hold up to {player.MaxInventorySpace - player.GetTotalItemsInInventory()} spells.");
                return;
            }
            List<Spell> spellList = spellEnumerable.ToList();
            Console.WriteLine($"Spells in your inventory, press the corresponding key to equip the weapon:");
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
    }
}
