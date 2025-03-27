using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer.Creatures
{
    public class Witch : Monster
    {
        public Witch(string name, int health, int averageAttackDamage) : base(name, health, averageAttackDamage)
        {

        }

        public override void DisplayAttack(int damage)
        {
            Console.WriteLine($"The Witch cast a spell on you! The spell dealt {damage} damage!");
        }
    }
}
