using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonExplorer.Creatures;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using NLog;
using System.IO;


namespace DungeonExplorer
{
    [TestClass]
    public class UnitTests
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        private Game _game;
        private Player _player;
        private Spell _spell;
        private Weapon _weapon;

        private Witch _witch;
        private Dragon _dragon;
        private Shulker _shulker;
        private Skeleton _skeleton;
        private Warden _warden;

        [TestInitialize]
        /// <summary>
        /// Initialises the test environment before each test method
        /// </summary>
        public void SetUp() 
        {
            // [TestInitialize] attribute instructs VS to run setup before each test method,
            // ensuring that all objects are properly initialised
            _player = new Player("TestingPlayer", 500, 8);
            _game = new Game("TestingGame", _player);
            _spell = new Spell("Healing Spell of Testing", 1000);
            _weapon = new Weapon("Weapon of Mass Testing", 30);
            _witch = new Witch("Witch", 100, new Weapon("Spell", 30), 70, 130);
            _dragon = new Dragon("Dragon", 100, new Weapon("Fire Breathing", 30), 60, 150);
            _shulker = new Shulker("Shulker", 100, new Weapon("Homing Bullet", 30), 70, 140);
            _skeleton = new Skeleton("Skeleton", 100, new Weapon("Bow and Arrow", 30), 80, 150);
            _warden = new Warden("Warden", 100, new Weapon("Sonic Boom", 30), 90, 140);
        }
        [TestMethod]
        /// <summary>
        /// Tests if the game object is successfully initialised
        /// </summary>
        public void TestIfGameInitialises()
        {
            try
            {
                Assert.IsNotNull(_game, "Game does not initialise");
                logger.Info("TestIfGameInitialises passed");
            }
            catch (Exception ex)
            {
                logger.Error(ex, "TestIfGameInitialises failed.");
                throw;
            }
        }
        [TestMethod]
        /// <summary>
        /// Tests if the player object is successfully initialised
        /// </summary>
        public void TestIfPlayerInitialises()
        {
            try
            { 
                Assert.IsNotNull(_player, "Player does not initialise");
                logger.Info("TestIfPlayerInitialises passed");
            }
            catch (Exception ex)
            {
                logger.Error(ex, "TestIfPlayerInitialises failed.");
                throw;
            }
        }
        [TestMethod]
        /// <summary>
        /// Tests if the spell object is successfully initialised
        /// </summary>
        public void TestIfSpellInitialises()
        {
            try
            { 
                Assert.IsNotNull(_spell, "Spell does not initialise");
                logger.Info("TestIfSpellInitialises passed");
            }
            catch (Exception ex)
            {
                logger.Error(ex, "TestIfSpellInitialises failed.");
                throw;
            }
        }
        [TestMethod]
        /// <summary>
        /// Tests if the weapon object is successfully initialised
        /// </summary>
        public void TestIfWeaponInitialises()
        {
            try
            { 
                Assert.IsNotNull(_weapon, "Weapon does not initialise");
                logger.Info("TestIfWeaponInitialises passed");
            }
            catch (Exception ex)
            {
                logger.Error(ex, "TestIfWeaponInitialises failed.");
                throw;
            }
        }
        [TestMethod]
        /// <summary>
        /// Test if the Creature can be instantiated
        /// </summary>
        public void TestIfWitchInitialises()
        {
            try
            { 
                Assert.IsNotNull(_witch, "Witch did not initialise");
                logger.Info("TestIfWitchInitialises passed");
            }
            catch (Exception ex)
            {
                logger.Error(ex, "TestIfWitchInitialises failed.");
                throw;
            }
        }
        
