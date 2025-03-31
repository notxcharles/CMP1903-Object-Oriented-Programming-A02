using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DungeonExplorer.Player;

namespace DungeonExplorer
{
    // TODO: Documentation
    public class Inventory
    {
        private List<Item> _inventoryList;
        private int _maxLength;
        // TODO: Documentation
        public Inventory(int maxLength)
        {
            _inventoryList = new List<Item>();
            _maxLength = maxLength;
        }
        // TODO: Documentation
        // returns true if is a success
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
        // TODO: Documentation
        public void Remove(Item item)
        {
            _inventoryList.Remove(item);
        }
        // TODO: Documentation
        public int Count
        {
            get { return _inventoryList.Count; }
        }
        // TODO: Documentation
        private List<Weapon> GetWeaponsInInventoryAscending()
        {
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
        // TODO: Documentation
        private List<Weapon> GetWeaponsInInventoryDescending()
        {
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
        // TODO: Documentation
        private List<Weapon> GetWeaponsInInventorAlphabetically()
        {
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
        // TODO: Documentation
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
                return GetWeaponsInInventorAlphabetically();
            }
            return null;
        }
        // TODO: Documentation
        public List<Spell> GetSpellsInInventory()
        {
            var spells = _inventoryList.OfType<Spell>().Select(spell => spell).ToList();
            var sortedSpells = from Spell spell in spells orderby spell.HealAmount ascending select spell;
            List<Spell> spellsList = sortedSpells.ToList();
            if (spellsList.Count == 0)
            {
                Console.WriteLine("You have no spells in your inventory");
                return null;
            }
            return spellsList;
        }
        // TODO: Documentation
        public int GetTotalWeaponsInInventory()
        {
            int weaponCount = _inventoryList.OfType<Weapon>().Count();
            return weaponCount;
        }
        // TODO: Documentation
        public int GetTotalSpellsInInventory()
        {
            int spellCount = _inventoryList.OfType<Spell>().Count();
            return spellCount;
        }
    }
}
