using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer.Creatures
{
    public interface ICanDamage
    {
        Weapon Weapon { get; }

        int GetAttackDamage();
        void DisplayAttack(int damage);
    }
}
