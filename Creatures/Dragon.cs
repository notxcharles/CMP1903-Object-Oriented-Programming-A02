using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    /// <summary>
    /// Represents a Shulker, a type of monster with fiery breath
    /// </summary>
    public class Dragon : Monster
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Dragon"/> class.
        /// </summary>
        /// <param name="name">The name of the Dragon.</param>
        /// <param name="health">The current health of the Dragon.</param>
        /// <param name="weapon">The weapon that the Dragon uses.</param>
        /// <param name="minimumDifficulty">The minimum difficulty level for encountering the Dragon.</param>
        /// <param name="maximumDifficulty">The maximum difficulty level for encountering the Dragon.</param>
        /// <param name="maximumHealthToFlee">The maximum health threshold for the Dragon to flee.</param>
        public Dragon(string name, int health, Weapon weapon, int minimumDifficulty, int maximumDifficulty, 
            int maximumHealthToFlee) : base(name, health, weapon, minimumDifficulty, maximumDifficulty, maximumHealthToFlee)
        {

        }
        /// <summary>
        /// Gets the message to display when the Dragon attacks.
        /// </summary>
        /// <param name="damage">The amount of damage dealt by the Dragon.</param>
        /// <returns>A string message describing the attack.</returns>
        public override string GetAttackMessage(int damage)
        {
            return $"The Dragon breathes fire! It dealt {damage} damage!";
        }
    }
}