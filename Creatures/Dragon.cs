using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    // TODO: Documentation
    public class Dragon : Monster
    {
        // TODO: Documentation
        public Dragon(string name, int health, Weapon weapon) : base(name, health, weapon)
        {

        }
        // TODO: Documentation
        public override string GetAttackMessage(int damage)
        {
            return $"The Dragon breathes fire! It dealt {damage} damage!";
        }
    }
}