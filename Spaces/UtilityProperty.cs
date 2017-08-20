using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinMonopoly.Spaces
{
    class UtilityProperty : Property
    {
        public enum UtilityType
        {
            Electric,
            Water
        }
        public UtilityType Type { get; }

        public UtilityProperty(UtilityType type)
        {
            switch(type)
            {
                case UtilityType.Electric:
                    Name = "Electric Company";
                    break;
                case UtilityType.Water:
                    Name = "Water Works";
                    break;
            }
            Type = type;
            Set = PropertySets.Utility;
        }
        public override void DrawBoard()
        {
            throw new NotImplementedException();
        }

        public override void DrawCard()
        {
            throw new NotImplementedException();
        }

        // TODO: Figure out how to charge based on dice roll
        public override void OnLand(Player person)
        {
            throw new NotImplementedException();
        }
    }
}
