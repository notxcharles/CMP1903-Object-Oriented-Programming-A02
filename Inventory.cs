using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public class Inventory
    {
        private List<Item> _inventory;
        private int _maxLength;
        public Inventory(int maxLength)
        {
            _maxLength = maxLength;
        }

        public void Add(Item item)
        {
            if (_inventory.Count >= _maxLength)
            {
                Console.WriteLine("Your inventory is full, if you wish to add more items to your inventory then you must discard some items");
            }
        }
    }
}
