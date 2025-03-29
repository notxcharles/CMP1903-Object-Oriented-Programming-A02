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
        public Skeleton(string name, int health, Weapon weapon, int minimumDifficulty, int maximumDifficulty) : base(name, health, weapon, minimumDifficulty, maximumDifficulty)
        {

        }
        // TODO: Documentation

        public override string GetAttackMessage(int damage)
        {
            return $"The Skeleton shot you with its bow and arrow! It dealt {damage}!";
        }
    }
}
