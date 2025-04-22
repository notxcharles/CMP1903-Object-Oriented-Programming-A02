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
        private float _difficulty;
        //TODO: Update documentation
        /// <summary>
        /// Class <c>Monster</c>'s constructor
        /// </summary>
        /// <param name="name">The name of the monster</param>
        /// <param name="breed">The breed of the monster</param>
        /// <param name="health">The maximum health of the monster</param>
        /// <param name="averageAttack">The average attack value that the monster does</param>
        public Monster(string name, int health, Weapon weapon) : base(name, health)  
        {
            Debug.Assert(name != null, "Error: name does not exist");
            Tests.TestForPositiveInteger(health);
            _weapon = weapon;
            _difficulty = CalculateRandomDifficulty();
            Health = (int)(health * _difficulty);
        }
        //TODO: Update documentation
        /// <summary>
        /// Class <c>Monster</c>'s constructor
        /// </summary>
        /// <param name="name">The name of the monster</param>
        /// <param name="breed">The breed of the monster</param>
        /// <param name="health">The maximum health of the monster</param>
        /// <param name="averageAttack">The average attack value that the monster does</param>
        public Monster(string name, int health, Weapon weapon, int minDifficulty, int maxDifficulty) : base(name)
        {
            Debug.Assert(name != null, "Error: name does not exist");
            Tests.TestForPositiveInteger(health);
            _weapon = weapon;
            _difficulty = CalculateRandomDifficulty(minDifficulty, maxDifficulty);
            Health = (int)(health * _difficulty);
        }
        //TODO: Update documentation
        /// <summary>
        /// Class <c>Monster</c>'s constructor
        /// </summary>
        /// <param name="health">The maximum health of the monster</param>
        /// <param name="averageAttack">The average attack value that the monster does</param>
        public Monster(int health, float difficulty, Weapon weapon)
        {
            Name = CreateMonsterName();
            Tests.TestForPositiveInteger(health);
            _difficulty = difficulty;
            Health = (int)(health * _difficulty);
            _weapon = weapon;
        }
        //TODO: Documentation
        public Monster(int health, Weapon weapon)
        {
            _weapon = weapon;
            _difficulty = CalculateRandomDifficulty();
            Health = (int)(health * _difficulty);
        }
        // TODO: Documentation
        public Weapon Weapon
        {
            get { return _weapon; }
            protected set { _weapon = value; }
        }
        // TODO: documentation
        public float Difficulty
        {
            get { return _difficulty; }
            protected set { _difficulty = value; }
        }
        //TODO: Documentation
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
        // TODO: Documentation
        private float CalculateRandomDifficulty()
        {
            float randomValue = _random.Next(60, 140);
            float randomDifficulty = randomValue/100;
            return randomDifficulty;
        }
        // TODO: Documentation
        private float CalculateRandomDifficulty(int min, int max)
        {
            float randomValue = _random.Next(min, max);
            float randomDifficulty = randomValue / 100;
            return randomDifficulty;
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
    }
}
