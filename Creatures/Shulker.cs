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
        /// <summary>
        /// Initializes a new instance of the <see cref="Shulker"/> class.
        /// </summary>
        /// <param name="name">The name of the Shulker.</param>
        /// <param name="health">The current health of the Shulker.</param>
        /// <param name="weapon">The weapon that the Shulker uses.</param>
        /// <param name="minimumDifficulty">The minimum difficulty level for encountering the Shulker.</param>
        /// <param name="maximumDifficulty">The maximum difficulty level for encountering the Shulker.</param>
        /// <param name="maximumHealthToFlee">The maximum health threshold for the Shulker to flee.</param>
        public Shulker(string name, int health, Weapon weapon, int minimumDifficulty, int maximumDifficulty, 
            int maximumHealthToFlee) : base(name, health, weapon, minimumDifficulty, maximumDifficulty, maximumHealthToFlee)
        {

        }
        /// <summary>
        /// Gets the message to display when the Shulker attacks.
        /// </summary>
        /// <param name="damage">The amount of damage dealt by the Shulker.</param>
        /// <returns>A string message describing the attack.</returns>
        public override string GetAttackMessage(int damage)
        {
            return $"The Shulker shot a homing bullet that dealt {damage} damage!";
        }
    }
}
