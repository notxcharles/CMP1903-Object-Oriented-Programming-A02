using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer.Creatures
{
    // TODO: Documentationv
    public class Skeleton : Monster
    {
        // TODO: Documentation
        public Skeleton(string name, int health, int averageAttackDamage) : base(name, health, averageAttackDamage)
        {

        }
        // TODO: Documentation

        public override void DisplayAttack(int damage)
        {
            Console.WriteLine($"The Skeleton shot you with its bow and arrow! It dealt {damage}!");
        }
    }
}
