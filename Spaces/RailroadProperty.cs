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

        public override void DrawBoard()
        {
            throw new NotImplementedException();
        }

        public override void DrawCard()
        {
            throw new NotImplementedException();
        }

        public override void OnLand(Player person)
        {
            throw new NotImplementedException();
        }
    }
}
