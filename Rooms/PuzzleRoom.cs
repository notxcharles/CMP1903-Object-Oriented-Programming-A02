using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer.Rooms
{
    public class PuzzleRoom : Room
    {
        public PuzzleRoom(Weapon weapon, Spell spell, Hint hint) : base(weapon, spell, hint)
        {
        }
    }
}
