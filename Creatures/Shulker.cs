using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer.Creatures
{
    // TODO: Documentation
    public class Shulker : Monster
    {
        // TODO: Documentation
        public Shulker(string name, int health, Weapon weapon) : base(name, health, weapon)
        {

        }
        // TODO: Documentation
        public override void DisplayAttack(int damage)
        {
            Console.WriteLine($"The Shulker shot a homing bullet that dealt {damage} damage!");
        }
    }
}
