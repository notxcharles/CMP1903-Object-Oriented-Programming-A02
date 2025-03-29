using System;
using System.Collections.Generic;
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
        public static void PromptNextTurn()
        {
            Console.WriteLine("Press any key to continue");
            ConsoleKeyInfo key = Console.ReadKey();
        }
        /// <summary>
        /// Prints the display for the start of the game
        /// </summary>
        /// <remarks>
        /// This prints multiple messages to the console, welcoming the user to the game. <c>this._gameName</c> is
        /// used as the title of the game
        /// </remarks>
        public static void GameStartDisplay(string gameName)
        {
            ClearConsole();
            Console.WriteLine($"Welcome to {gameName}");
            Console.WriteLine($"You must battle your way through each room. In each room you will have to defeat a " +
                $"monster who will have the the key to unlock the door!");
            PromptNextTurn();
            ClearConsole();
            return;
        }
        /// <summary>
        /// <c>FinishGame</c> prints a message to the console that lets the user know that they have finished the game
        /// </summary>
        public static void FinishGame()
        {
            Console.WriteLine("Congratulations. You have won! Here is your treasure");
            return;
        }
    }
}
