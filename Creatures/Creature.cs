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
        private string _name;
        private int _health;
        private int _maxHealth;
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
        }
    }
}
