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
        public Spell(string name) : base(name)
        {

        }
        public int HealAmount
        {
            get { return _healAmount; }
        }
    }
}
