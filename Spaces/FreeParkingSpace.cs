using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinMonopoly.Spaces
{
    class FreeParkingSpace : ISpace
    {
        public string Name => "Free Parking";

        public void DrawBoard()
        {
            throw new NotImplementedException();
        }

        public void OnLand(Player person)
        {
            // TODO: Check house rules and gain tax income
        }
    }
}
