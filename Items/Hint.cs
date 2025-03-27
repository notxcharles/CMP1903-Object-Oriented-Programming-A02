using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    // TODO: Documentation
    public class Hint : Item
    {
        
        private string _clue;
        // TODO: Documentation
        public Hint(string name, string hint) : base(name)
        {
            _clue = hint;
        }
        // TODO: Documentation
        public string Clue
        {
            get { return _clue; }
        }
    }
}
