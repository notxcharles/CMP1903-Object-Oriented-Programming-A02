using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DungeonExplorer
{
    [TestClass]
    public class UnitTests
    {
        private Game _game;
        private Player _player;
        /// <summary>
        /// Initialises the test environment before each test method
        /// </summary>
        [TestInitialize]
        public void SetUp() 
        {
            // [TestInitialize] attribute instructs VS to run setup before each test method,
            // ensuring that all objects are properly initialised
            _player = new Player("TestingPlayer", 500, 8);
            _game = new Game("TestingGame", _player);
        }
        /// <summary>
        /// Tests if the player can pick up a weapon and have it in their inventory
        /// </summary>
        [TestMethod]
        public void PlayerPicksUpWeapon()
        {
            string weaponName = "TestingWeapon";
            Weapon weapon = new Weapon(weaponName, 50);
            _player.PickUpWeapon(weapon);
            Assert.AreEqual(_player.HasItem(weaponName), true);
        }
        /// <summary>
        /// Tests if the player can pick up a spell and have it in their inventory
        /// </summary>
        [TestMethod]
        public void PlayerPicksUpSpell()
        {
            string spellName = "TestingSpell";
            Weapon spell = new Weapon(spellName, 50);
            _player.PickUpWeapon(spell);
            Assert.AreEqual(_player.HasItem(spellName), true);
        }
        /// <summary>
        /// Tests if weapon.GetAttackDamage() returns 0 or a positive integer
        /// </summary>
        [TestMethod]
        public void WeaponDoesZeroOrPositiveDamage()
        {
            string weaponName = "TestingWeapon";
            Weapon weapon = new Weapon(weaponName, 50);
            Assert.IsTrue(weapon.GetAttackDamage() >= 0, "The result should be a positive integer");
        }
    }
}
