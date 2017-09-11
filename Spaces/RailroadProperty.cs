using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinMonopoly.Spaces
{
    public class RailroadProperty : Property
    {
        public RailroadProperty(string name)
        {
            Name = name;
            Set = PropertySets.Railroad;
        }

        public override void OnLand(Player person)
        {
            throw new NotImplementedException();
        }
    }
}
