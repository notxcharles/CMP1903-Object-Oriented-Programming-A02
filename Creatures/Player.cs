using DungeonExplorer.Creatures;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using static DungeonExplorer.Player;

namespace DungeonExplorer
{
    /// <summary>
    /// Class <c>Player</c> controls the logic of the Player character
    /// </summary>
    public class Player : Creature, ICanDamage
    {
        private Inventory _inventory;
        public int MaxInventorySpace { get; private set; }
        private Weapon _currentEquippedWeapon;
        public enum SortBy
        {
            Ascending,
            Descending,
            Alphabetically
        }
        /// <summary>
        /// Class <c>Player</c>'s constructor
        /// </summary>
        /// <param name="name">Player's name</param>
        /// <param name="health">Player's max health</param>
        public Player(string name, int health) : base(name, health)
        {
            Debug.Assert(name != null && name.Length > 0, "Error: Player name is null or string is empty");
            Testing.TestForPositiveInteger(health);
            MaxInventorySpace = 4;
            _inventory = new Inventory(4);
            //The player's default starting weapon are their fists
            _currentEquippedWeapon = new Weapon("Fists", 30);
        }
        /// <summary>
        /// Gets the player's currently equipped weapon.
        /// </summary>
        public Weapon Weapon
        {
            get { return _currentEquippedWeapon; }
        }
        /// <summary>
        /// Player can <c>PickUpItem</c>
        /// </summary>
        /// <remarks>
        /// This function first checks if the Player's inventory is full. If not, it adds \weapon\ to the Player's inventory.
        /// It can be renamed to PickUpWeapon(), however because of the assessment requirements I have renamed it back to
        /// PickUpItem()
        /// </remarks>
        /// <param name="weapon">The weapon that the player will pick up</param>
        public void PickUpWeapon(Weapon weapon)
        {
            Debug.Assert(MaxInventorySpace <= 9, "Error: MaxInventorySpace should not be greater than 9");
            if (_inventory.Count == MaxInventorySpace)
            {
                Console.WriteLine("Your inventory is full! You cannot pick up any more weapons");
            }
            else if (weapon == null)
            {
                Console.WriteLine("Error: Weapon does not exist");
            }
            else
            {
                _inventory.Add(weapon);
                Console.WriteLine($"{weapon.Name} has been added to your inventory");
            }
            return;
        }
        /// <summary>
        /// Adds a spell to the player's inventory if there is space available.
        /// </summary>
        /// <param name="spell">The spell to add to the inventory.</param>
        public void PickUpSpell(Spell spell)
        {
            Debug.Assert(MaxInventorySpace <= 9, "Error: MaxInventorySpace should not be greater than 9");
            if (_inventory.Count == MaxInventorySpace)
            {
                Console.WriteLine("Your inventory is full! You cannot pick up any more items");
            }
            else if (spell == null)
            {
                Console.WriteLine("Error: Spell does not exist");
            }
            else
            {
                _inventory.Add(spell);
                Console.WriteLine($"{spell.Name} has been added to your inventory");
            }
            return;
        }
        
        /// <summary>
        /// Handles the logic for the player to equip a different weapon
        /// </summary>
        /// <param name="weaponIndex">The index of the weapon within the player's inventory (when inventory is sorted by damage descending)</param>
        public void EquipDifferentWeapon(int weaponIndex)
        {
            // Swap the selected weapon with the currently equipped weapon
            List<Weapon> sortedWeaponList = _inventory.GetWeaponsInInventory(Player.SortBy.Ascending);
            Weapon weaponToEquip = sortedWeaponList[weaponIndex];
            Debug.Assert(weaponToEquip != null, "Error: weaponToEquip is null");
            _inventory.Remove(weaponToEquip);
            _inventory.Add(_currentEquippedWeapon);
            Weapon previousEquippedWeapon = _currentEquippedWeapon;
            _currentEquippedWeapon = weaponToEquip as Weapon;
            Console.WriteLine($"{_currentEquippedWeapon.Name} has been equipped. " +
                $"{previousEquippedWeapon.Name} has been added to your inventory");
            return;
        }
        /// <summary>
        /// Uses a spell from the player's inventory to heal the player.
        /// </summary>
        /// <param name="spellIndex">The index of the spell to use in the inventory.</param>
        public void UseSpell(int spellIndex)
        {
            List<Spell> spellList = _inventory.GetSpellsInInventory();
            Spell spellToUse = spellList[spellIndex];
            Debug.Assert(spellToUse != null, "Error: spellToUse is null");
            _inventory.Remove(spellToUse);
            Health = Health + spellToUse.HealAmount;
            if (Health > MaxHealth)
            {
                Health = MaxHealth;
            }

            Console.WriteLine($"{spellToUse.Name} has been used! " +
                $"Your health is restored to {Health}");
            return;
        }
        /// <summary>
        /// <c>GetTotalItemsInInventory()</c> returns a count of the player's total inventory
        /// </summary>
        /// <returns><c>Player._inventory.Count</c></returns>
        public int GetTotalItemsInInventory()
        {
            Debug.Assert(_inventory != null, "Error: Inventory doesn't exist");
            return _inventory.Count;
        }
        /// <summary>
        /// Gets the total number of weapons in the player's inventory.
        /// </summary>
        /// <returns>The total number of weapons in the inventory.</returns>
        public int GetTotalWeaponsInInventory()
        {
            Debug.Assert(_inventory != null, "Error: Inventory doesn't exist");
            return _inventory.GetTotalWeaponsInInventory();
        }
        /// <summary>
        /// Gets the total number of spells in the player's inventory.
        /// </summary>
        /// <returns>The total number of spells in the inventory.</returns>
        public int GetTotalSpellsInInventory()
        {
            Debug.Assert(_inventory != null, "Error: Inventory doesn't exist");
            return _inventory.GetTotalSpellsInInventory();
        }
        /// <summary>
        /// Gets a list of weapons in the player's inventory sorted by the specified criteria.
        /// </summary>
        /// <param name="sortBy">The sorting criteria.</param>
        /// <returns>A list of weapons sorted by the specified criteria.</returns>
        public List<Weapon> GetWeaponsInInventory(Player.SortBy sortBy)
        {
            Debug.Assert(_inventory != null, "Error: Inventory doesn't exist");
            return _inventory.GetWeaponsInInventory(sortBy);
        }
        /// <summary>
        /// Gets a list of spells in the player's inventory.
        /// </summary>
        /// <returns>A list of spells in the inventory.</returns>
        public List<Spell> GetSpellsInInventory()
        {
            Debug.Assert(_inventory != null, "Error: Inventory doesn't exist");
            return _inventory.GetSpellsInInventory();
        }
        /// <summary>
        /// Gets the attack damage of the player's currently equipped weapon.
        /// </summary>
        /// <returns>The attack damage of the equipped weapon.</returns>
        public int GetAttackDamage()
        {
            Debug.Assert(_currentEquippedWeapon != null, "Error: _currentEquippedWeapon doesn't exist");
            int attackDamage = _currentEquippedWeapon.GetAttackDamage();
            Testing.TestForPositiveInteger(attackDamage);
            return attackDamage;
        }
        /// <summary>
        /// Gets the attack message for the player's attack with their weapon.
        /// </summary>
        /// <param name="damage">The damage dealt by the attack.</param>
        /// <returns>A message describing the player's attack.</returns>
        public string GetAttackMessage(int damage)
        {
            return $"The player attacked with their weapon {_currentEquippedWeapon.Name} and did {damage} damage";
        }
    }
}
