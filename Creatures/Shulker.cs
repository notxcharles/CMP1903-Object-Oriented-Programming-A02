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
        public Shulker(string name, int health, int averageAttackDamage) : base(name, health, averageAttackDamage)
        {

        }
        // TODO: Documentation
        public override void DisplayAttack(int damage)
        {
            Console.WriteLine($"The Shulker shot a ! The spell dealt {damage} damage!");
        }
    }
}
