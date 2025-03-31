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
        // TODO: Documentation
        public Weapon Weapon
        {
            get { return _currentEquippedWeapon; }
            // added a setter in case this is made into a multiplayer game at a later date
            protected set { _currentEquippedWeapon = value; }
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
        // TODO: Documentation
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
        /// <param name="weaponIndex">The index of the weapon within the player's inventory (when inventory is sorted by type)</param>
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
        // TODO: Documentation
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
        // TODO: Documentation
        public int GetTotalWeaponsInInventory()
        {
            return _inventory.GetTotalWeaponsInInventory();
        }
        // TODO: Documentation
        public int GetTotalSpellsInInventory()
        {
            return _inventory.GetTotalSpellsInInventory();
        }
        // TODO: Documentation
        public List<Weapon> GetWeaponsInInventory(Player.SortBy sortBy)
        {
            return _inventory.GetWeaponsInInventory(sortBy);
        }
        // TODO: Documentation
        public List<Spell> GetSpellsInInventory()
        {
            return _inventory.GetSpellsInInventory();
        }
        /// <summary>
        /// <c>GetCurrentAttackDamage()</c> returns a the damage of the Player's equipped weapon
        /// </summary>
        /// <returns><c>Player._currentEquippedWeapon.GetAttackDamage()</c></returns>
        public int GetAttackDamage()
        {
            int attackDamage = _currentEquippedWeapon.GetAttackDamage();
            Testing.TestForPositiveInteger(attackDamage);
            return attackDamage;
        }
        // TODO: Documentation
        public string GetAttackMessage(int damage)
        {
            return $"The player attacked with their weapon {_currentEquippedWeapon.Name} and did {damage} damage";
        }
    }
}
