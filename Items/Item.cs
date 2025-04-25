using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public class Item
    {
        [JsonProperty]
        private string _name;
        /// <summary>
        /// Initialises a new instance of the <see cref="Item"/> class with the specified
        /// name
        /// </summary>
        /// <param name="name">The name of the spell</param>
        public Item(string name)
        {
            _name = name;
        }
        public Item()
        {

        }
        /// <summary>
        /// Gets or sets the name of the item
        /// </summary>
        /// <value>The name of the item</value>
        public string Name
        { 
            get { return _name; }
            protected set { _name = value; }
        }
        /// <summary>
        /// Create the summary of the item
        /// </summary>
        /// <remarks>
        /// The summary contains the name of the item and how much health it heals
        /// </remarks>
        /// <returns>The summary</returns>
        public virtual string CreateSummary()
        {
            return $"This item is called {Name}";
        }
    }
}
