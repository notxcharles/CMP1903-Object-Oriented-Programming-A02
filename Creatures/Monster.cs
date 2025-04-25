using DungeonExplorer.Creatures;
using Newtonsoft.Json;
using System;
using System.Diagnostics;

namespace DungeonExplorer
{
    /// <summary>
    /// Class <c>Player</c> controls the logic of the Monster
    /// </summary>
    /// <remarks>
    /// The <c>Monster</c> class is used to create a monster object that the player will fight against.
    /// </remarks>
    public class Monster : Creature, ICanDamage
    {
        private static Random _random = new Random();
        private static string[] _monsterNames = new string[] {
            "Walter White",
            "Joffrey Baratheon",
            "Cersei Lannister",
            "Slade Wilson",
            "Draco Malfoy",
            "Tyrion Lannister",
            "Frank Underwood",
            "The Governor",
            "Wilson Fisk",
            "Negan",
            "Pete Campbell",
            "Alaric Saltzman",
            "Dexter Morgan",
            "Tommen Baratheon",
            "Annalise Keating",
            "Jack Torrance",
            "Omar Little",
            "Bane",
            "Regina Mills",
            "Kai Parker",
            "Dennis Reynolds",
            "Darth Maul",
            "Count Dooku",
            "Jabba the Hutt",
        };
        private Weapon _weapon;
        [JsonProperty]
        private float _difficulty;
        [JsonProperty]
        private int _fleeHealth;
        /// <summary>
        /// Initializes a new instance of the <see cref="Monster"/> class with specified parameters.
        /// </summary>
        /// <param name="name">The name of the monster.</param>
        /// <param name="health">The base health of the monster.</param>
        /// <param name="weapon">The weapon that the monster uses.</param>
        /// <param name="minDifficulty">The minimum difficulty value that can be assigned to the monster.</param>
        /// <param name="maxDifficulty">The maximum difficulty value that can be assigned to the monster.</param>
        /// <param name="maximumHealthToFlee">The health threshold at which the monster will flee.</param>
        public Monster(string name, int health, Weapon weapon, int minDifficulty, int maxDifficulty, int maximumHealthToFlee) : base(name)
        {
            Debug.Assert(name != null, "Error: name does not exist");
            Tests.TestForPositiveInteger(health);
            _weapon = weapon;
            _difficulty = CalculateRandomDifficulty(minDifficulty, maxDifficulty);
            Health = (int)(health * _difficulty);
            MaxHealth = Health;
            _fleeHealth = maximumHealthToFlee;
        }
        /// <summary>
        /// Gets or sets the weapon of the character.
        /// </summary>
        /// <value>
        /// The weapon used by the character.
        /// </value>
        public Weapon Weapon
        {
            get { return _weapon; }
            protected set { _weapon = value; }
        }
        /// <summary>
        /// Gets or sets the difficulty level of the character's challenge.
        /// </summary>
        /// <value>
        /// A float representing the difficulty. A higher value indicates a more difficult challenge.
        /// </value>
        public float Difficulty
        {
            get { return _difficulty; }
            protected set { _difficulty = value; }
        }
        /// <summary>
        /// Gets the difficulty level as a string based on the <see cref="Difficulty"/> value.
        /// </summary>
        /// <value>
        /// Returns a string representing the difficulty level:
        /// "Easy" if the difficulty is less than 0.8,
        /// "Medium" if the difficulty is between 0.8 and 1.2,
        /// and "Hard" if the difficulty is greater than 1.2.
        /// </value>
        public string DifficultyLevel
        {
            get
            {
                if (Difficulty < 0.8)
                {
                    return "Easy";
                }
                else if (Difficulty < 1.2)
                {
                    return "Medium";
                }
                else
                {
                    return "Hard";
                }
            }
        }
        /// <summary>
        /// Calculates a random float between <c>min/100</c> and <c>max/100</c>
        /// </summary>
        /// <param name="min">min/100 represents the lowest random value</param>
        /// <param name="max">max/100 represents the lowest random value</param>
        /// <returns>the random value</returns>
        private float CalculateRandomDifficulty(int min, int max)
        {
            float randomValue = _random.Next(min, max);
            float randomDifficulty = randomValue / 100;
            return randomDifficulty;
        }
        /// <summary>
        /// <c>GetCurrentAttackDamage()</c> returns a the damage of the Monster's weapon
        /// </summary>
        /// <returns><c>Monster._currentEquippedWeapon.GetAttackDamage()</c></returns>
        public int GetAttackDamage()
        {
            return (int)(_weapon.GetAttackDamage()*_difficulty);
        }
        //TODO: Documentation Strings
        public virtual string GetAttackMessage(int damage)
        {
            Console.WriteLine($"DEBUG: {this.GetType().Name} has {_difficulty} difficulty");
            return $"The {this.GetType().Name}, {Name} dealt {damage} damage";
        }

        /// <summary>
        /// WantsToFlee determines if the monster has fled from the player
        /// </summary>
        /// <param name="maximumHealthToFlee">If the monster's health is greater than maximumHealthToFlee then return false</param>
        /// <param name="fleeChance">The percentage chance that the monster will flee</param>
        /// <returns>true if monster has fled</returns>
        public virtual bool WantsToFlee(int fleeChance)
        {
            fleeChance = (int)(fleeChance * (2*_difficulty));
            if (_fleeHealth < Health)
            {
                return false;
            }
            int randomValue = _random.Next(0, 100);
            if (fleeChance < randomValue)
            {
                return true;
            }
            return false;
        }
    }
}
