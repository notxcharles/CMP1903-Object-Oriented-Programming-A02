using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer.Creatures
{
    /// <summary>
    /// Represents a Warden, a type of monster
    /// </summary>
    public class Warden : Monster
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Warden"/> class.
        /// </summary>
        /// <param name="name">The name of the Warden.</param>
        /// <param name="health">The current health of the Warden.</param>
        /// <param name="weapon">The weapon that the Warden uses.</param>
        /// <param name="minimumDifficulty">The minimum difficulty level for encountering the Warden.</param>
        /// <param name="maximumDifficulty">The maximum difficulty level for encountering the Warden.</param>
        /// <param name="maximumHealthToFlee">The maximum health threshold for the Warden to flee.</param>
        public Warden(string name, int health, Weapon weapon, int minimumDifficulty, int maximumDifficulty, 
            int maximumHealthToFlee) : base(name, health, weapon, minimumDifficulty, maximumDifficulty, maximumHealthToFlee)
        {

        }
        /// <summary>
        /// Gets the message to display when the warden attacks.
        /// </summary>
        /// <param name="damage">The amount of damage dealt by the warden.</param>
        /// <returns>A string message describing the attack.</returns>
        public override string GetAttackMessage(int damage)
        {
            return $"The Warden released a sonic boom that dealt {damage} damage!";
        }
    }
}
