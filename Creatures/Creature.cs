using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    // TODO: Documentationv
    public class Creature
    {
        protected string _name;
        protected int _health;
        [JsonProperty]
        protected int _maxHealth;
        // TODO: Documentation
        public Creature(string name, int health)
        {
            _name = name;
            _health = health;
            _maxHealth = health;
        }
        // TODO: Documentation
        public Creature(int health)
        {
            _health = health;
            _maxHealth = health;
        }
        // TODO: Documentation
        public Creature(string name)
        {
            _name = name;
        }
        //TODO: Documentation
        public Creature()
        {

        }
        // TODO: Documentation
        public string Name
        {
            get { return _name; }
            protected set { _name = value; }
        }
        // TODO: Documentationv
        public int Health
        {
            get { return _health; }
            set { _health = value; }
        }
        // TODO: Documentation
        public int MaxHealth
        {
            get { return _maxHealth; }
            private set { _maxHealth = value; }
        }
    }
}
