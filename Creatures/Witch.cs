using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer.Creatures
{
    // TODO: Documentation
    public class Witch : Monster
    {
        // TODO: Documentation
        public Witch(string name, int health, Weapon weapon) : base(name, health, weapon)
        {

        }

        // TODO: Documentation
        public override void DisplayAttack(int damage)
        {
            Console.WriteLine($"The Witch cast a spell on you! The spell dealt {damage} damage!");
        }
    }
}
