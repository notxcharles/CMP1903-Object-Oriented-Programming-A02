using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DungeonExplorer.Player;

namespace DungeonExplorer
{
    /// <summary>
    /// Represents an inventory that can hold a collection of items.
    /// </summary>
    public class Inventory
    {
        private List<Item> _inventoryList;
        private int _maxLength;
        /// <summary>
        /// Specifies the sorting order for inventory items.
        /// </summary>
        public enum SortBy
        {
            Ascending,
            Descending,
            Alphabetically
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Inventory"/> class with a specified maximum length.
        /// </summary>
        /// <param name="maxLength">The maximum number of items the inventory can hold.</param>
        public Inventory(int maxLength)
        {
            _inventoryList = new List<Item>();
            _maxLength = maxLength;
        }
        /// <summary>
        /// Adds an item to the inventory.
        /// </summary>
        /// <param name="item">The item to add to the inventory.</param>
        /// <returns><c>true</c> if the item was successfully added, otherwise, <c>false</c>.</returns>
        public bool Add(Item item)
        {
            if (_inventoryList.Count >= _maxLength)
            {
                Console.WriteLine("Your inventory is full, if you wish to add more items to your inventory then you must discard some items");
                return false;
            }
            _inventoryList.Add(item);
            return true;
        }
        /// <summary>
        /// Removes an item from the inventory.
        /// </summary>
        /// <param name="item">The item to remove from the inventory.</param>
        public void Remove(Item item)
        {
            _inventoryList.Remove(item);
        }
        /// <summary>
        /// Gets the number of items in the inventory.
        /// </summary>
        /// <value>The count of items in the inventory list.</value>
        public int Count
        {
            get { return _inventoryList.Count; }
        }
        /// <summary>
        /// Retrieves a list of weapons in the inventory sorted by ascending attack damage.
        /// </summary>
        /// <returns>A list of weapons sorted by ascending attack damage, or null if there are no weapons in the inventory.</returns>
        private List<Weapon> GetWeaponsInInventoryAscending()
        {
            Debug.Assert(_inventoryList != null, "Error: _inventoryList doesn't exist");
            var weaponsWithIndex = _inventoryList.OfType<Weapon>().Select(weapon => weapon).ToList();
            var sortedWeapons = from Weapon weapon in weaponsWithIndex orderby weapon.AttackDamage ascending select weapon;
            List<Weapon> sortedWeaponList = sortedWeapons.ToList();
            if (sortedWeaponList.Count == 0)
            {
                Console.WriteLine("You have no weapons in your inventory");
                return null;
            }
            return sortedWeaponList;
        }
        /// <summary>
        /// Returns a list of the weapons in the inventory, sorted by descending attack damage
        /// </summary>
        private List<Weapon> GetWeaponsInInventoryDescending()
        {
            Debug.Assert(_inventoryList != null, "Error: _inventoryList doesn't exist");
            var weaponsWithIndex = _inventoryList.OfType<Weapon>().Select(weapon => weapon).ToList();
            var sortedWeapons = from Weapon weapon in weaponsWithIndex orderby weapon.AttackDamage descending select weapon;
            List<Weapon> sortedWeaponList = sortedWeapons.ToList();
            if (sortedWeaponList.Count == 0)
            {
                Console.WriteLine("You have no weapons in your inventory");
                return null;
            }
            return sortedWeaponList;
        }
        /// <summary>
        /// Gets a list of weapons in the inventory sorted by attack damage in alphabetical order
        /// </summary>
        /// <returns>A list of weapons sorted by attack damage in ascending order, or <c>null</c> if there are no weapons.</returns>
        private List<Weapon> GetWeaponsInInventoryAlphabetically()
        {
            Debug.Assert(_inventoryList != null, "Error: _inventoryList doesn't exist");
            var weaponsWithIndex = _inventoryList.OfType<Weapon>().Select(weapon => weapon).ToList();
            var sortedWeapons = from Weapon weapon in weaponsWithIndex orderby weapon.Name select weapon;
            List<Weapon> sortedWeaponList = sortedWeapons.ToList();
            if (sortedWeaponList.Count == 0)
            {
                Console.WriteLine("You have no weapons in your inventory");
                return null;
            }
            return sortedWeaponList;
        }
        /// <summary>
        /// Gets a list of weapons in the inventory sorted by attack damage in descending order.
        /// </summary>
        /// <returns>A list of weapons sorted by attack damage in descending order, or <c>null</c> if there are no weapons.</returns>
        public List<Weapon> GetWeaponsInInventory(SortBy sortBy)
        {
            if (sortBy == SortBy.Ascending)
            {
                return GetWeaponsInInventoryAscending();
            }
            else if (sortBy == SortBy.Descending)
            {
                return GetWeaponsInInventoryDescending();
            }
            else if (sortBy == SortBy.Alphabetically)
            {
                return GetWeaponsInInventoryAlphabetically();
            }
            return null;
        }
        /// <summary>
        /// Gets a list of weapons in the inventory sorted alphabetically by name.
        /// </summary>
        /// <returns>A list of weapons sorted alphabetically by name, or <c>null</c> 
        public List<Spell> GetSpellsInInventory()
        {
            Debug.Assert(_inventoryList != null, "Error: _inventoryList doesn't exist");
            var spells = _inventoryList.OfType<Spell>().Select(spell => spell).ToList();
            var sortedSpells = from Spell spell in spells orderby spell.HealAmount descending select spell;
            List<Spell> spellsList = sortedSpells.ToList();
            if (spellsList.Count == 0)
            {
                Console.WriteLine("You have no spells in your inventory");
                return null;
            }
            return spellsList;
        }
        /// <summary>
        /// Gets the total number of weapons in the inventory.
        /// </summary>
        public int GetTotalWeaponsInInventory()
        {
            Debug.Assert(_inventoryList != null, "Error: _inventoryList doesn't exist");
            int weaponCount = _inventoryList.OfType<Weapon>().Count();
            return weaponCount;
        }
        /// <summary>
        /// Gets the total number of spells in the inventory.
        /// </summary>
        /// <returns>The total number of spells in the inventory.</returns>
        public int GetTotalSpellsInInventory()
        {
            Debug.Assert(_inventoryList != null, "Error: _inventoryList doesn't exist");
            int spellCount = _inventoryList.OfType<Spell>().Count();
            return spellCount;
        }
        /// <summary>
        /// Determines whether the inventory list contains an item with the specified name.
        /// </summary>
        /// <param name="itemName">The name of the item to search for in the inventory list.</param>
        /// <returns>
        /// <c>true</c> if an item with the specified name is found in the inventory list; otherwise, <c>false</c>.
        /// </returns>
        public bool HasItem(string itemName)
        {
            foreach (Item item in _inventoryList)
            {
                if (item.Name == itemName)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
