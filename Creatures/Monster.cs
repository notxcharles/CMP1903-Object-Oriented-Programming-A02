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
        public Monster(string name, int health, Weapon weapon) : base(name, health)  
        {
            Debug.Assert(name != null, "Error: name does not exist");
            Testing.TestForPositiveInteger(health);
            _weapon = weapon;
        }
        /// <summary>
        /// Class <c>Monster</c>'s constructor
        /// </summary>
        /// <param name="health">The maximum health of the monster</param>
        /// <param name="averageAttack">The average attack value that the monster does</param>
        public Monster(int health, Weapon weapon) : base(health)
        {
            Name = CreateMonsterName();
            Testing.TestForPositiveInteger(health);
            _weapon = weapon;
        }

        // TODO: Documentation
        public Weapon Weapon
        {
            get { return _weapon; }
            protected set { _weapon = value; }
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
            return _weapon.GetAttackDamage();
        }
        //TODO: Documentation Strings
        public virtual void DisplayAttack(int damage)
        {
            Console.WriteLine($"The {this.GetType().Name}, {Name} dealt {damage} damage");
        }
    }
}
