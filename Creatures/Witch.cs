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
        public override string GetAttackMessage(int damage)
        {
            return $"The Witch cast a spell on you! The spell dealt {damage} damage!";
        }
    }
}
