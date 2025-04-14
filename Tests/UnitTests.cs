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
        private Spell _spell;
        private Weapon _weapon;
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
            _spell = new Spell("Healing Spell of Testing", 1000);
            _weapon = new Weapon("Weapon of Mass Testing", 30);
        }
        [TestMethod]
        /// <summary>
        /// Tests if the game object is successfully initialised
        /// </summary>
        public void TestGameInitialisation()
        {
            Assert.IsTrue(_game != null, "Game does not initialise");
        }
        [TestMethod]
        /// <summary>
        /// Tests if the player object is successfully initialised
        /// </summary>
        public void TestPlayerInitialisation()
        {
            Assert.IsTrue(_player != null, "Player does not initialise");
        }
        [TestMethod]
        /// <summary>
        /// Tests if the spell object is successfully initialised
        /// </summary>
        public void TestSpellInitialisation()
        {
            Assert.IsTrue(_spell != null, "Spell does not initialise");
        }
        [TestMethod]
        /// <summary>
        /// Tests if the weapon object is successfully initialised
        /// </summary>
        public void TestWeaponInitialisation()
        {
            Assert.IsTrue(_weapon != null, "Weapon does not initialise");
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
        [TestMethod]
        /// <summary>
        /// Tests if Player.HasItem() returns true. If it returns false, the inventory doesn't keep track of items that it should contain
        /// </summary>
        public void PlayerInventoryHasWeaponWithName()
        {
            string name = "item with name";
            Weapon weapon = new Weapon(name, 50);
            _player.PickUpWeapon(weapon);
            Assert.IsTrue(_player.HasItem(name), "Player's inventory does not contain a weapon");
        }
        [TestMethod]
        /// <summary>
        /// Tests if Player.HasItem() returns true. If it returns false, the inventory doesn't keep track of items that it should contain
        /// </summary>
        public void PlayerInventoryHasSpellWithName()
        {
            string name = "item with name";
            Spell item = new Spell(name, 50);
            _player.PickUpSpell(item);
            Assert.IsTrue(_player.HasItem(name), "Player's inventory does not contain a spell");
        }
        [TestMethod]
        /// <summary>
        /// Tests if Player.GetTotalItemsInInventory() returns 0 or a positive integer
        /// </summary>
        public void PlayerGetTotalItemsInInventory()
        {
            Assert.IsTrue(_player.GetTotalItemsInInventory() >= 0, "Player's inventory has negative items in their inventory");
        }
        [TestMethod]
        /// <summary>
        /// Tests if Player.GetTotalWeaponsInInventory() returns 0 or a positive integer
        /// </summary>
        public void PlayerGetTotalWeaponsInInventory()
        {
            Assert.IsTrue(_player.GetTotalWeaponsInInventory() >= 0, "Player's inventory has negative items in their inventory");
        }
        [TestMethod]
        /// <summary>
        /// Tests if Player.GetTotalWeaponsInInventory() returns 0 or a positive integer
        /// </summary>
        public void PlayerGetTotalSpellsInInventory()
        {
            Assert.IsTrue(_player.GetTotalSpellsInInventory() >= 0, "Player's inventory has negative items in their inventory");
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
