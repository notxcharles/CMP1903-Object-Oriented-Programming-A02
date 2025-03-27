using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer.Creatures
{
    // TODO: Documentation
    public class Warden : Monster
    {
        // TODO: Documentationv
        public Warden(string name, int health, Weapon weapon) : base(name, health, weapon)
        {

        }
        // TODO: Documentation
        public override void DisplayAttack(int damage)
        {
            Console.WriteLine($"The Warden released a sonic boom that dealt {damage} damage!");
        }
    }
}
