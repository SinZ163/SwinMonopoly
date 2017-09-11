using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinMonopoly.Spaces
{
    class GOTOJailSpace : ISpace
    {
        public string Name => "Goto Jail";

        public void DrawBoard()
        {
            throw new NotImplementedException();
        }

        public void OnLand(Player person)
        {
            //TODO: Move them to jail, set their jail status to true.
        }
    }
}
