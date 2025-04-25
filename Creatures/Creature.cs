using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    /// <summary>
    /// Represents a creature with a name, health, and maximum health.
    /// This class is intended to be a base class for various types of creatures in the game.
    /// </summary>
    public class Creature
    {
        protected string _name;
        protected int _health;
        [JsonProperty]
        protected int _maxHealth;
        /// <summary>
        /// Initializes a new instance of the <see cref="Creature"/> class with specified name and health values.
        /// </summary>
        /// <param name="name">The name of the creature.</param>
        /// <param name="health">The initial health of the creature.</param>
        /// <remarks>
        /// This constructor also sets the maximum health to the initial health value and outputs a message to the console 
        /// indicating the creature's name, type, health, and maximum health.
        /// </remarks>
        public Creature(string name, int health)
        {
            _name = name;
            _health = health;
            _maxHealth = health;
            Console.WriteLine($"the monster {_name} of type {this.GetType().Name}, has health {_health} and max health {_maxHealth}");
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Creature"/> class with only the specified name.
        /// </summary>
        /// <param name="name">The name of the creature.</param>
        /// <remarks>
        /// This constructor sets the name of the creature but does not set the health or maximum health. 
        /// Health properties should be set separately if needed.
        /// </remarks>
        public Creature(string name)
        {
            _name = name;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Creature"/> class.
        /// </summary>
        /// <remarks>
        /// This constructor is intentionally left blank to allow the functionality of loading the class from a save file.
        /// </remarks>
        public Creature()
        {

        }
        /// <summary>
        /// Gets or sets the name of the creature.
        /// </summary>
        /// <value>
        /// The name of the creature.
        /// </value>
        public string Name
        {
            get { return _name; }
            protected set { _name = value; }
        }
        /// <summary>
        /// Gets or sets the current health of the creature.
        /// </summary>
        /// <value>
        /// The current health value of the creature.
        /// </value>
        public int Health
        {
            get { return _health; }
            set { _health = value; }
        }
        /// <summary>
        /// Gets or sets the maximum health of the creature.
        /// </summary>
        /// <value>
        /// The maximum health value of the creature.
        /// </value>
        public int MaxHealth
        {
            get { return _maxHealth; }
            protected set { _maxHealth = value; }
        }
    }
}
