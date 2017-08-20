using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;

namespace SwinMonopoly
{
    public class Player
    {
        public string Nickname { get; private set; }
        public Color Color { get; private set; }
        public int Money { get; private set; }

        public List<Property> ownedProperty;

        public Player(string name, Color color)
        {
            Nickname = name;
            Color = color;
        }

        public void GainMoney(int amount)
        {
            Money += amount;
        }

        public bool Charge(int amount)
        {
            if (Money >= amount)
            { 
                Money -= amount;
                return true;
            }
            return false;
        }
    }
}