        /// <summary>
        /// Test if the Creature can be instantiated
        /// </summary>
        public void TestIfDragonInitialises()
        {
            try
            { 
                Assert.IsNotNull(_dragon, "Dragon did not initialise");
                logger.Info("TestIfDragonInitialises passed");
            }
            catch (Exception ex)
            {
                logger.Error(ex, "TestIfDragonInitialises failed.");
                throw;
            }
        }
        [TestMethod]
        /// <summary>
        /// Test if the Creature can be instantiated
        /// </summary>
        public void TestIfShulkerInitialises()
        {
            try
            { 
                Assert.IsNotNull(_shulker, "shulker did not initialise");
                logger.Info("TestIfShulkerInitialises passed");
            }
            catch (Exception ex)
            {
                logger.Error(ex, "TestIfShulkerInitialises failed.");
                throw;
            }
        }
        [TestMethod]
        /// <summary>
        /// Test if the Creature can be instantiated
        /// </summary>
        public void TestIfSkeletonInitialises()
        {
            try
            { 
                Assert.IsNotNull(_skeleton, "skeleton did not initialise");
                logger.Info("TestIfSkeletonInitialises passed");
            }
            catch (Exception ex)
            {
                logger.Error(ex, "TestIfSkeletonInitialises failed.");
                throw;
            }
        }
        [TestMethod]
        /// <summary>
        /// Test if the Creature can be instantiated
        /// </summary>
        public void TestIfWardenInitialises()
        {
            try
            {
                Assert.IsNotNull(_warden, "Warden did not initialise");
                logger.Info("TestIfWardenInitialises passed");
            }
            catch (Exception ex)
            {
                logger.Error(ex, "TestIfWardenInitialises failed.");
                throw;
            }
        }
        [TestMethod]
        /// <summary>
        /// Tests if the player can pick up a weapon and have it in their inventory
        /// </summary>
        public void PlayerPicksUpWeapon()
        {
            string weaponName = "TestingWeapon";
            Weapon weapon = new Weapon(weaponName, 50);
            _player.PickUpWeapon(weapon);
            try
            { 
                Assert.AreEqual(_player.HasItem(weaponName), true);
                logger.Info("PlayerPicksUpWeapon passed");
            }
            catch (Exception ex)
            {
                logger.Error(ex, "PlayerPicksUpWeapon failed.");
                throw;
            }
        }
        [TestMethod]
        /// <summary>
        /// Tests if the player can pick up a spell and have it in their inventory
        /// </summary>
        public void PlayerPicksUpSpell()
        {
            string spellName = "TestingSpell";
            Weapon spell = new Weapon(spellName, 50);
            _player.PickUpWeapon(spell);
            try
            { 
                Assert.IsTrue(_player.HasItem(spellName), "Player's inventory does not contain the spell it should contain");
                logger.Info("PlayerPicksUpSpell passed");
            }
            catch (Exception ex)
            {
                logger.Error(ex, "PlayerPicksUpSpell failed.");
                throw;
            }
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
            try
            { 
                Assert.IsTrue(_player.HasItem(name), "Player's inventory does not contain the weapon it should contain");
                logger.Info("PlayerInventoryHasWeaponWithName passed");
            }
            catch (Exception ex)
            {
                logger.Error(ex, "PlayerInventoryHasWeaponWithName failed.");
                throw;
            }
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
            try
            { 
                Assert.IsTrue(_player.HasItem(name), "Player's inventory does not contain a spell");
                logger.Info("PlayerInventoryHasSpellWithName passed");
            }
            catch (Exception ex)
            {
                logger.Error(ex, "PlayerInventoryHasSpellWithName failed.");
                throw;
            }
        }
        [TestMethod]
        /// <summary>
        /// Tests if Player.GetTotalItemsInInventory() returns 0 or a positive integer
        /// </summary>
        public void PlayerGetTotalItemsInInventory()
        {
            try
            { 
                Assert.IsTrue(_player.GetTotalItemsInInventory() >= 0, "Player's inventory has negative items in their inventory");
                logger.Info("PlayerGetTotalItemsInInventory passed");
            }
            catch (Exception ex)
            {
                logger.Error(ex, "PlayerGetTotalItemsInInventory failed.");
                throw;
            }
        }
        [TestMethod]
        /// <summary>
        /// Tests if Player.GetTotalWeaponsInInventory() returns 0 or a positive integer
        /// </summary>
        public void PlayerGetTotalWeaponsInInventory()
        {
            try
            { 
                Assert.IsTrue(_player.GetTotalWeaponsInInventory() >= 0, "Player's inventory has negative items in their inventory");
                logger.Info("PlayerGetTotalWeaponsInInventory passed");
            }
            catch (Exception ex)
            {
                logger.Error(ex, "PlayerGetTotalWeaponsInInventory failed.");
                throw;
            }
        }
        [TestMethod]
        /// <summary>
        /// Tests if Player.GetTotalWeaponsInInventory() returns 0 or a positive integer
        /// </summary>
        public void PlayerGetTotalSpellsInInventory()
        {
            try
            { 
                Assert.IsTrue(_player.GetTotalSpellsInInventory() >= 0, "Player's inventory has negative items in their inventory");
                logger.Info("PlayerGetTotalSpellsInInventory passed");
            }
            catch (Exception ex)
            {
                logger.Error(ex, "PlayerGetTotalSpellsInInventory failed.");
                throw;
            }
        }
        [TestMethod]
        /// <summary>
        /// Tests if weapon.GetAttackDamage() returns 0 or a positive integer
        /// </summary>
        public void WeaponDoesZeroOrPositiveDamage()
        {
            string weaponName = "TestingWeapon";
            Weapon weapon = new Weapon(weaponName, 50);
            try
            { 
                Assert.IsTrue(weapon.GetAttackDamage() >= 0, "The result should be a positive integer");
                logger.Info("WeaponDoesZeroOrPositiveDamage passed");
            }
            catch (Exception ex)
            {
                logger.Error(ex, "WeaponDoesZeroOrPositiveDamage failed.");
                throw;
            }
        }
        [TestMethod]
        /// <summary>
        /// Tests if Weapon.CreateSummary() should not return a null or empty string
        /// </summary>
        public void WeaponCreateSummary()
        {
            try
            { 
                Assert.IsNotNull(_weapon.CreateSummary(), "Weapon summary should not be null");
                Assert.IsNotEmpty(_weapon.CreateSummary(), "Weapon summary should not be empty");
                logger.Info("WeaponCreateSummary passed");
            }
            catch (Exception ex)
            {
                logger.Error(ex, "WeaponCreateSummary failed.");
                throw;
            }
        }
        [TestMethod]
        /// <summary>
        /// Tests if Spell.CreateSummary() should not return a null or empty string
        /// </summary>
        public void SpellCreateSummary()
        {
            try
            { 
                Assert.IsNotNull(_spell.CreateSummary(), "Spell summary should not be null");
                Assert.IsNotEmpty(_spell.CreateSummary(), "Spell summary should not be empty");
                logger.Info("SpellCreateSummary passed");
            }
            catch (Exception ex)
            {
                logger.Error(ex, "SpellCreateSummary failed.");
                throw;
            }
        }
        [TestMethod]
        /// <summary>
        /// Tests if the creature's GetAttackMessage() returns a null or empty string
        /// </summary>
        public void DragonGetAttackMessage()
        {
            try
            { 
                Assert.IsNotNull(_dragon.GetAttackMessage(50), "Attack Message should not be null");
                Assert.IsNotEmpty(_dragon.GetAttackMessage(50), "Attack Message  should not be empty");
                logger.Info("DragonGetAttackMessage passed");
            }
            catch (Exception ex)
            {
                logger.Error(ex, "DragonGetAttackMessage failed.");
                throw;
            }
        }
        [TestMethod]
        /// <summary>
        /// Tests if the creature's GetAttackMessage() returns a null or empty string
        /// </summary>
        public void SkeletonGetAttackMessage()
        {
            try
            { 
                Assert.IsNotNull(_skeleton.GetAttackMessage(50), "Attack Message should not be null");
                Assert.IsNotEmpty(_skeleton.GetAttackMessage(50), "Attack Message should not be empty");
                logger.Info("SkeletonGetAttackMessage passed");
            }
            catch (Exception ex)
            {
                logger.Error(ex, "SkeletonGetAttackMessage failed.");
                throw;
            }
        }
        [TestMethod]
        /// <summary>
        /// Tests if the creature's GetAttackMessage() returns a null or empty string
        /// </summary>
        public void ShulkerGetAttackMessage()
        {
            try
            { 
                Assert.IsNotNull(_shulker.GetAttackMessage(50), "Attack Message should not be null");
                Assert.IsNotEmpty(_shulker.GetAttackMessage(50), "Attack Message should not be empty");
                logger.Info("ShulkerGetAttackMessage passed");
            }
            catch (Exception ex)
            {
                logger.Error(ex, "ShulkerGetAttackMessage failed.");
                throw;
            }
        }
        [TestMethod]
        /// <summary>
        /// Tests if the creature's GetAttackMessage() returns a null or empty string
        /// </summary>
        public void WardenGetAttackMessage()
        {
            try
            { 
                Assert.IsNotNull(_warden.GetAttackMessage(50), "Attack Message should not be null");
                Assert.IsNotEmpty(_warden.GetAttackMessage(50), "Attack Message should not be empty");
                logger.Info("WardenGetAttackMessage passed");
            }
            catch (Exception ex)
            {
                logger.Error(ex, "WardenGetAttackMessage failed.");
                throw;
            }
        }
        [TestMethod]
        /// <summary>
        /// Tests if the creature's GetAttackMessage() returns a null or empty string
        /// </summary>
        public void WitchGetAttackMessage()
        {
            try 
            { 
                Assert.IsNotNull(_witch.GetAttackMessage(50), "Attack Message should not be null");
                Assert.IsNotEmpty(_witch.GetAttackMessage(50), "Attack Message should not be empty");
                logger.Info("WitchGetAttackMessage passed");
            }
            catch (Exception ex)
            {
                logger.Error(ex, "WitchGetAttackMessage failed.");
                throw;
            }
        }

