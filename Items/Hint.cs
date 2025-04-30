using Newtonsoft.Json;
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
        [JsonProperty]
        private string _clue;
        /// <summary>
        /// Initialises a new instance of the <see cref="Hint"/> class with the specified
        /// name and hint
        /// </summary>
        /// <param name="name">The name of the spell</param>
        /// <param name="hint">The clue</param>
        public Hint(string name, string hint) : base(name)
        {
            _clue = hint;
        }
        /// <summary>
        /// Gets the value of the clue
        /// </summary>
        public string Clue
        {
            get { return _clue; }
        }
    }
}
