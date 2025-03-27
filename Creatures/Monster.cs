using DungeonExplorer.Creatures;
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
        public int AverageAttackDamage { get; private set; }
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
        /// <summary>
        /// Class <c>Monster</c>'s constructor
        /// </summary>
        /// <param name="name">The name of the monster</param>
        /// <param name="breed">The breed of the monster</param>
        /// <param name="health">The maximum health of the monster</param>
        /// <param name="averageAttack">The average attack value that the monster does</param>
        public Monster(string name, int health, int averageAttack) : base(name, health)  
        {
            Debug.Assert(name != null, "Error: name does not exist");
            Testing.TestForPositiveInteger(health);
            Testing.TestForZeroOrAbove(averageAttack);
            AverageAttackDamage = averageAttack;
        }
        /// <summary>
        /// Class <c>Monster</c>'s constructor
        /// </summary>
        /// <param name="health">The maximum health of the monster</param>
        /// <param name="averageAttack">The average attack value that the monster does</param>
        public Monster(int health, int averageAttack) : base(health)
        {
            Name = CreateMonsterName();
            Testing.TestForPositiveInteger(health);
            Testing.TestForZeroOrAbove(averageAttack);
            AverageAttackDamage = averageAttack;
        }

        // TODO: Documentation
        public Weapon Weapon
        {
            get { return _weapon; }
        }
        /// <summary>
        /// From <c>Monster._monsterNames</c>, randomly select a name for the monster
        /// </summary>
        /// <returns>The selected string from Monster._monsterNames</returns>
        private string CreateMonsterName()
        {
            int index = _random.Next(0, _monsterNames.Length);
            return _monsterNames[index];
        }
        /// <summary>
        /// Create a random number from a Gaussian distribution
        /// </summary>
        /// <param name="mean">Mean of the Gaussian distribution</param>
        /// <param name="stdDev">Standard deviation of the distribution</param>
        /// <returns>The random value from the distribution</returns>
        private double CreateRandomGaussianNumber(int mean, int stdDev)
        {
            double u1 = 1.0 - _random.NextDouble(); //uniform(0,1] random doubles
            double u2 = 1.0 - _random.NextDouble();
            double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2); //random normal(0,1)
            double randNormal = mean + stdDev * randStdNormal; //random normal(mean,stdDev^2)
            return randNormal;
        }
        /// <summary>
        /// Get the attack damage of the monster
        /// </summary>
        /// <remarks>
        /// Uses the <c>CreateRandomGaussianNumber()</c> function to get the attack damage that the monster does.
        /// </remarks>
        /// <returns>the attack damage</returns>
        public int GetAttackDamage()
        {
            //m_averageAttack represents the mean of a normal distribution
            //attackDamage will be a random datapoint in the distribution
            int stdDevPercentage = 5;
            double attackDamageGaussian = CreateRandomGaussianNumber(AverageAttackDamage, AverageAttackDamage / stdDevPercentage);
            int attackDamage = Convert.ToInt32(attackDamageGaussian);
            return attackDamage;
        }
        
        //TODO: Documentation Strings
        public virtual void DisplayAttack(int damage)
        {
            Console.WriteLine($"The {this.GetType().Name}, {Name} dealt {damage} damage");
        }
    }
}
