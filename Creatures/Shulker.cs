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
        public Shulker(string name, int health, Weapon weapon, int minimumDifficulty, int maximumDifficulty) : base(name, health, weapon, minimumDifficulty, maximumDifficulty)
        {

        }
        // TODO: Documentation
        public override string GetAttackMessage(int damage)
        {
            return $"The Shulker shot a homing bullet that dealt {damage} damage!";
        }
    }
}
