using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public class Spell : Item, IHasSummary
    {
        private int _healAmount;
        /// <summary>
        /// Initialises a new instance of the <see cref="Spell"/> class with the specified
        /// name and heal amount
        /// </summary>
        /// <param name="name">The name of the spell</param>
        /// <param name="healAmount">The amount of health the spell heals</param>
        public Spell(string name, int healAmount) : base(name)
        {
            _healAmount = healAmount;
        }
        /// <summary>
        /// Gets or sets the amount of health the spell heals
        /// </summary>
        /// <value>The amount of health the spell heals</value>
        public int HealAmount
        {
            get { return _healAmount; }
            private set { _healAmount = value; }
        }
        /// <summary>
        /// Create the summary of the spell
        /// </summary>
        /// <remarks>
        /// The summary contains the name of the spell and how much health it heals
        /// </remarks>
        /// <returns>The summary</returns>
        public string CreateSummary()
        {
            string summary = $"A {Name}! This heals the player for {_healAmount} health!";
            return summary;
        }
    }
}
