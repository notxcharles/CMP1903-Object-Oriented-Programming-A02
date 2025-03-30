using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer.Rooms
{
    public class PuzzleRoom : Room
    {
        private bool _puzzleSolved;
        private int _numberToGuess;
        public PuzzleRoom(int numberToGuess, Weapon weapon, Spell spell, Hint hint) : base(weapon, spell, hint)
        {
            _numberToGuess = numberToGuess;
        }

        public bool GuessLowerThan(int guess)
        {
            return guess < _numberToGuess;
        }
        public bool GuessGreaterThan(int guess)
        {
            return guess > _numberToGuess;
        }
        public bool PuzzleSolved
        {
            get { return _puzzleSolved; }
            set { _puzzleSolved = value; }
        }
    }
}
