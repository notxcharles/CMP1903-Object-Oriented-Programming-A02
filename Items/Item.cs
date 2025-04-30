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
        /// <summary>
        /// Initializes a new instance of the <see cref="Item"/> class.
        /// </summary>
        /// <remarks>
        /// This constructor is intentionally left blank to allow the functionality of loading the class from a save file.
        /// </remarks>
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
    }
}
