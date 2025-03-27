using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public class Dragon : Monster
    {
        public Dragon(string name, int health, int averageAttackDamage) : base(name, health, averageAttackDamage)
        {

        }

        public override void DisplayAttack(int damage)
        {
            Console.WriteLine($"The Dragon breathes fire! It dealt {damage}!");
        }
    }
}