using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public class Creature
    {
        private string _name;
        private int _health;
        private int _maxHealth;

        public Creature(string name, int health)
        {
            _name = name;
            _health = health;
            _maxHealth = health;
        }

        public string Name
        {
            get { return _name; }
        }
        public int Health
        {
            get { return _health; }
            set { _health = value; }
        }
        public int MaxHealth
        {
            get { return _maxHealth; }
        }
    }
}
