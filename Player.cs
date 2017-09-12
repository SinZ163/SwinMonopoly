using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;

using SwinMonopoly.Spaces;

namespace SwinMonopoly
{
    public class Player
    {
        public string Nickname { get; private set; }
        public Color Color { get; private set; }
        public int Money { get; private set; }

        public List<Property> ownedProperty;

        public bool Alive;

        private int space;
        public int Space
        {
            get => space;
            set
            {
                while (value >= 40) value -= 40;
                space = value;
            }
        }

        public Player(string name, Color color)
        {
            Nickname = name;
            Color = color;
            Money = 1500;
            Space = 0;
            Alive = true;
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
            throw new Exception("Not enough funds");
        }
    }
}
