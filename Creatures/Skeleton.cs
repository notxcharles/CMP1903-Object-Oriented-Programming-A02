using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer.Creatures
{
    /// <summary>
    /// Represents a Skeleton, a type of monster that wields a bow
    /// </summary>
    public class Skeleton : Monster
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Skeleton"/> class.
        /// </summary>
        /// <param name="name">The name of the Skeleton.</param>
        /// <param name="health">The current health of the Skeleton.</param>
        /// <param name="weapon">The weapon that the Skeleton uses.</param>
        /// <param name="minimumDifficulty">The minimum difficulty level for encountering the Skeleton.</param>
        /// <param name="maximumDifficulty">The maximum difficulty level for encountering the Skeleton.</param>
        /// <param name="maximumHealthToFlee">The maximum health threshold for the Skeleton to flee.</param>
        public Skeleton(string name, int health, Weapon weapon, int minimumDifficulty, int maximumDifficulty, 
            int maximumHealthToFlee) : base(name, health, weapon, minimumDifficulty, maximumDifficulty, maximumHealthToFlee)
        {

        }
        /// <summary>
        /// Gets the message to display when the Skeleton attacks.
        /// </summary>
        /// <param name="damage">The amount of damage dealt by the Skeleton.</param>
        /// <returns>A string message describing the attack.</returns>
        public override string GetAttackMessage(int damage)
        {
            return $"The Skeleton shot you with its bow and arrow! It dealt {damage}!";
        }
    }
}
