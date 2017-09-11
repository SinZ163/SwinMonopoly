using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinMonopoly.Spaces
{
    class JailSpace : ISpace
    {
        public string Name => "Jail";

        public void DrawBoard()
        {
            throw new NotImplementedException();
        }

        public void OnLand(Player person)
        {
            // Nothing happens when landed.
        }
    }
}
