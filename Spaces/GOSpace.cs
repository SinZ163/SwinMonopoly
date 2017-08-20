using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinMonopoly.Spaces
{
    public class GOSpace : ISpace
    {
        public string Name => "GO";

        public void DrawBoard()
        {
            throw new NotImplementedException();
        }

        //TODO: Make sure it pays when you go past
        //TODO: Make sure it doesn't double pay
        public void OnLand(Player person)
        {
            person.GainMoney(200);
        }
    }
}
