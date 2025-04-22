using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer.Rooms
{
    /// <summary>
    /// Represents a room with a puzzle that needs to be solved.
    /// </summary>
    public class PuzzleRoom : Room
    {
        [JsonProperty]
        private bool _puzzleSolved;
        [JsonProperty]
        private int _numberToGuess;
        [JsonConstructor]
        // TODO: Documentation comment
        // this constructor is blank because it allows me to implement the funcitonality of loading the class from a save file
        public PuzzleRoom()
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="PuzzleRoom"/> class.
        /// </summary>
        /// <param name="numberToGuess">The number that needs to be guessed to solve the puzzle.</param>
        /// <param name="weapon">The weapon associated with the room.</param>
        /// <param name="spell">The spell associated with the room.</param>
        /// <param name="hint">The hint associated with the room.</param>
        public PuzzleRoom(int numberToGuess, Weapon weapon, Spell spell, Hint hint) : base(weapon, spell, hint)
        {
            _numberToGuess = numberToGuess;
        }
        /// <summary>
        /// Determines whether the provided guess is lower than the number to guess.
        /// </summary>
        /// <param name="guess">The guess to compare.</param>
        /// <returns><c>true</c> if the guess is lower than the number to guess; otherwise, <c>false</c>.</returns>
        public bool GuessLowerThan(int guess)
        {
            return guess < _numberToGuess;
        }
        /// <summary>
        /// Determines whether the provided guess is greater than the number to guess.
        /// </summary>
        /// <param name="guess">The guess to compare.</param>
        /// <returns><c>true</c> if the guess is greater than the number to guess; otherwise, <c>false</c>.</returns>
        public bool GuessGreaterThan(int guess)
        {
            return guess > _numberToGuess;
        }
        /// <summary>
        /// Gets or sets a boolean value indicating whether the puzzle has been solved.
        /// </summary>
        public bool PuzzleSolved
        {
            get { return _puzzleSolved; }
            set { _puzzleSolved = value; }
        }
    }
}
