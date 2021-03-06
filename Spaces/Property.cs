﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinMonopoly.Spaces
{
    public abstract class Property : ISpace
    {
        public Player owner;
        
        public enum PropertySets
        {
            Undefined = 0,
            Brown,
            Teal,
            Magenta,
            Orange,
            Red,
            Yellow,
            Green,
            Blue,
            Railroad,
            Utility
        }
        public PropertySets Set { get; protected set; }

        public int PropertyValue { get; protected set; }

        public bool IsMortgaged { get; private set; }

        public Property()
        {
            owner = null;
            IsMortgaged = false;
        }

        public virtual void Mortgage()
        {
            if (IsMortgaged) throw new Exception("Unable to mortgage an already mortgaged property");
            owner.GainMoney(PropertyValue / 2);
            IsMortgaged = true;
        }
        public void UnMortgage()
        {
            if (IsMortgaged == false) throw new Exception("Unable to unmortgage an already unmortgaged property");
            owner.Charge((int)(PropertyValue * 0.6));
            IsMortgaged = false;
        }

        public string Name { get; protected set; }

        public abstract void OnLand(Player person);
    }
}
