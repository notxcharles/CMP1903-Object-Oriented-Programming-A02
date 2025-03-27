using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public class Spell : Item
    {
        private int _healAmount;
        public Spell(string name, int healAmount) : base(name)
        {
            _healAmount = healAmount;
        }
        public int HealAmount
        {
            get { return _healAmount; }
            private set { _healAmount = value; }
        }
    }
}
