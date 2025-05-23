﻿using Newtonsoft.Json;
using System;
using System.Diagnostics;

namespace DungeonExplorer
{
    /// <summary>
    /// Class <c>Weapon</c> controls the logic of the Weapon
    /// </summary>
    /// <remarks>
    /// Contains the logic for creating a weapon object that the player can use to attack the monster. Class contains the
    /// type of the weapon, the average attack damage of the weapon, and the method to get calculate the attack damage.
    /// </remarks>
    public class Weapon : Item, IHasSummary
    {
        [JsonProperty]
        public int _averageAttackDamage;
        private static Random _random = new Random();
        private static string[] _weaponNames = {
            "Baseball Bat",
            "Machete",
            "Crowbar",
            "Fire Axe",
            "Katana",
            "Shovel",
            "Chainsaw",
            "Hammer",
            "Shotgun",
            "Rifle",
            "Bow and Arrow",
            "Chair Leg",
            "Fire Extinguisher",
            "Heavy Flashlight",
            "Screwdriver",
            "Kitchen Knife",
            "Barbed Wire",
            "Handheld Lawnmower",
            "Car",
            "Fireworks",
            "Tennis Ball Machine"
        };
        private static int _stdDevPercentage = 5;

        [JsonConstructor]
        /// <summary>
        /// Initializes a new instance of the <see cref="Weapon"/> class.
        /// </summary>
        /// <remarks>
        /// This constructor is intentionally left blank to allow the functionality of loading the class from a save file.
        /// </remarks>
        public Weapon()
        {
        }
        /// <summary>
        /// Class <c>Weapon</c>'s constructor
        /// </summary>
        /// <param name="name">The name of the weapon</param>
        /// <param name="weaponAverageDamage">The weapon's average attack damage</param>
        public Weapon(string name, int weaponAverageDamage) : base(name)
        {
            Debug.Assert(name != null, "Error: type is null");
            Tests.TestForPositiveInteger(weaponAverageDamage);
            _averageAttackDamage = weaponAverageDamage;
        }
        /// <summary>
        /// Class <c>Weapon</c>'s constructor
        /// </summary>
        /// <param name="weaponAverageDamage">The weapon's average attack damage</param>
        public Weapon(int weaponAverageDamage) : base()
        {
            Tests.TestForPositiveInteger(weaponAverageDamage);
            Name = CreateWeaponName();
            _averageAttackDamage = weaponAverageDamage;
        }
        /// <summary>
        /// Gets the average attack damage of the weapon.
        /// </summary>
        public int AttackDamage
        { 
            get { return _averageAttackDamage; }
        }
        /// <summary>
        /// From <c>Weapon._weaponNames</c>, randomly select a name for the weapon
        /// </summary>
        /// <returns>The selected string from Weapon._weaponTypes</returns>
        private string CreateWeaponName()
        {
            int index = _random.Next(0, _weaponNames.Length);
            return _weaponNames[index];
        }
        /// <summary>
        /// Create a random number from a Gaussian distribution
        /// </summary>
        /// <param name="mean">Mean of the Gaussian distribution</param>
        /// <param name="stdDev">Standard deviation of the distribution</param>
        /// <returns>The random value from the distribution</returns>
        private double CreateRandomGaussianNumber(int mean, int standardDeviation)
        {
            Tests.TestForPositiveInteger(mean);
            Tests.TestForZeroOrAbove(standardDeviation);
            // Returns a random integer, based on a Gaussian distribution
            double u1 = 1.0 - _random.NextDouble(); 
            double u2 = 1.0 - _random.NextDouble();
            double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2);
            double randNormal = mean + standardDeviation * randStdNormal;
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
            double attackDamageGaussian = CreateRandomGaussianNumber(_averageAttackDamage, _averageAttackDamage / _stdDevPercentage);
            int attackDamage = Convert.ToInt32(attackDamageGaussian);
            Tests.TestForPositiveInteger(attackDamage);
            if (attackDamage < 0)
            {
                return 0;
            }
            return attackDamage;
        }
        /// <summary>
        /// Create the summary of the weapon
        /// </summary>
        /// <remarks>
        /// The summary contains the type of the weapon and the average attack damage of the weapon.
        /// </remarks>
        /// <returns>The summary</returns>
        public string CreateSummary()
        {
            string summary = ($"{Name}, dealing an average of {_averageAttackDamage} per attack");
            return summary;
        }
    }
}
