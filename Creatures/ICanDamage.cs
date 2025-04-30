using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer.Creatures
{
    /// <summary>
    /// Defines the contract for an entity that can deal damage in the game.
    /// </summary>
    public interface ICanDamage
    {
        Weapon Weapon { get; }
        int GetAttackDamage();
        string GetAttackMessage(int damage);
    }
}