        // I want to test that the saved gamestate is equal to the gamestate when it has been loaded from the file
        [TestMethod]
        public void SavingIsWorkingAsIntended()
        {
            try
            {
                GameState savedGameState = _game.CreateNewGameState();
                GameState loadedGameState = _game.LoadGameStateFromFile();
                var jsonSettings = SaveHandler.GetJsonSerializerSettings();
                string savedJson = JsonConvert.SerializeObject(savedGameState, jsonSettings);
                string loadedJson = JsonConvert.SerializeObject(loadedGameState, jsonSettings);
                Assert.IsTrue(savedJson == loadedJson);
            }
            catch (Exception ex)
            {
                GameState savedGameState = _game.CreateNewGameState();
                GameState loadedGameState = _game.LoadGameStateFromFile();
                var jsonSettings = SaveHandler.GetJsonSerializerSettings();
                string savedJson = JsonConvert.SerializeObject(savedGameState, jsonSettings);
                string loadedJson = JsonConvert.SerializeObject(loadedGameState, jsonSettings);
                File.WriteAllText("original.json", savedJson);
                File.WriteAllText("loaded.json", loadedJson);
                logger.Error(ex, "SavingIsWorkingAsIntended. Saved Game was not equal to loaded game");
                throw;
            }
        }
    }
}
