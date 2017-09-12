using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinMonopoly.Spaces
{
    public class RailroadProperty : Property
    {
        public RailroadProperty(string name) : base()
        {
            Name = name;
            Set = PropertySets.Railroad;
        }

        public override void OnLand(Player person)
        {
            if (owner is null)
            {
                // Unowned
                person.Charge(PropertyValue);
                owner = person;
            }
            else
            {
                if (owner == person)
                    return;
                if (IsMortgaged)
                    return;
                // TODO: Check monopoly status
                person.Charge(25);
            }
        }
    }
}
