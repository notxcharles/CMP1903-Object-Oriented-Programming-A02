using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public class Item
    {
        private string _name;
        public Item(string name)
        {
            _name = name;
        }
        public Item()
        {

        }
        public string Name
        { 
            get { return _name; }
            protected set { _name = value; }
        }
        public virtual string CreateSummary()
        {
            string summary = $"There is a {_name} in the room";
            return summary;
        }
    }
}
