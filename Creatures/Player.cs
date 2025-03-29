using DungeonExplorer.Creatures;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace DungeonExplorer
{
    /// <summary>
    /// Class <c>Player</c> controls the logic of the Player character
    /// </summary>
    public class Player : Creature, ICanDamage
    {
        private List<Item> _inventory = new List<Item>();
        public int MaxInventorySpace { get; private set; }
        private Weapon _currentEquippedWeapon;
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
            //The player's default starting weapon are their fists
            _currentEquippedWeapon = new Weapon("Fists", 30);
        }
        /// <summary>
        /// Class <c>Player</c>'s constructor
        /// </summary>
        /// <param name="name">Player's name</param>
        /// <param name="health">Player's max health</param>
        /// <param name="maxInventorySpace">The maximum inventory space of the player. 0-9</param>
        public Player(string name, int health, int maxInventorySpace): base(name, health)
        {
            Debug.Assert(name != null && name.Length > 0, "Error: Player name is null or string is empty");
            Testing.TestForPositiveInteger(health);
            // There needs to be a maximum inventory space so that ChangeEquippedWeapon() can work
            if (maxInventorySpace > 9)
            {
                maxInventorySpace = 9;
            }
            this.MaxInventorySpace = maxInventorySpace;
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
        /// Prints multiple lines to the console displaying information about the Player
        /// </summary>
        /// <remarks>
        /// Shows the Player's health, maximum health and what weapon is currently equipped
        /// </remarks>
        public void ShowCharacterDetails()
        {
            Console.WriteLine($"\nCharacter Details:");
            Console.WriteLine($"Health: {Health}/{MaxHealth}");
            return;
        }
        // TODO : Documentation
        /// <summary>
        /// Prints multiple lines to the console displaying information about the Player
        /// </summary>
        /// <remarks>
        /// Shows the Player's health, maximum health and what weapon is currently equipped
        /// </remarks>
        public void ShowCharacterDetails(Weapon _currentEquippedWeapon)
        {
            Console.WriteLine($"\nCharacter Details:");
            Console.WriteLine($"Health: {Health}/{MaxHealth}");
            Console.WriteLine($"Equipped Weapon: {_currentEquippedWeapon.CreateSummary()}\n");
            return;
        }
        /// <summary>
        /// <c>ShowTurnDecisions</c> prints all decisions that the Player can make to the console
        /// </summary>
        /// <param name="monsterAlive">true if the Monster's health is greater than 0</param>
        public void ShowTurnDecisions(Room currentRoom)
        {
            Debug.Assert(!(currentRoom.IsMonsterAlive() == true && currentRoom.IsMonsterAlive() == false), "Error: monsterAlive was both true and false");
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("(0) View Inventory");
            Console.WriteLine("(1) Change Equipped Weapon");
            Console.WriteLine("(2) Use a spell");
            if (currentRoom.ClueInTheRoom != null)
            {
                Console.WriteLine("(3) Read the clue");
            }
            Console.WriteLine("(4) Open the door");
            Console.WriteLine("(5) View room name and description again");
            if (currentRoom.IsMonsterAlive())
            {
                Console.WriteLine($"(6) Attack Monster with {_currentEquippedWeapon.Name}");
            }
            if (currentRoom.SpellInTheRoom != null)
            {
                Console.WriteLine($"(7) Pick up spell");
            }
            if (currentRoom.WeaponInTheRoom != null)
            {
                Console.WriteLine($"(8) Pick up weapon");
            }

            Console.WriteLine("(9) Exit game");
            Console.WriteLine("(m) Display map");
            return;
        }
        // TODO: update documentation
        /// <summary>
        /// Call <c>ShowTurnDecisions()</c> and then read the user's input as to the action they choose
        /// </summary>
        /// <remarks>
        /// After the user is shown the decisions that they may make on the turn, this function also returns the integer
        /// value for the decision. The user may only enter an integer, if they do not, they are informed of the required
        /// format and asked for their input again
        /// </remarks>
        /// <param name="monsterAlive">true if the Monster's health is greater than 0</param>
        /// <returns>Int value from 0 to 5 or 9. if monsterAlive = true, 6 may also be returned</returns>
        public int GetTurnDecisions(Room currentRoom)
        {
            ShowCharacterDetails(_currentEquippedWeapon);
            bool recievedValidInput = false;
            while (recievedValidInput == false)
            {
                ShowTurnDecisions(currentRoom);
                ConsoleKeyInfo key = Console.ReadKey();
                Console.WriteLine("");
                try
                {
                    int keyAsInt = Convert.ToInt32(key.KeyChar.ToString());
                    if (keyAsInt >= 0 && keyAsInt <= 8)
                    {
                        Console.WriteLine($"Player pressed {keyAsInt}");
                        return keyAsInt;
                    }
                    else if (keyAsInt == 9)
                    {
                        Console.WriteLine($"Player wishes to exit");
                        Environment.Exit(0);
                    }
                    else
                    {
                        Console.WriteLine($"{key} was pressed. You must input a number from 0 to 9");
                    }
                }
                catch (FormatException e)
                {
                    if (key.KeyChar.ToString() == "m")
                    {
                        return 10;
                    }
                    else
                    {
                        Console.WriteLine($"error {key} was pressed. You must press a number from 0 to 9");
                    }
                }
            }
            return -1;
        }
        /// <summary>
        /// Prints multiple strings of all items in the player's inventory
        /// </summary>
        /// <remarks>
        /// First we check that there are items in the inventory, if there is then the inventory is sorted
        /// by item type. For each item in the Player's inventory, a message is written to the console that 
        /// displays the item's name. If the inventory is empty, a message is printed which communicates 
        /// this to the player instead
        /// </remarks>
        public void ViewItemsInInventory()
        {
            // If there are no items in the inventory, show an error
            if (_inventory.Count == 0)
            {
                Console.WriteLine($"You have no items in your inventory. You can hold up to {MaxInventorySpace} items.");
            }
            else
            {
                Console.WriteLine($"Current equipped weapon: {_currentEquippedWeapon.CreateSummary()}");
                Console.WriteLine($"Weapons in your inventory:");
                var weaponsWithIndex = _inventory.OfType<Weapon>().Select(weapon => weapon);
                foreach (var weapon in weaponsWithIndex)
                {
                    Console.WriteLine($"- {weapon.CreateSummary()}");
                }
                Console.WriteLine($"Spells in your inventory:");
                var spellsWithIndex = _inventory.OfType<Spell>().Select(spell => spell);
                foreach (var spell in spellsWithIndex)
                {
                    Console.WriteLine($"- {spell.CreateSummary()}");
                }
                Console.WriteLine($"You can hold up to {MaxInventorySpace} items in your inventory. You " +
                    $"are currently holding {_inventory.Count} items.");                
            }
            return;
        }
        // TODO: Documentation
        public List<Weapon> GetWeaponsInInventory()
        {
            var weaponsWithIndex = _inventory.OfType<Weapon>().Select(weapon => weapon).ToList();
            var sortedWeapons = from Weapon weapon in weaponsWithIndex orderby weapon.AttackDamage descending select weapon;
            List<Weapon> sortedWeaponList = sortedWeapons.ToList();
            if (sortedWeaponList.Count == 0)
            {
                Console.WriteLine("You have no weapon in your inventory");
                return null;
            }
            return sortedWeaponList;
        }
        /// <summary>
        /// Handles the logic for the player to equip a different weapon
        /// </summary>
        /// <param name="weaponIndex">The index of the weapon within the player's inventory (when inventory is sorted by type)</param>
        public void EquipDifferentWeapon(int weaponIndex)
        {
            // Swap the selected weapon with the currently equipped weapon
            var weapons = _inventory.OfType<Weapon>().Select(weapon => weapon).ToList();
            var sortedWeapons = from Weapon weapon in weapons orderby weapon.AttackDamage descending select weapon;
            List<Weapon> sortedWeaponList = sortedWeapons.ToList();
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
        public void ViewSpellsInInventory()
        {
            var spellsWithIndex = _inventory.OfType<Spell>().Select((spell, index) => (spell, index));
            if (spellsWithIndex.Count() == 0)
            {
                Console.WriteLine($"You have no spells in your inventory. You can hold up to {MaxInventorySpace - _inventory.Count} spells.");
                return;
            }
            else
            {
                Console.WriteLine($"Spells in your inventory, press the corresponding key to use the spell:");
                foreach (var (weapon, index) in spellsWithIndex)
                {
                    Console.WriteLine($"-{index}: {weapon.CreateSummary()}");
                }
            }
            return;
        }
        // TODO: documentation
        /// <summary>
        /// Call <c>SelectWeaponInInventory()</c> and then read the user's input as to the action they choose
        /// </summary>
        /// <returns>The integer index of the item in _inventory that the user selects</returns>
        public int SelectSpellInInventory()
        {
            var spellsWithIndex = _inventory.OfType<Spell>().Select((weapon, index) => (weapon, index));
            ViewSpellsInInventory();
            // Player can't select an item in their inventory if their inventory is empty
            if (spellsWithIndex.Count() == 0)
            {
                return -1;
            }
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey();
                try
                {
                    int keyAsInt = Convert.ToInt32(key.KeyChar.ToString());
                    if (keyAsInt >= 0 && keyAsInt < spellsWithIndex.Count())
                    {
                        return keyAsInt;
                    }
                    else
                    {
                        Console.WriteLine($"{key} was pressed. You must press a key that " +
                            $"corresponds to a spell");
                    }
                }
                catch (FormatException e)
                {
                    Console.WriteLine($"{key} was pressed. You may only press a key that " +
                        $"corresponds to a spell");
                }
            }
        }
        // TODO: Documentations
        public void UseSpell(int spellIndex)
        {
            var spellsWithIndex = _inventory.OfType<Spell>().Select(spell => spell).ToList();
            Spell spellToUse = spellsWithIndex[spellIndex];
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
        /// <c>GetCurrentAttackDamage()</c> returns a the damage of the Player's equipped weapon
        /// </summary>
        /// <returns><c>Player._currentEquippedWeapon.GetAttackDamage()</c></returns>
        public int GetAttackDamage()
        {
            int attackDamage = _currentEquippedWeapon.GetAttackDamage();
            Testing.TestForPositiveInteger(attackDamage);
            return attackDamage;
        }
        public void DisplayAttack(int damage)
        {
            Console.WriteLine($"The player did {damage} damage");
        }
    }
}
