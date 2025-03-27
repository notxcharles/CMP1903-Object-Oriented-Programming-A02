using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer.Creatures
{
    public class Warden : Monster
    {
        public Warden(string name, int health, int averageAttackDamage) : base(name, health, averageAttackDamage)
        {

        }

        public override void DisplayAttack(int damage)
        {
            Console.WriteLine($"The Warden released a sonic boom that dealt {damage} damage!");
        }
    }
}
