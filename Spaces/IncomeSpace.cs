using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinMonopoly.Spaces
{
    class IncomeSpace : ISpace
    {
        public void DrawBoard()
        {
            throw new NotImplementedException();
        }

        public void OnLand(Player person)
        {
            //TODO: Make sure they pay up
            person.Charge(200);
        }
    }
}
