using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer.Creatures
{
    /// <summary>
    /// Represents a Witch, a type of Monster that casts spells.
    /// </summary>
    public class Witch : Monster
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Witch"/> class.
        /// </summary>
        /// <param name="name">The name of the witch.</param>
        /// <param name="health">The current health of the witch.</param>
        /// <param name="weapon">The weapon that the witch uses.</param>
        /// <param name="minimumDifficulty">The minimum difficulty level for encountering the witch.</param>
        /// <param name="maximumDifficulty">The maximum difficulty level for encountering the witch.</param>
        /// <param name="maximumHealthToFlee">The maximum health threshold for the witch to flee.</param>
        public Witch(string name, int health, Weapon weapon, int minimumDifficulty, int maximumDifficulty, 
            int maximumHealthToFlee) : base(name, health, weapon, minimumDifficulty, maximumDifficulty, maximumHealthToFlee)
        {

        }
        /// <summary>
        /// Gets the message to display when the witch attacks.
        /// </summary>
        /// <param name="damage">The amount of damage dealt by the witch's spell.</param>
        /// <returns>A string message describing the attack.</returns>
        public override string GetAttackMessage(int damage)
        {
            return $"The Witch cast a spell on you! The spell dealt {damage} damage!";
        }
    }
}
